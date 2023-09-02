using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WeaponRecoil : MonoBehaviour
{

    [HideInInspector]
    public CinemachineImpulseSource cameraShake;
    [HideInInspector]
    public Animator rigController;
    [HideInInspector]
    public float recoilModifier = 1f;

    public Vector2[] recoilPattern;
    public float duration;

    private float time;
    private int index;
    private float verticalRecoil;
    private float horizontalRecoil;

    public CharacterAiming characterAiming;
    private void Awake()
    {
        cameraShake = GetComponent<CinemachineImpulseSource>();
    }
    private void Start()
    {
        if (PlayerManager.HasInstance)
        {
            this.characterAiming = PlayerManager.Instance.characterAiming;

        }
    }
    public void Reset()
    {
        index = 0;
    }

    public void GenerateRecoil(string weaponName)
    {
        time = duration;

        cameraShake.GenerateImpulse(Camera.main.transform.forward);

        horizontalRecoil = recoilPattern[index].x;
        verticalRecoil = recoilPattern[index].y;

        index = NextIndex(index);

        rigController.Play("weapon_recoil_" + weaponName, 1, 0f);
    }

    private int NextIndex(int index)
    {
        return (index + 1) % recoilPattern.Length;
    }

    private void Update()
    {
        if (time > 0)
        {
            this.characterAiming.yAxis.Value -= (((verticalRecoil / 10) * Time.deltaTime) / duration * recoilModifier);
            this.characterAiming.xAxis.Value -= (((horizontalRecoil / 10) * Time.deltaTime) / duration * recoilModifier);
            time -= Time.deltaTime;
        }
    }
}
