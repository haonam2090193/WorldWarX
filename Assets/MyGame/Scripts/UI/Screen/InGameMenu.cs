using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class InGameMenu : BasePopup
{
    private float defaultBullet;
    private GameObject player;
    private Animator animator;

    //Default Index :
    public Transform spawnPoisition;
    private Transform playerTransform;
    private CharacterController characterController;
    private Animator rigController;
    ActiveWeapon activeWeapon;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spawnPoisition = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        this.playerTransform = player.transform;
        this.activeWeapon = player.GetComponent<ActiveWeapon>();
        this.characterController = player.GetComponent<CharacterController>();

        this.rigController = GameObject.FindGameObjectWithTag("Rig").GetComponent<Animator>();
    }
    public override void Hide()
    {
        base.Hide();
    }

    public override void Show(object data)
    {
        base.Show(data);
    }

    public void OnResumeClick()
    {
        this.Hide();
        GameManager.Instance.ContinueGame();
    }

    public void OnSettingClick()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowPopup<PopupSetting>();
        }
    }

    public void OnRestartClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
        DefaultIndex();
    }

    public void OnReturnMenuClick()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowNotify<Map1ToMenu>();
        }
        this.Hide();

        // 2. : cách về Menu
    }

  /*  IEnumerator FadeIn()
    {
        animator.Play("FadeIn");

        yield return new WaitForSeconds(2f);
    }
    IEnumerator FadeOut()
    {
        animator.Play("FadeOut");

        yield return new WaitForSeconds(2f);
    }*/
    private void DefaultIndex()
    {
       // animator.Play("FadeIn");
        spawnPoisition = GameObject.FindGameObjectWithTag("SpawnPoint").transform;

        rigController.Play("weapon_unarmed");

        foreach (Transform guns in activeWeapon.weaponSlots)
        {
            foreach (Transform childs in guns)
            {
                Destroy(childs.gameObject);
            }
        }
        this.activeWeapon.equippedWeapons = new RaycastWeapon[3];
        this.characterController.enabled = false;
        this.playerTransform.position = spawnPoisition.position;
        DOVirtual.DelayedCall(0.1f, () =>
        {
            this.characterController.enabled = true;
        });
        //  animator.Play("FadeOut");

    }
}
