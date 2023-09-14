using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameScreen : BaseScreen
{
    [SerializeField]  TextMeshProUGUI ammoText;
    [SerializeField]  TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] Slider HPSlider;
    public int playerScore;
    private float playerValue;
    private void Start()
    {
        if (PlayerManager.HasInstance)
        {
            playerValue = PlayerManager.Instance.playerHeath.currentHealth;
            
        }
        
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Register(ListenType.UPDATE_AMMO, OnUpdateAmmo);
            ListenerManager.Instance.Register(ListenType.UPDATE_HP, OnUpdateHP);
            ListenerManager.Instance.Register(ListenType.UPDATE_SCORE, OnUpdateScore);
        }


    }

    private void Update()
    {
        playerValue /= 100;
        if (PlayerManager.HasInstance)
        {
            HPSlider.value = playerValue;
        }

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
    private void OnDestroy()
    {
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Unregister(ListenType.UPDATE_AMMO, OnUpdateAmmo);
            ListenerManager.Instance.Unregister(ListenType.UPDATE_HP, OnUpdateHP);
            ListenerManager.Instance.Unregister(ListenType.UPDATE_SCORE, OnUpdateScore);

        }
    }
    
    public void OnMenuScreenClick()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        { 
       
            UIManager.Instance.ShowPopup<InGameMenu>();
            GameManager.Instance.PauseGame();
        }
    }

    private void OnUpdateAmmo(object value)
    {
        if (value is int ammo)
        {
            ammoText.text = ammo.ToString();
        }
    }

    private void OnUpdateHP(object value)
    {
        if (value is int hp)
        {
            hpText.text = hp.ToString();
        }
    }

    private void OnUpdateScore(object value)
    {
        if(value is int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
