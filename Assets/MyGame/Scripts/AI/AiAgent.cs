using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    public AiStateMachine stateMachine;
    public AiStateID initState;
    public NavMeshAgent navMeshAgent;
    public Ragdoll ragdoll;
    public AiHealth health;
    public Transform playerTransform;

    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<AiHealth>();
        ragdoll = GetComponent<Ragdoll>();
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
