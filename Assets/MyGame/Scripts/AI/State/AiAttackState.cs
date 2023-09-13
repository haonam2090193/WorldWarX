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
        if(aiAgent.health.currentHealth <= 0)
        {
            return;
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
