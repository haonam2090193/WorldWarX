using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowNotify<LoadingMap2>();
        }
        //Cách để chọn lại vị trí khi chuyển qua scene mới

         
    }
}
