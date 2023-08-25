using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterAiming : MonoBehaviour
{
    private float turnSpeed;
    private float defaultRecoil;
    private float aimRecoil;
    public Transform cameraLookAt;
    public AxisState xAxis;
    public AxisState yAxis;
    public bool isAiming;
    
    private Camera mainCamera;
    private Animator animator;
    private ActiveWeapon activeWeapon;
    private int isAimingParam = Animator.StringToHash("IsAiming");

    public Animator rigController;
    private void Awake()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        activeWeapon = GetComponent<ActiveWeapon>();
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (DataManager.HasInstance)
        {
            turnSpeed = DataManager.Instance.GlobalConfig.turnSpeed;
            defaultRecoil = DataManager.Instance.GlobalConfig.defaultRecoil;
            aimRecoil = DataManager.Instance.GlobalConfig.aimRecoil;

        }
    }

    private void Update()
    {
        var weapon = activeWeapon.GetActiveWeapon();
        if (weapon)
        {
            if (activeWeapon.canFire)
            { 
                isAiming = Input.GetMouseButton(1);
                animator.SetBool(isAimingParam, isAiming);  
                weapon.weaponRecoil.recoilModifier = isAiming ? aimRecoil : defaultRecoil;
                if(isAiming)
                {
                    rigController.Play("weapon_aim_" + weapon.weaponName);
                    xAxis.m_MaxSpeed = 100;
                    yAxis.m_MaxSpeed = 100;
                }
                else
                {
                    //rigController.SetBool("weapon_aim_" + weapon.weaponName); 
                    xAxis.m_MaxSpeed = 300;
                    yAxis.m_MaxSpeed = 300;
                }
            } 
        }
    }

    void FixedUpdate()
    {
        xAxis.Update(Time.fixedDeltaTime);
        yAxis.Update(Time.fixedDeltaTime);

        cameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);

        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }
}
