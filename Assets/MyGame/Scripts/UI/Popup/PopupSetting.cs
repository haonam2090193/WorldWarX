using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSetting : BasePopup
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

    public override void Hide()
    {
        base.Hide();
    }

    public void OnClickCloseButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_CLICK);
        }
        this.Hide();

    }

    public void OnBGMValueChange(float v)
    {
        Debug.Log("AAAA");
        bgmVolume = v;
    }

    public void OnEffectValueChange(float v)
    {
        effectVolume = v;
    }

    public void OnXAxisValueChange(float v)
    {
        xVolume = v;
    }

    public void OnYAxisValueChange(float v)
    {
        yVolume = v;
    }

    public void OnApplySetting()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_CLICK);

            if (bgmVolume != AudioManager.Instance.AttachBGMSource.volume)
            {
                AudioManager.Instance.ChangeBGMVolume(bgmVolume);
            }

            if (effectVolume != AudioManager.Instance.AttachSESource.volume)
            {
                AudioManager.Instance.ChangeSEVolume(effectVolume);
            }
        }
        this.Hide();
    }

    public void OnClosingGameSetting()
    {
        this.Hide();
    }

}
