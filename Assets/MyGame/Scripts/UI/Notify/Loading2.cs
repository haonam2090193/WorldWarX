using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading2 : MonoBehaviour
{
    public Transform playerTransform;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("map2");
        SceneManager.LoadScene("Map2");
        //Cách để chọn lại vị trí khi chuyển qua scene mới

           playerTransform.position = new Vector3(243.22f, 1, 1.32f);
    }
}
