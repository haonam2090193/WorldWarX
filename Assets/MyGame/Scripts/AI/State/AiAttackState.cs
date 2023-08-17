using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackState : AiState
{
    private float damage;
    AiAgent aiAgent;
   
    public AiStateID GetID()
    {
        return AiStateID.Attack;
    }
    public void Enter(AiAgent agent)
    {
        aiAgent = agent;
        Debug.Log("Attack");
        damage = DataManager.Instance.GlobalConfig.damage;
    }
    public void Update()
    {
        aiAgent.transform.LookAt(aiAgent.playerTransform);
        aiAgent.animator.SetBool("IsAttack", true);
       if (aiAgent.aiAttack.distance > 2)
        {
            aiAgent.stateMachine.ChangeState(AiStateID.ChasePlayer);
            aiAgent.animator.SetBool("IsAttack", false);
        }
    }
    public void Exit()
    {
        
    }
}
