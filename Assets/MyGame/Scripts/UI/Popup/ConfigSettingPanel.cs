using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigSettingPanel : BasePopup
{
    private float bgmVolume;
    private float effectVolume;
    private float xVolume;
    private float yVolume;

    public Slider sliderBGM;
    public Slider sliderEffect;
    public Slider sliderXAxis;
    public Slider sliderYAxis;
    public override void Init()
    {
        base.Init();
        if (AudioManager.HasInstance)
        {

            bgmVolume = AudioManager.Instance.AttachBGMSource.volume;
            effectVolume = AudioManager.Instance.AttachSESource.volume;

            sliderBGM.value = bgmVolume;
            sliderEffect.value = effectVolume;
        }
        if (PlayerManager.HasInstance)
        {
            xVolume = PlayerManager.Instance.characterAiming.xAxis.m_MaxSpeed;
            yVolume = PlayerManager.Instance.characterAiming.yAxis.m_MaxSpeed;

            sliderXAxis.value = xVolume;
            sliderYAxis.value = yVolume;
        }

    }

    public override void Show(object data)
    {
        base.Show(data);
        if (AudioManager.HasInstance)
        {
            bgmVolume = AudioManager.Instance.AttachBGMSource.volume;
            effectVolume = AudioManager.Instance.AttachSESource.volume;

            sliderBGM.value = bgmVolume;
            sliderEffect.value = effectVolume;
        }
        if (PlayerManager.HasInstance)
        {
            xVolume = PlayerManager.Instance.characterAiming.xAxis.m_MaxSpeed;
            yVolume = PlayerManager.Instance.characterAiming.yAxis.m_MaxSpeed;

            sliderXAxis.value = xVolume;
            sliderYAxis.value = yVolume;
        }
    }

    public void OnSoundSettingClick()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowPopup<SoundSetting>();
        }
    }
}
