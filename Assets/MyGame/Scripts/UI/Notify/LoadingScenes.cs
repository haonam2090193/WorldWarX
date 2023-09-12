using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScenes : BaseNotify
{
    public GameObject loadingScreen;
    public Image loadingSlider;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync(2));

    }
    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }
    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneId);

        loadingScreen.SetActive(true);

        while (!asyncOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(asyncOperation.progress / 0.9f);

            loadingSlider.fillAmount = progressValue;
            yield return null;
        }
    }
}
