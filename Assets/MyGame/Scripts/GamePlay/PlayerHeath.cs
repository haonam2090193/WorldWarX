using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    private float currentHealth;
    private float maxHeath;
    private void Awake()
    {
        currentHealth = maxHeath;
        maxHeath = DataManager.Instance.GlobalConfig.maxHealth;
    }

   public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        
    }
}
