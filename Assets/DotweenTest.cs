using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DotweenTest : MonoBehaviour
{
   // private DOTween doTween;
    Tweener tween;
    private void Awake()
    {
        this.transform.DORotate(new Vector3(0, 0, 45), 5f);
        this.transform.DOMove(new Vector3(75.51051f, 91.8f, 400), 10f);
    }
    private void Update()
    {
            
    }
}
