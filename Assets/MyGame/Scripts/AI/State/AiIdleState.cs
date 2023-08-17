using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiIdleState : AiState
{

    public Vector3 playerDirection;
    private float maxSightDistance;
    AiAgent aiAgent;
    public AiStateID GetID()
    {
        return AiStateID.Idle;
    }

    public void Enter(AiAgent agent)
    {
        Debug.Log("Idle");
        aiAgent = agent;
        if (DataManager.HasInstance)
        {
            maxSightDistance = DataManager.Instance.GlobalConfig.maxSight;
        }
    }

    public void Exit()  
    {
    
    }

    public void Update()
    {
        playerDirection = aiAgent.playerTransform.position - aiAgent.transform.position;

        if(aiAgent.health.currentHealth < aiAgent.health.maxHealth)
        {
            aiAgent.stateMachine.ChangeState(AiStateID.ChasePlayer);
        }
        if (playerDirection.magnitude > maxSightDistance)
        {
            return;
        }

        Vector3 agentDirection = aiAgent.transform.forward;

        playerDirection.Normalize();

        float dotProduct = Vector3.Dot(playerDirection, agentDirection);

        if(dotProduct >= 0) //co nghia la nhan vat da bi phat hien
        {
            aiAgent.stateMachine.ChangeState(AiStateID.ChasePlayer);
        }
    }
}
