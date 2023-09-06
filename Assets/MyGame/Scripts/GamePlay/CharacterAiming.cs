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
    public Animator rigController;

    private ActiveWeapon activeWeapon;
    private void Awake()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
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
        if (PlayerManager.HasInstance)
        {
            this.activeWeapon = PlayerManager.Instance.activeWeapon;
        }
    }

    private void Update()
    {
        var weapon = activeWeapon.GetActiveWeapon();

        if (weapon)
        {
            //Debug.Log(isAiming);
            weapon.weaponRecoil.recoilModifier = isAiming ? aimRecoil : defaultRecoil;
            isAiming = (Input.GetMouseButton(1) && !PlayerManager.Instance.weaponReload.isReloading && !this.activeWeapon.isHolstered);

            if (isAiming)
            {
                // rigController.SetBool("weapon_aim", true);
                rigController.Play("weapon_aim_" + weapon.weaponName);
                xAxis.m_MaxSpeed = 100;
                yAxis.m_MaxSpeed = 100;
                animator.SetBool("IsAiming", true);
            }
            else
            {
                animator.SetBool("IsAiming", false);
                rigController.Play("notAiming");
                xAxis.m_MaxSpeed = 300;
                yAxis.m_MaxSpeed = 300;
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
