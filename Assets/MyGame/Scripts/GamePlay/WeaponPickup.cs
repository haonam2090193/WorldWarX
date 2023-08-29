using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public RaycastWeapon weaponPrefab;

    public Transform player;
    private void Update()
    {
        this.transform.LookAt(player);
    }
    private void OnTriggerEnter(Collider other)
    {  
            ActiveWeapon activeWeapon = other.gameObject.GetComponent<ActiveWeapon>();
            if (activeWeapon)
            {
                RaycastWeapon newWeapon = Instantiate(weaponPrefab);
                activeWeapon.Equip(newWeapon);
            }      
    }   
}
