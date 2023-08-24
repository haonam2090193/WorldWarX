using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [Tooltip("The bullet prefab to be used for shooting")]
    public GameObject bulletPrefab;
    [Tooltip("The maximum number of bullets allowed in the pool")]
    public int maxBulletsInPool = 10;
    [Tooltip("The force applied to the bullet when shooting")]
    public float shootingForce = 10f;
    [Tooltip("The time it takes to reload the gun")]
    public float reloadTime = 1f;
    [Tooltip("The time it takes for a bullet to deactivate after hitting an object")]
    public float bulletDeactivationTime = 2f;
    [Tooltip("The position where the bullets will be spawned")]
    public Transform firePosition;
    [Tooltip("The fire rate of the gun (bullets per second)")]
    public float fireRate = 5f;
    [Tooltip("Enable continuous shooting mode")]
    public bool continuousMode = false;

    private List<GameObject> bulletPool;
    private bool isReloading = false;
    private bool canShoot = true;

    private void Start()
    {
        bulletPool = new List<GameObject>();
        for (int i = 0; i < maxBulletsInPool; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    private void Update()
    {
        if (continuousMode)
        {
            if (Input.GetButton("Fire1") && !isReloading && canShoot)
            {
                Shoot();
                StartCoroutine(StartFireRate());
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && !isReloading && canShoot)
            {
                Shoot();
                StartCoroutine(StartFireRate());
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(Reload());
        }
    }

    private void Shoot()
    {
        GameObject bullet = GetBulletFromPool();
        if (bullet != null)
        {
            bullet.transform.position = firePosition.position;
            bullet.transform.rotation = firePosition.rotation;
            bullet.SetActive(true);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = firePosition.forward * shootingForce;
            StartCoroutine(DeactivateBullet(bullet));
        }
    }

    private GameObject GetBulletFromPool()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }

    private IEnumerator Reload()
    {
        Debug.Log("Reload");
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }

    private IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletDeactivationTime);
        bullet.SetActive(false);
    }

    private IEnumerator StartFireRate()
    {
        canShoot = false;
        yield return new WaitForSeconds(1f / fireRate);
        canShoot = true;
    }
}