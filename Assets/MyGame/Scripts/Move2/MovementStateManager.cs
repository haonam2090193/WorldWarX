using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    public float speed = 3f;
    [HideInInspector]
    public Vector3 direction;
    float hzInput, verInput;
    Vector3 velocity;
    CharacterController characterController;

    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector3 spherePos;
    [SerializeField] float gravity = -9.18f;

    [HideInInspector] public Animator animator;

    MovementBaseState currentState;

    public IdleState Idle = new IdleState();
    public WalkState Walk = new WalkState();
    public CrouchState Crouch = new CrouchState();
    public RunState Run = new RunState();

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        SwitchState(Idle);
    }
    private void Update()
    {
        GetDirectionAndMove();
        Gravity();

        animator.SetFloat("Horizontal", hzInput);
        animator.SetFloat("Vertical", verInput);

        currentState.UpdateState(this);
    }
    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");
        direction = transform.forward * verInput + transform.right * hzInput;
        characterController.Move(direction.normalized * speed * Time.deltaTime);
    }
    bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, characterController.radius - 0.05f, groundLayer)) return true;
        return false;
    }
    void Gravity()
    {
        if (!IsGrounded())
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if(velocity.y < 0)
        {
            velocity.y = -2;
        }
        characterController.Move(velocity * Time.deltaTime);
    }
}
