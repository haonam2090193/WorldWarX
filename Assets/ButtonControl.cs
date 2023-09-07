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

    void Update()
    {
        // Kiểm tra và thực hiện hành động nếu animation "Selected" đang phát cho Button 1
        if (IsSelectedAnimationPlaying(soundButtonAnimator))
        {
            // Đã phát animation "Selected" cho Button 1, thực hiện hành động của bạn ở đây
            Debug.Log("Animation 'Selected' is playing for Button 1.");
        }

        // Kiểm tra và thực hiện hành động nếu animation "Selected" đang phát cho Button 2
        if (IsSelectedAnimationPlaying(mouseButtonAnimator))
        {
            // Đã phát animation "Selected" cho Button 2, thực hiện hành động của bạn ở đây
            Debug.Log("Animation 'Selected' is playing for Button 2.");
        }
    }
}
