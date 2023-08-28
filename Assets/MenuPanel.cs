using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuPanel : BaseScreen
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
        SceneManager.LoadSceneAsync("Map1");
        //this.Hide();
    }
}
