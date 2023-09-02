using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : BaseManager<PlayerManager>
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

    private void Start()
    {
            characterAiming = GetComponent<CharacterAiming>();
            activeWeapon = GetComponent<ActiveWeapon>();
            weaponReload = GetComponent<WeaponReload>();
            playerHeath = GetComponent<PlayerHeath>();
            playerRagdoll = GetComponent<PlayerRagdoll>();
            characterLocomotion = GetComponent<CharacterLocomotion>();
    }
}
