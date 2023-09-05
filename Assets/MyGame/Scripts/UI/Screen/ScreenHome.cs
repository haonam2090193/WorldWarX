using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;

public class ScreenHome : BaseScreen
{
    public override void Init()
    {
        base.Init();
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlayBGM(AUDIO.BGM_001);
        }
    }
    public override void Show(object data)
    {
        base.Show(data);

    }
    
    public override void Hide()
    {
        base.Hide();
    }
    public void StartGame()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_CLICK);
        }

        SceneManager.LoadScene("Map1");
        this.Hide();
        if(AudioManager.HasInstance)
        {
            AudioManager.Instance.StopBGMVolume();
        }
        UIManager.Instance.ShowScreen<InGameScreen>();
    }
    
    public void OnClickPopupSetting()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_CLICK);
        }
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowPopup<PopupSetting>();
        }
    }
}
