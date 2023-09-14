using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class Loading2 : MonoBehaviour
{

    private GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player");
        //characterController = PlayerManager.Instance.GetComponent<CharacterController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LoadSceneLogic();
        }
    }
    private void LoadSceneLogic()
    {

        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowNotify<NotifyLoading>();
            NotifyLoading scr = UIManager.Instance.GetExistNotify<NotifyLoading>();
            if (scr != null)
            {
                scr.AnimationLoaddingText();
                scr.DoAnimationLoadingProgress(5, () =>
                {
                    if (PlayerManager.HasInstance)
                    {
                        PlayerManager.Instance.GetComponent<CharacterController>().enabled = false;
                        Transform spawnPoint = GameObject.FindWithTag("SpawnLocation").transform;
                        player.transform.position = spawnPoint.position;
                        player.transform.rotation = spawnPoint.rotation;
                        PlayerManager.Instance.activeWeapon.enabled = false;
                        PlayerManager.Instance.characterAiming.enabled = false;
                        PlayerManager.Instance.weaponReload.enabled = false;
                        PlayerManager.Instance.playerHeath.enabled = false;
                        PlayerManager.Instance.characterLocomotion.enabled = false;
                    }


                    DOVirtual.DelayedCall(1f, () =>
                    {
                        if (PlayerManager.HasInstance)
                        {
                            PlayerManager.Instance.GetComponent<CharacterController>().enabled = true;

                            PlayerManager.Instance.activeWeapon.enabled = true;
                            PlayerManager.Instance.characterAiming.enabled = true;
                            PlayerManager.Instance.weaponReload.enabled = true;
                            PlayerManager.Instance.playerHeath.enabled = true;
                            PlayerManager.Instance.characterLocomotion.enabled = true;

                        }
                    });
                    scr.Hide();
                });
            }
            else
            {
                Debug.Log("Null");
            }
        }
    }
}
