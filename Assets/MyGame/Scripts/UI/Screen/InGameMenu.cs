using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : BasePopup
{
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
    }

    public void OnReturnMenuClick()
    {
        SceneManager.LoadScene("Menu");
        this.Hide();

        // 2. : cách về Menu
    }
}
