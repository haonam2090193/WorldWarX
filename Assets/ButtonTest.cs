using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{

    public void CloseSettingButton()
    {
        GameObject.Find("SettingPanel").SetActive(false);
    }
    public void OpenSettingButton()
    {
        GameObject.Find("SettingPanel").SetActive(true);
    }
}
