using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingPanel : BaseUIElement
{
    [Header("LOADING PANEL")]
    [SerializeField] private GameObject completeGameobject;
    [SerializeField] private TMP_Text loadingText;
    [SerializeField] private Slider loadingSlider;

   /* protected override void LoadComponent()
    {
        base.LoadComponent();
        if (this.completeGameobject == null)
            this.completeGameobject = transform.Find("Complete_Text").gameObject;

        if (this.loadingText == null)
            this.loadingText = transform.Find("Container/Loading_Text").GetComponent<TMP_Text>();

        if (this.loadingSlider == null)
            this.loadingSlider = GetComponentInChildren<Slider>();
    }*/

    public override void Show(object data)
    {
        base.Show(data);
        this.completeGameobject.SetActive(false);
    }

    public override void Hide()
    {
        base.Hide();
        this.completeGameobject.SetActive(false);
    }

    public IEnumerator LoadScene(int sceneIndex)
    {
        this.loadingSlider.value = 0;
        this.loadingText.SetText("0%");

        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            float percent = asyncOperation.progress;
            this.loadingSlider.value = (int)(percent * this.loadingSlider.maxValue);
            this.loadingText.SetText($"{(int)(percent * 100)}%");

            if (percent >= 0.9f) //0 - 0.9: load scene //0.9 - 1: chuyen scene
            {
                this.loadingSlider.value = this.loadingSlider.maxValue;
                this.loadingText.SetText("100%");
                this.completeGameobject.SetActive(true);
                if (Input.anyKeyDown)
                {
                    asyncOperation.allowSceneActivation = true;           
                }
            }
            yield return null;

        }
    }
}
