using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSetting : BasePopup
{
    private float bgmVolume;
    private float effectVolume;

    public Slider seSlider;
    public Slider bgmSlider;

    public override void Init()
    {
        base.Init();
        if (AudioManager.HasInstance)
        {
            effectVolume = AudioManager.Instance.AttachSESource.volume;
            bgmVolume = AudioManager.Instance.AttachBGMSource.volume;

            seSlider.value = effectVolume;
            bgmSlider.value = bgmVolume;
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

    public void ChangeSEVolume(float volume)
    {
        effectVolume = volume;
    }
    public void ChangeBGMVolume(float volume)
    {
        bgmVolume = volume;
    }
    public void OnClickCloseButton()    
    {
        Debug.Log("Clicked");
        this.Hide();
    }
}
