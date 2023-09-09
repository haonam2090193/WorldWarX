using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListButtonPanel : BasePopup
{
    public Animator soundSettingButton;
    public Animator mouseSettingButton;
    public CanvasGroup SECanvasGroup;
    public CanvasGroup MouseCanvasGroup;


    private void Start()
    {
        StartCoroutine(PlaySoundSetting());
    }
    public override void Show(object data)
    {
        base.Show(data);
    }

    public override void Hide()
    {
        base.Hide();
    }

    public bool CheckPressedButton(Animator animator)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Hightlight To Pressed"))
        {
            return true;
        }

        return false;
    }

    private IEnumerator PlaySoundSetting()
    {
        soundSettingButton.Play("Hightlight To Pressed");
            MouseCanvasGroup.alpha = 0;
            MouseCanvasGroup.interactable = false;
            MouseCanvasGroup.blocksRaycasts = false;

            SECanvasGroup.alpha = 1;
            SECanvasGroup.interactable = true;
            SECanvasGroup.blocksRaycasts = true;
        

        yield return new WaitForSeconds(0.1f); 
    }

    public void SoundSettingPressed()
    {
        if (!CheckPressedButton(soundSettingButton))
        {
            soundSettingButton.Play("Hightlight To Pressed");
            mouseSettingButton.Play("Pressed To Normal");
        }
        MouseCanvasGroup.alpha = 0;
        MouseCanvasGroup.interactable = false;
        MouseCanvasGroup.blocksRaycasts = false;

        SECanvasGroup.alpha = 1;
        SECanvasGroup.interactable = true;
        SECanvasGroup.blocksRaycasts = true;
    }
   
    public void MouseSettingPressed()
    {
        if (!CheckPressedButton(mouseSettingButton))
        {
            mouseSettingButton.Play("Hightlight To Pressed");
            soundSettingButton.Play("Pressed To Normal");
        }
        SECanvasGroup.alpha = 0;
        SECanvasGroup.interactable = false;
        SECanvasGroup.blocksRaycasts = false;

        MouseCanvasGroup.alpha = 1;
        MouseCanvasGroup.interactable = true;
        MouseCanvasGroup.blocksRaycasts = true;
    }
}
