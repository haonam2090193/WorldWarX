using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ActiveWeapon : MonoBehaviour
{
    public Animator rigController;
    public Transform crosshairTarget;
    public Transform[] weaponSlots;
    public bool isChangingWeapon;
    public bool canFire;

    public bool isHolstered = false;
    private int activeWeaponIdx; 
    RaycastWeapon currentWeapon;
    [SerializeField]
    private RaycastWeapon[] equippedWeapons = new RaycastWeapon[3];

    private CharacterAiming characterAiming;
    private WeaponReload weaponReload;


    void Start()
    {
        if (PlayerManager.HasInstance)
        {
            this.weaponReload = PlayerManager.Instance.weaponReload;

        }
     
    }

    void Update()
    {
        if (crosshairTarget == null)
        {
            GameObject.Find("CrossHairTarget");

            //are fixing
        }

        currentWeapon = GetActiveWeapon();

        var raycastWeapon = GetWeapon(activeWeaponIdx);
        bool isNotSprinting = rigController.GetCurrentAnimatorStateInfo(2).shortNameHash == Animator.StringToHash("notSprinting");
        canFire = !isHolstered && isNotSprinting && !this.weaponReload.isReloading;
        if (raycastWeapon)
        {
            if (Input.GetButtonDown("Fire1") && canFire && !raycastWeapon.isFiring)
            {
                if (raycastWeapon.singleMode)
                {
                    raycastWeapon.FireBullet(crosshairTarget.position);
                }
                else
                {
                    raycastWeapon.StartFiring();
                }
            }

                raycastWeapon.UpdateWeapon(Time.deltaTime, crosshairTarget.position);

            if (Input.GetButtonUp("Fire1") || !canFire)
            {
                raycastWeapon.StopFiring();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetActiveWeapon(WeaponSlot.Primary);
                Debug.Log("alpha1");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetActiveWeapon(WeaponSlot.Secondary);
                Debug.Log("alpha2");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SetActiveWeapon(WeaponSlot.Submary);
                Debug.Log("alpha2");
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                ToggleActiveWeapon();
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (currentWeapon.weaponSlot == WeaponSlot.Primary && equippedWeapons[1] != null)
                {
                    Debug.Log("Primary");
                    SetActiveWeapon(WeaponSlot.Secondary);
                }
                else if (currentWeapon.weaponSlot == WeaponSlot.Secondary&&equippedWeapons[2] !=null)
                {
                    Debug.Log("Seacondary");
                    SetActiveWeapon(WeaponSlot.Submary);
                }
                else if (currentWeapon.weaponSlot == WeaponSlot.Submary && equippedWeapons[0] != null)
                {
                    Debug.Log("Submary");
                    SetActiveWeapon(WeaponSlot.Primary);
                }
            }
        }
    }

   
    public bool IsFiring()
    {
        RaycastWeapon currentWeapon = GetActiveWeapon();
        if (!currentWeapon)
        {
            return false;
        }

        return currentWeapon.isFiring;
    }

    public void Equip(RaycastWeapon newWeapon)
    {
        int weaponSlotIndex = (int)newWeapon.weaponSlot;
        var raycastWeapon = GetWeapon(weaponSlotIndex);
        if (raycastWeapon)
        {
            Destroy(raycastWeapon.gameObject);
        }
        raycastWeapon = newWeapon;
        raycastWeapon.raycastDestination = crosshairTarget;
        raycastWeapon.weaponRecoil.characterAiming = characterAiming;
        raycastWeapon.weaponRecoil.rigController = rigController;

        raycastWeapon.transform.SetParent(weaponSlots[weaponSlotIndex],false);

        equippedWeapons[weaponSlotIndex] = raycastWeapon;
        SetActiveWeapon(newWeapon.weaponSlot);
        Debug.Log(weaponSlotIndex);
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.BroadCast(ListenType.UPDATE_AMMO, raycastWeapon.ammoCount);
        }
    }

    public RaycastWeapon GetActiveWeapon()
    {
        return GetWeapon(activeWeaponIdx);
    }


    private void SetActiveWeapon(WeaponSlot weaponSlot)
    {
        int holsterIndex = activeWeaponIdx;
        int activateIndex = (int)weaponSlot;

        if (holsterIndex == activateIndex)
        {
            holsterIndex = -1;
        }

        StartCoroutine(SwitchWeapon(holsterIndex, activateIndex));
    }
    private void ToggleActiveWeapon()
    {
        bool isHolstered = rigController.GetBool("holster_weapon");
        if (isHolstered)
        {
            StartCoroutine(ActivateWeapon(activeWeaponIdx));
        }
        else
        {
            StartCoroutine(HolsterWeapon(activeWeaponIdx));
        }
    }

    private RaycastWeapon GetWeapon(int index)
    {
        if(index < 0 || index >= equippedWeapons.Length)
        {
            return null;
        }
        return equippedWeapons[index];
    }

    private IEnumerator SwitchWeapon(int holsterIndex, int activateIndex)
    {
        rigController.SetInteger("weapon_index", activateIndex);
        yield return StartCoroutine(HolsterWeapon(holsterIndex));
        yield return StartCoroutine(ActivateWeapon(activateIndex));
        activeWeaponIdx = activateIndex;
    }

    private IEnumerator HolsterWeapon(int index)
    {

        isChangingWeapon = true;
        isHolstered = true;
        var weapon = GetWeapon(index);
        if (weapon)
        {
            rigController.SetBool("holster_weapon", true);
            yield return new WaitForSeconds(0.1f);
            do
            {
                yield return new WaitForEndOfFrame();
            } while (rigController.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
        }
        isChangingWeapon = false;
    }

    private IEnumerator ActivateWeapon(int index)
    {
        isChangingWeapon = true;
        var weapon = GetWeapon(index);
        if (weapon)
        {
            rigController.SetBool("holster_weapon", false);
            rigController.Play("equip_" + weapon.weaponName);
            yield return new WaitForSeconds(0.1f);
            do
            {
                yield return new WaitForEndOfFrame();
            } while (rigController.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
            isHolstered = false;    
            if (ListenerManager.HasInstance)
            {
                ListenerManager.Instance.BroadCast(ListenType.UPDATE_AMMO, weapon.ammoCount);
            }
        }
        isChangingWeapon = false;

    }
}