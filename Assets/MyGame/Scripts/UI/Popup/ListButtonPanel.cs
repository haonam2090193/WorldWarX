using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListButtonPanel : BasePopup
{
    public Animator soundSettingButton;
    public Animator mouseSettingButton;

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

        // Kiểm tra xem animator đang ở trạng thái "Hightlight To Pressed"
        if (stateInfo.IsName("Hightlight To Pressed"))
        {
            return true;
        }

        return false;
    }

    public void SoundSettingPressed()
    {
        if (!CheckPressedButton(soundSettingButton))
        {
            soundSettingButton.Play("Hightlight To Pressed");
            mouseSettingButton.Play("Pressed To Normal");
        }
      /*  if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowPopup<ConfigSettingPanel>().
        }*/

    }

    public void MouseSettingPressed()
    {
        if (!CheckPressedButton(mouseSettingButton))
        {
            mouseSettingButton.Play("Hightlight To Pressed");
            soundSettingButton.Play("Pressed To Normal");
        }
    }
}
