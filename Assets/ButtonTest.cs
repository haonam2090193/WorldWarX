using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    private CanvasGroup canvasGroups;
    private Toggle toggle;

    private void Awake()
    {
        toggle = GetComponentInChildren<Toggle>();
        canvasGroups = GetComponentInChildren<CanvasGroup>();
    }
    private void Start()
    {
        DeactivePanel();
       // DeactiveToggle();
    }
    public void ActivePanel()
    {
        Debug.Log("Active");
        canvasGroups.alpha = 1;
        canvasGroups.blocksRaycasts = true;
        canvasGroups.interactable = true;
    }
    public void DeactivePanel()
    {

        Debug.Log("Deactive");

        canvasGroups.alpha = 0;
        canvasGroups.blocksRaycasts = false;
        canvasGroups.interactable = false;
    }
    
    public void ActiveToggle()
    { 
        toggle.isOn = true;
        Debug.Log("Active Toggle");
    }
    public void DeactiveToggle()
    {
        toggle.isOn = false;
        Debug.Log("Deactive Toggle");
    } 
}
