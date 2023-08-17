using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    public float currentHealth;
    private float maxHeath;
    private void Awake()
    {
        maxHeath = DataManager.Instance.GlobalConfig.maxHealth;
        currentHealth = maxHeath;
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Player Dead");
            // Die();
        }
    }
   /* public void TakeDamage(float amount)
    {
        currentHealth -= amount;
       
    }*/
    private void Die()
    {
        Destroy(this.gameObject, 5);
    }
}
