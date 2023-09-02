using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    public float currentHealth;
    private float maxHealth;
    public Vector3 direction;

    PlayerRagdoll playerRagdoll;
    private void Start()
    {

        if (DataManager.HasInstance)
        {
            maxHealth = DataManager.Instance.GlobalConfig.maxHealth;
        }
        currentHealth = maxHealth;

        if (PlayerManager.HasInstance)
        {
            playerRagdoll = PlayerManager.Instance.playerRagdoll;
        }
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
             Die();
        }
    }
    private void Die()
    {
        Debug.Log("Player Dead");

        this.playerRagdoll.ActiveRagdoll();

        Destroy(this.gameObject, 5);
    }
}
