using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        Debug.Log(transform.position);
        transform.position = new Vector3(30, 30, 30);
        Debug.Log(transform.position);
        player.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
