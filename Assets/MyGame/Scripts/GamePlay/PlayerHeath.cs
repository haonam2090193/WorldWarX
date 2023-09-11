using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    public int currentHealth;
    private int maxHealth;
    public Vector3 direction;

    PlayerRagdoll playerRagdoll;
    private void Start()
    {

        if (DataManager.HasInstance)
        {
            maxHealth = DataManager.Instance.GlobalConfig.maxHealth;
        }
        currentHealth = maxHealth;
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.BroadCast(ListenType.UPDATE_HP, currentHealth);
        }
        if (PlayerManager.HasInstance)
        {
            playerRagdoll = PlayerManager.Instance.playerRagdoll;
        }
    }
    private void Update()
    {
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.BroadCast(ListenType.UPDATE_HP, currentHealth);
        }
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
