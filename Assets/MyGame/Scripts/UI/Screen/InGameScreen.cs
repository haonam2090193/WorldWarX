using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InGameScreen : BaseScreen
{
    private void Update()
    {
        OnSettingClick();
    }
    public override void Hide()
    {
        base.Hide();
    }
    public override void Init()
    {
        base.Init();
    }
    public override void Show(object data)
    {
        base.Show(data);
    }
    
    public void OnSettingClick()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        { 
            UIManager.Instance.ShowPopup<PopupSetting>();

        }
    }
}
