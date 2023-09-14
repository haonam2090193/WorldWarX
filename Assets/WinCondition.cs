using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class WinCondition : MonoBehaviour
{
    private void Awake()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerManager.HasInstance)
            {
                PlayerManager.Instance.playerHeath.winPoint += 1;
                Destroy(this.gameObject);
                if (UIManager.HasInstance)
                {
                    DOVirtual.DelayedCall(1f, () =>
                    {
                        UIManager.Instance.ShowPopup<InGameMenu>();
                    });
                }
            }
        }
    }
}

