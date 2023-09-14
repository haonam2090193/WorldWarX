using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class InGameMenu : BasePopup
{
    public GameObject loseCondition;
    public GameObject resume;
    public GameObject winCondition;

    public bool isWinning;
    private void Update()
    {
        if (PlayerManager.HasInstance)
        {
            if(PlayerManager.Instance.playerHeath.currentHealth < 0)
            {
                LoseCondition();
            }
            else if(PlayerManager.Instance.playerHeath.winPoint >= 1)
            {
                WinCondition();
            }
           
        }
    }
    public override void Init()
    {
        base.Init();
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

    public void OnReturnMenuClick()
    {

        Application.Quit();

    }

    public void LoseCondition()
    {
        if (GameManager.HasInstance)
        {
            GameManager.Instance.PauseGame();
        }
        loseCondition.SetActive(true);
        resume.SetActive(false);
    }
    public void WinCondition()
    {
        if (GameManager.HasInstance)
        {
            GameManager.Instance.PauseGame();
        }
        winCondition.SetActive(true);
        resume.SetActive(false);

    }

}
