using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("map2");
        SceneManager.LoadScene("Map2");
        //Cách để chọn lại vị trí khi chuyển qua scene mới
    }
}
