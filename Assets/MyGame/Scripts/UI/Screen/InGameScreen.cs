using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameScreen : BaseScreen
{
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] Slider HPSlider;

    private float playerValue ;
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
    
    public void OnMenuScreenClick()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        { 
            
            UIManager.Instance.ShowPopup<InGameMenu>();
            GameManager.Instance.PauseGame();
        }
    }



    private void OnDestroy()
    {
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Unregister(ListenType.UPDATE_AMMO, OnUpdateAmmo);
            ListenerManager.Instance.Unregister(ListenType.UPDATE_HP, OnUpdateHP);

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


}
