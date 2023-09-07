using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading2 : MonoBehaviour
{
    public GameObject player;
    public GameObject tele;
    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = tele.transform.position;
        Debug.Log("map2");

        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowNotify<LoadingMap2>();
        }
        //Cách để chọn lại vị trí khi chuyển qua scene mới

         
    }
}
