using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackState : AiState
{
    private float attackDamage;

    public AiStateID GetID()
    {
        return AiStateID.Attack;
    }

    public void Enter(AiAgent agent)
    {

    }
    public void Update(AiAgent agent)
    {
        agent.transform.LookAt(agent.playerTransform.position);
    }
    public void Exit(AiAgent agent)
    {
    
    }
}
