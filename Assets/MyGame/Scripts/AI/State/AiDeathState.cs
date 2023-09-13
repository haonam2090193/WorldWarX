using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDeathState : AiState
{
    private float dieForce;
    public Vector3 direction;
    public Rigidbody rigidbody;
    AiAgent aiAgent;
    public AiStateID GetID()
    {
        return AiStateID.Death;
    }
    public void Update()
    {

    }

    public void Enter(AiAgent agent)
    {
        aiAgent = agent;

        Debug.Log("DeathState");

        if (DataManager.HasInstance)
        {
            dieForce = DataManager.Instance.GlobalConfig.dieForce;
        }
        aiAgent.ragdoll.ActiveRagdoll();
        direction.y = 1f;
        aiAgent.ragdoll.ApplyForce(direction * dieForce, rigidbody);
        aiAgent.health.DestroyWhenDeath();
    }

    public void Exit()
    {
        
    }

}
