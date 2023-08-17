using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttack : MonoBehaviour
{
    public Animator animator;
    public float distance;
    private AiHealth health;
    private AiAgent agent;
    private void Awake()
    {
        agent = GetComponent<AiAgent>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
       distance = Vector3.Distance(this.transform.position, agent.playerTransform.position);
      //  DealDamage();
    }
    public void DealDamage(float amount)
    {
       /* if (distance <= 2f)
        {
            animator.SetBool("IsAttack", true);
            agent.stateMachine.ChangeState(AiStateID.ChasePlayer);
        }
        else animator.SetBool("IsAttack", false);*/
    }
}