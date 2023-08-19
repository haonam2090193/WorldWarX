using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    public float currentHealth;
    private float maxHealth;
    public Vector3 direction;
    private PlayerRagdoll playerRagdoll;
    //private Rigidbody rigidbody;
    private CharacterAiming characterAiming;


    private void Awake()
    {
        playerRagdoll = GetComponent<PlayerRagdoll>();
        if (DataManager.HasInstance)
        {
            maxHealth = DataManager.Instance.GlobalConfig.maxHealth;
        }
        characterAiming = GetComponent<CharacterAiming>();
       // rigidbody = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            //Debug.Log("Player Dead");
             Die();
        }
    }
    private void Die()
    {
        Debug.Log("Player Dead");

        playerRagdoll.ActiveRagdoll();
        //playerRagdoll.ApplyForce(direction, rigidbody);
        Destroy(gameObject, 5);
        characterAiming.enabled = false;
        this.enabled = false;
    }
}
