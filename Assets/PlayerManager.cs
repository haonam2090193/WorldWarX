using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals("Map2"))
        {
            this.GetComponent<CharacterController>().enabled = false;   
            
            activeWeapon.enabled = false;
            characterAiming.enabled = false;
            weaponReload.enabled = false;
            playerHeath.enabled = false;
            characterLocomotion.enabled = false;
            playerRagdoll.enabled = false;

            Transform spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;
            
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
            DOVirtual.DelayedCall(1.5f, () =>
            {
                this.GetComponent<CharacterController>().enabled = true;
                activeWeapon.enabled = true;
                characterAiming.enabled = true;
                weaponReload.enabled = true;
                playerHeath.enabled = true;
                characterLocomotion.enabled = true;
                playerRagdoll.enabled = true;
            });

        }
    }
}
