using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    public WeaponSlot weaponSlot;
    public string weaponName;
    public bool isFiring = false;
    public int fireRate = 25;
    public float bulletSpeed = 1000f;
    public float bulletDrop = 0f;
    public ParticleSystem[] muzzleFlash;
    public float[] spreads;

    public ParticleSystem hitEffect;
    public TrailRenderer tracerEffect;

    public Transform raycastOrigin;
    public Transform raycastDestination;
    public WeaponRecoil weaponRecoil;
    public GameObject magazine;

    public int ammoCount;
    public int totalAmmo;
    public float damage;
    public int ammoPerShot;

    private Ray ray;
    private RaycastHit hitInfo;
    private float accumulatedTime;
    private float maxLifetime = 3f;

    private void Awake()
    {
        weaponRecoil = GetComponent<WeaponRecoil>();

    }

    public void StartFiring()
    {
        isFiring = true;
        if (accumulatedTime > 0.0f)
        {
            accumulatedTime = 0.0f;
        }
        weaponRecoil.Reset();
    }

    public void StopFiring()
    {
        isFiring = false;
    }

    public void UpdateWeapon(float deltaTime, Vector3 target)
    {
        if (isFiring)
        {
            UpdateFiring(deltaTime, target);
        }

        accumulatedTime += deltaTime;

        UpdateBullets(deltaTime);
    }

    private void UpdateFiring(float deltaTime, Vector3 target)
    {
        accumulatedTime += deltaTime;
        float fireInterval = 1.0f / fireRate;
        while (accumulatedTime >= 0f)
        {
            FireBullet(target);
            accumulatedTime -= fireInterval;
        }
    }

    private void UpdateBullets(float deltaTime)
    {
        SimulateBullet(deltaTime);
        DestroyBullets();
    }

    private void SimulateBullet(float deltaTime)
    {
        ObjectPool.Instance.pooledObjects.ForEach(bullet =>
        {
            Vector3 p0 = GetPosition(bullet);
            bullet.time += deltaTime;
            Vector3 p1 = GetPosition(bullet);
            RaycastSegment(p0, p1, bullet);
        });
    }

    private void DestroyBullets()
    {
        foreach (Bullet bullet in ObjectPool.Instance.pooledObjects)
        {
            if(bullet.time >= maxLifetime)
            {
                bullet.Deactive();
            }
        }
    }

    private void FireBullet(Vector3 target)
    {
        if(ammoCount <= 0)
        {
            return;
        }

        ammoCount -= ammoPerShot;

        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.BroadCast(ListenType.UPDATE_AMMO, ammoCount);
        }

        foreach (var item in muzzleFlash)
        {
            item.Emit(1);
        }
        for (int i = 0; i < ammoPerShot; i++)
        {
            float xSpread = Random.Range(spreads[0], spreads[1]);
            float ySpread = Random.Range(spreads[2], spreads[3]);
            Vector3 randomSpread = new Vector3(xSpread, ySpread, 0);
            Vector3 velocity = ((target - raycastOrigin.position).normalized + randomSpread) * bulletSpeed;

            var bullet = ObjectPool.Instance.GetPooledObject();
            bullet.Active(raycastOrigin.position, velocity);

            weaponRecoil.GenerateRecoil(weaponName);
        }
   
    }

    private Vector3 GetPosition(Bullet bullet)
    {
        //p = p0 + v*t + 1/2*g*t*t
        Vector3 gravity = Vector3.down * bulletDrop;
        return (bullet.initialPosition) + (bullet.initialVelocity * bullet.time) + (0.5f * gravity * bullet.time * bullet.time);
    }

    private void RaycastSegment(Vector3 start, Vector3 end, Bullet bullet)
    {
        Vector3 direction = end - start;
        float distance = direction.magnitude;
        ray.origin = start;
        ray.direction = direction;
        if(Physics.Raycast(ray, out hitInfo, distance))
        {
            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);

            bullet.transform.position = hitInfo.point;
            bullet.time = maxLifetime;
            end = hitInfo.point;
            var rigidbody = hitInfo.collider.GetComponent<Rigidbody>();
            if (rigidbody)
            {
                rigidbody.AddForceAtPosition(ray.direction * 10, hitInfo.point, ForceMode.Impulse);
            }

            var hitBox = hitInfo.collider.GetComponent<HitBox>();
            if (hitBox)
            {
                hitBox.OnHit(this, ray.direction);
            }
        }
        bullet.transform.position = end;
    }
}
