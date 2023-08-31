using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseManager<GameManager>
{
    private void Start()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowNotify<NotifyLoading>();
            NotifyLoading scr = UIManager.Instance.GetExistNotify<NotifyLoading>();
            if (scr != null)
            {
                scr.AnimationLoaddingText();
                scr.DoAnimationLoadingProgress(5, () =>
                {
                    UIManager.Instance.ShowScreen<ScreenHome>();
                    scr.Hide();
                });
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CloseGame()
    {
        EditorApplication.ExitPlaymode();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.visible = true;

    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
}
