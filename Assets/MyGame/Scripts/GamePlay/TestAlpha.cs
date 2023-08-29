using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAlpha : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("1");
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log("2");
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("3");
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            Debug.Log("4");
        }
    }
}
