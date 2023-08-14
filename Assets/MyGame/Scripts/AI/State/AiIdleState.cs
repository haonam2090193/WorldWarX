using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiIdleState : AiState
{

    public Vector3 playerDirection;
    private float maxSightDistance;
    AiAttack aiAttack;
    public AiStateID GetID()
    {
        return AiStateID.Idle;
    }

    public void Enter(AiAgent agent)
    {
        Debug.Log("Idle");

        if (DataManager.HasInstance)
        {
            maxSightDistance = DataManager.Instance.GlobalConfig.maxSight;
        }
    }

    public void Exit(AiAgent agent)  
    {
    
    }

    public void Update(AiAgent agent)
    {

        playerDirection = agent.playerTransform.position - agent.transform.position;
        if(playerDirection.magnitude > maxSightDistance)
        {
            return;
        }

        Vector3 agentDirection = agent.transform.forward;

        playerDirection.Normalize();

        float dotProduct = Vector3.Dot(playerDirection, agentDirection);

        if(dotProduct >= 0) //co nghia la nhan vat da bi phat hien
        {
            agent.stateMachine.ChangeState(AiStateID.ChasePlayer);
        }
    }
}
