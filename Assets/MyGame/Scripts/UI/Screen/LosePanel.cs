using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : BasePopup
{
    public override void Hide()
    {
        base.Hide();
    }
    public override void Init()
    {
        base.Init();
    }
    private void Start()
    {
        if (UIManager.HasInstance)
        {
             InGameScreen inGameScreen =   UIManager.Instance.GetComponent<InGameScreen>();
            inGameScreen.Hide();

        }
        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.Confined;
    }
    public void OnExitGame()
    {
        if (GameManager.HasInstance)
        {
            GameManager.Instance.CloseGame();
        }
    }
}
