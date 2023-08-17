using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    public float currentHealth;
    private float maxHealth;
    public Vector3 direction;
    private PlayerRagdoll playerRagdoll;
    private Rigidbody rigidbody;

    private void Awake()
    {
        playerRagdoll = GetComponent<PlayerRagdoll>();
        if (DataManager.HasInstance)
        {
            maxHealth = DataManager.Instance.GlobalConfig.maxHealth;
        }
        
        rigidbody = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Player Dead");
             Die();
        }
    }
    private void Die()
    {

        playerRagdoll.ActiveRagdoll();
        playerRagdoll.ApplyForce(direction, rigidbody);
        Destroy(this.gameObject, 5);
    }
}
