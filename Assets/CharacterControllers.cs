using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllers : MonoBehaviour
{
    [HideInInspector]
    public CharacterAiming characterAiming;
    [HideInInspector]
    public ActiveWeapon activeWeapon;
    [HideInInspector]
    public WeaponReload weaponReload;
    [HideInInspector]
    public PlayerHeath playerHeath;
    [HideInInspector]
    public PlayerRagdoll playerRagdoll;
    [HideInInspector]
    public CharacterLocomotion characterLocomotion;
    private void Awake()
    {
        characterAiming = GetComponent<CharacterAiming>();
        activeWeapon = GetComponent<ActiveWeapon>();
        weaponReload = GetComponent<WeaponReload>();
        playerHeath = GetComponent<PlayerHeath>();
        characterLocomotion = GetComponent<CharacterLocomotion>();
    }
}
