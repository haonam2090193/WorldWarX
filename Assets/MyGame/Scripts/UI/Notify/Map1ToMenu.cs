using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Map1ToMenu : BaseNotify
{
    public TextMeshProUGUI loadingPercentText;
    public Slider loadingSlider;
    private GameObject[] enemies;
    public override void Init()
    {
        base.Init();
        StartCoroutine(LoadScene());
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        GameObject player = GameObject.Find("Player");
        Destroy(player);
        if (GameManager.HasInstance)
        {
            GameManager.Instance.ContinueGame();
        }
        
    }

    public override void Show(object data)
    {
        base.Show(data);
    }

    public override void Hide()
    {
        base.Hide();
    }

    private IEnumerator LoadScene()
    {      
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Menu");

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
                    UIManager.Instance.ShowOverlap<OverlapFade2>();
                    GameObject overlapFade = GameObject.Find("OVERLAP_OverlapFade");
                    Destroy(overlapFade);
                }
                yield return new WaitForSeconds(3f);
                asyncOperation.allowSceneActivation = true;
                UIManager.Instance.HideAllScreens();
                UIManager.Instance.HideAllPopups();
                UIManager.Instance.ShowScreen<ScreenHome>();
                this.Hide();
            }

            yield return null;
             }
        }
 

}
