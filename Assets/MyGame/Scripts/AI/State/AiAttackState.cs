using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackState : AiState
{
    AiAgent aiAgent;
   
    public AiStateID GetID()
    {
        return AiStateID.Attack;
    }
    public void Enter(AiAgent agent)
    {
        aiAgent = agent;
    }
    public void Update()
    {
        if (PlayerManager.HasInstance)
        {
            if(PlayerManager.Instance.playerHeath.currentHealth <= 0)
            {
                aiAgent.stateMachine.ChangeState(AiStateID.Idle);
                return;
            }
        }
        aiAgent.transform.LookAt(new Vector3( aiAgent.playerTransform.position.x , aiAgent.transform.position.y, aiAgent.playerTransform.position.z));
        aiAgent.animator.SetBool("IsAttack", true);

       if (aiAgent.health.distance > 2)
        {
            aiAgent.health.canAttack = false;
            aiAgent.stateMachine.ChangeState(AiStateID.ChasePlayer);
            aiAgent.animator.SetBool("IsAttack", false);
        }
    }
    
    public void Exit()
    {
        
    }
}
