using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Animator buttonAnimator;
    private bool isHighlighted = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isHighlighted)
            buttonAnimator.Play("Normal To Hightlight");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isHighlighted)
            buttonAnimator.Play("Hightlight To Normal");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isHighlighted)
        {
            buttonAnimator.Play("Pressed To Normal");
            isHighlighted = false;
        }
        else
        {
            buttonAnimator.Play("Hightlight To Pressed");
            isHighlighted = true;
        }
    }
}
