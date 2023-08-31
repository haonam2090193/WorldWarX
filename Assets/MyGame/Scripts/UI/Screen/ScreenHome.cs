using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;

public class ScreenHome : BaseScreen
{
    public Toggle pauseVideoToggle;
    public VideoPlayer BGMvideoPlayer;
    public override void Init()
    {
        base.Init();
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlayBGM(AUDIO.BGM_BGM_001);
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
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowPopup<PopupSetting>();
        }
    }
    
    public void OnPauseVideoToggle(bool toggle)
    {
        if(pauseVideoToggle.isOn)
        {
            BGMvideoPlayer.Pause();
        }
        else
        {
            BGMvideoPlayer.Play();
        }
    }

}
