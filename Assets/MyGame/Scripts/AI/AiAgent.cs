using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    public Transform playerTransform;
    public AiStateID initState;

    [HideInInspector]
    public NavMeshAgent navMeshAgent;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public Ragdoll ragdoll;
    [HideInInspector]
    public AiStateMachine stateMachine;
    [HideInInspector]
    public AiHealth health;
    
    [HideInInspector]
    public HitBox hitBox;

    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<AiHealth>();
        ragdoll = GetComponent<Ragdoll>();
        animator = GetComponent<Animator>();
        hitBox = GetComponent<HitBox>();
        stateMachine = new AiStateMachine(this);

        stateMachine.RegisterState(new AiChasePlayerState());
        stateMachine.RegisterState(new AiDeathState());
        stateMachine.RegisterState(new AiIdleState());
        stateMachine.RegisterState(new AiAttackState());
        stateMachine.ChangeState(initState);
    }
    void Update()
    {
        stateMachine.Update();
    }
}
