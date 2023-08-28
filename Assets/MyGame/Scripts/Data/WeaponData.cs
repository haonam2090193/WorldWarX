using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]

public class WeaponData : ScriptableObject
{
    [Header("Stats")]
    public float fireRate = 25;
    public float bulletSpeed = 1000f;
    public float bulletDrop = 0f;
    public int ammoCount;
    public int totalAmmo;
    public float damage;
    public int ammoPerShot;
    public bool singleMode;
    public float[] spreads;
}
