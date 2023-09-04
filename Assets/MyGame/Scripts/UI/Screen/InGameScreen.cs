using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InGameScreen : BaseScreen
{
    private void Update()
    {
        OnMenuScreenClick();
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
    
    public void OnMenuScreenClick()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        { 
            
            UIManager.Instance.ShowPopup<InGameMenu>();
            GameManager.Instance.PauseGame();
        }
    }

}
