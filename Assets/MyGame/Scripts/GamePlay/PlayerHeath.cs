using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerHeath : MonoBehaviour
{
    public int currentHealth;
    private int maxHealth;
    public Vector3 direction;
    Animator animator;
    public int winPoint;
    PlayerRagdoll playerRagdoll;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowScreen<InGameScreen>();
        }
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
        if (UIManager.HasInstance)
        {
            DOVirtual.DelayedCall(1f, () =>
            {
                UIManager.Instance.ShowPopup<InGameMenu>();
            });
        }
        this.playerRagdoll.ActiveRagdoll();

        animator.Play("weapon_unarmed");

        Destroy(this.gameObject, 5);
    }
}
