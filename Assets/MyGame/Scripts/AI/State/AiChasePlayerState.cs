using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerState : AiState
{
    private float timer = 0f;
    private float maxDistance;
    private float maxTime;
    private AiAgent aiAgent;

    public AiStateID GetID()
    {
        return AiStateID.ChasePlayer;
    }

    public void Enter(AiAgent agent)
    {
        aiAgent = agent;

        Debug.Log("ChasePlayer");
        this.aiAgent = agent;
        if (DataManager.HasInstance)
        {
            maxDistance = DataManager.Instance.GlobalConfig.maxDistance;
            maxTime = DataManager.Instance.GlobalConfig.maxTime;
        }
    }

    public void Update()
    {
        if (!aiAgent.navMeshAgent.enabled)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (!aiAgent.navMeshAgent.hasPath)
        {
            aiAgent.navMeshAgent.destination = aiAgent.playerTransform.position;
        }

        if (timer < 0f)
        {
            Vector3 direction = aiAgent.playerTransform.position - aiAgent.navMeshAgent.destination;
            direction.y = 0;
            if (direction.sqrMagnitude > maxDistance * maxDistance)
            {
                if (aiAgent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    aiAgent.navMeshAgent.destination = aiAgent.playerTransform.position;
                }
            }
            timer = maxTime;
        }
        if (aiAgent.health.distance <= 2f)
        {
            aiAgent.stateMachine.ChangeState(AiStateID.Attack);
        }
       /* else
        {
            agent.stateMachine.ChangeState(AiStateID.ChasePlayer);
        }*/
    }
    public void Exit()
    {
        
    }
}
