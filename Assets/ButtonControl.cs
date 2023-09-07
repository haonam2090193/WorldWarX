using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Button soundButton;
    public Button mouseButton;

    public Animator soundButtonAnimator;
    public Animator mouseButtonAnimator;

    bool IsSelectedAnimationPlaying(Animator animator)
    {
        if (animator != null)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName("Selected"))
            {
                return true; 
            }
        }   
    return false; 
    }

    private void Update()
    {
        if (IsSelectedAnimationPlaying(soundButtonAnimator))
        {
            Debug.Log("sound button");
            soundButton.interactable = false;
            mouseButton.interactable = true; // Khi soundButton được chọn, bật tương tác cho mouseButton
        }
        else if (IsSelectedAnimationPlaying(mouseButtonAnimator))
        {
            Debug.Log("mouse button");
            soundButton.interactable = true;
            mouseButton.interactable = false; // Khi mouseButton được chọn, bật tương tác cho soundButton
        }
        else
        {
            // Nếu cả hai Animator đều không phát "Selected", bật tương tác cho cả hai Button
            soundButton.interactable = true;
            mouseButton.interactable = true;
        }
    }
}
