using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    public float currentHealth;
    private float maxHeath;

    private PlayerRagdoll playerRagdoll;
    private void Awake()
    {
        playerRagdoll = GetComponent<PlayerRagdoll>();

        maxHeath = DataManager.Instance.GlobalConfig.maxHealth;
        currentHealth = maxHeath;
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Player Dead");
             Die();
        }
    }
   /* public void TakeDamage(float amount)
    {
        currentHealth -= amount;
       
    }*/
    private void Die()
    {

        playerRagdoll.ActiveRagdoll();
        Destroy(this.gameObject, 5);        
       
    }
}
