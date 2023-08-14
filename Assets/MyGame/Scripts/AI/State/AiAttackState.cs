using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackState : AiState
{
    private float damage;
    private AiAttack aiAttack;
    public AiStateID GetID()
    {
        return AiStateID.Attack;
    }

    public void Enter(AiAgent agent)
    {
        Debug.Log("Attack");

        damage = DataManager.Instance.GlobalConfig.damage;
    }
    public void Update(AiAgent agent)
    {
        agent.transform.LookAt(agent.playerTransform);
        Debug.Log(aiAttack.distance);
       /* if ( <= 2)
        {
            aiAttack.animator.SetBool("IsAttack", true);
            aiAttack.DealDamage(10);
        }
        else if(distance > 2)
        {
            agent.stateMachine.ChangeState(AiStateID.ChasePlayer);
        }*/
    }
    public void Exit(AiAgent agent)
    {
        
    }
}
