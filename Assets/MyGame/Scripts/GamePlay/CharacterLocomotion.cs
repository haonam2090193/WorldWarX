 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    public Animator rigController;
    private float jumpHeight;
    private float gravity;
    private float stepDown;
    private float airControl;
    private float jumpDamp;
    private float groundSpeed;
    private float pushPower;

    private Animator animator;
    private CharacterController characterController;
    private Vector2 userInput;
    private Vector3 rootMotion;
    private Vector3 velocity;
    [HideInInspector]
    public bool isJumping;

    private ActiveWeapon activeWeapon;
    private WeaponReload weaponReload;
    private CharacterAiming characterAiming;

    private int isSprintingParam = Animator.StringToHash("IsSprinting");

    void Start()
    {
        animator = GetComponent<Animator>();

        if (PlayerManager.HasInstance)
        {
            activeWeapon = PlayerManager.Instance.activeWeapon;
            weaponReload = PlayerManager.Instance.weaponReload;
            characterAiming = PlayerManager.Instance.characterAiming;

        }
        characterController = GetComponent<CharacterController>();
        if (DataManager.HasInstance)
        {
            jumpHeight = DataManager.Instance.GlobalConfig.jumpHeight;
            gravity = DataManager.Instance.GlobalConfig.gravity;
            stepDown = DataManager.Instance.GlobalConfig.stepDown;
            airControl = DataManager.Instance.GlobalConfig.airControl;
            jumpDamp = DataManager.Instance.GlobalConfig.jumpDamp;
            groundSpeed = DataManager.Instance.GlobalConfig.groundSpeed;
            pushPower = DataManager.Instance.GlobalConfig.pushPower;
        }
    }

    void Update()
    {
        this.userInput.x = Input.GetAxis("Horizontal");
        this.userInput.y = Input.GetAxis("Vertical");

        this.animator.SetFloat("InputX", this.userInput.x);
        this.animator.SetFloat("InputY", this.userInput.y);

        UpdateIsSprinting();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            UpdateInAir();
        }
        else
        {
            UpdateOnGround();
        }
    }

    private bool IsSprinting()
    {
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        bool isFiring = this.activeWeapon.IsFiring();
        bool isReloading = this.weaponReload.isReloading;
        bool isChangingWeapon = this.activeWeapon.isChangingWeapon;
        bool isAiming = this.characterAiming.isAiming;

        return isSprinting && !isFiring && !isReloading && !isChangingWeapon && !isAiming;
    }

    private void UpdateIsSprinting()
    {
        bool isSprinting = IsSprinting();
        this.animator.SetBool(isSprintingParam, isSprinting);
        this.rigController.SetBool(isSprintingParam, isSprinting);
    }

    private void UpdateOnGround()
    {
            Vector3 stepForwardAmount = rootMotion * groundSpeed;
            Vector3 stepDownAmount = Vector3.down * stepDown;
            this.characterController.Move(stepForwardAmount + stepDownAmount);
            rootMotion = Vector3.zero;
        if (!this.characterController.isGrounded)
        {
            SetInAir(0);
        }
    }

    private void UpdateInAir()
    {
        this.velocity.y -= gravity * Time.fixedDeltaTime;
        Vector3 airDisplacement = velocity * Time.fixedDeltaTime;
        airDisplacement += CalculateAircontrol();
        this.characterController.Move(airDisplacement);
        isJumping = !this.characterController.isGrounded;
        rootMotion = Vector3.zero;
        this.animator.SetBool("IsJumping", isJumping);
    }

    private void OnAnimatorMove()
    {
        rootMotion += this.animator.deltaPosition;
    }
     
    private void Jump()
    {
        if (!isJumping)
        {
            float jumpVelocity = Mathf.Sqrt(2 * gravity * jumpHeight);
            SetInAir(jumpVelocity);
        }
    }

    private void SetInAir(float jumpVelocity)
    {
        isJumping = true;
        velocity = this.animator.velocity * jumpDamp * groundSpeed;
        this.velocity.y = jumpVelocity;
        this.animator.SetBool("IsJumping", true);
    }

    private Vector3 CalculateAircontrol()
    {
        return ((this.transform.forward * this.userInput.y) + (this.transform.right * this.userInput.x)) * (airControl / 100);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
            return;

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3f)
            return;

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
    }
}
