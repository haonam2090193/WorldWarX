using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ResetPoint : MonoBehaviour
{
    private float defaultBullet;
    private GameObject player;

    //Default Index :
    public Transform defaultPlayerTransform;
    private Transform playerTransform;
    private CharacterController characterController;
    private Animator rigController;
    ActiveWeapon activeWeapon;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.playerTransform = player.transform;
        this.activeWeapon = player.GetComponent<ActiveWeapon>();
        this.characterController = player.GetComponent<CharacterController>();
        
        this.rigController = GameObject.FindGameObjectWithTag("Rig").GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            DefaultIndex();
        }
    }
    public void DefaultIndex()
    {
        rigController.Rebind();
        //rigController.Play("weapon_unarmed");
       
        foreach(Transform guns in activeWeapon.weaponSlots)
        {
            foreach (Transform childs in guns)
            {
                Destroy(childs.gameObject);    
            }
        }
        this.activeWeapon.equippedWeapons = new RaycastWeapon[3];
        this.characterController.enabled = false;
        this.playerTransform.position = defaultPlayerTransform.position;
        DOVirtual.DelayedCall(0.1f, () =>
        {
            this.characterController.enabled = true;
        });
    }
}
