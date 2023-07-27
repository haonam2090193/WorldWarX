using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isActive = false;
    public bool IsActive => isActive;

    public void Deactive()
    {
        isActive = false;
        this.gameObject.SetActive(false);
    }
    public void Active()
    {
        isActive = true;
        this.gameObject.SetActive(true);
    }
}
