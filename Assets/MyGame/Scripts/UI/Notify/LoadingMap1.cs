using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadingMap1 : BaseNotify
{
    public TextMeshProUGUI loadingPercentText;
    public Slider loadingSlider;

    
    public override void Init()
    {
        base.Init();
        LoadScenes();
    }
    
    public override void Show(object data)
    {
        base.Show(data);
    }

    public override void Hide()
    {
        base.Hide();
    }

    public void LoadScenes()
    {
        StartCoroutine(LoadScene("Map1"));
    }

    private IEnumerator LoadScene(string screneName)
    {
        Debug.Log("AAAAA");
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(screneName);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            loadingSlider.value = asyncOperation.progress;
            loadingPercentText.SetText($"LOADING SCENES: {asyncOperation.progress * 100}%");
            if (asyncOperation.progress >= 0.9f)
            {
                loadingSlider.value = 1f;
                loadingPercentText.SetText($"LOADING SCENES: {loadingSlider.value * 100}%");
                if (UIManager.HasInstance)
                {
                    UIManager.Instance.ShowOverlap<OverlapFade>();
                }
                yield return new WaitForSeconds(3f);
                asyncOperation.allowSceneActivation = true;

                this.Hide();
            }
          
            yield return null;
        }
    }    
}
    
