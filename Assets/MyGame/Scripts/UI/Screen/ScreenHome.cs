using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScreenHome : BaseScreen
{
    public override void Show(object data)
    {
        base.Show(data);
    }
    
    public override void Hide()
    {
        base.Hide();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Map1");
        this.Hide();
        Debug.Log("Loaded");
    }
    
    public void OnClickPopupSetting()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowPopup<PopupSetting>();
        }
    }
        
}
