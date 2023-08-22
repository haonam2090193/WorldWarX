using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHealth : MonoBehaviour
{
    [Header("AI")]
    public float maxHealth;
    private float blinkDuration;
    public float currentHealth;
    public float distance;
    public Animator animator;

    private AiHealth health;
    private AiAgent agent;
    private Ragdoll ragdoll;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private AiAgent aiAgent;
    private float timeDestroyAI;

    public bool canAttack = false;
    
    [Header("Player")]
    public PlayerHeath playerHeath;


    void Start()
    {
        if (DataManager.HasInstance)
        {
            maxHealth = DataManager.Instance.GlobalConfig.maxHealth;
            blinkDuration = DataManager.Instance.GlobalConfig.blinkDuration;
            timeDestroyAI = DataManager.Instance.GlobalConfig.timeDestroyAI;
        }
        currentHealth = maxHealth;

        if(playerHeath == null)
        {
            Debug.Log("x");
            playerHeath = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHeath>();
        }

        agent = GetComponentInParent<AiAgent>();
        animator = GetComponentInParent<Animator>();
        ragdoll = GetComponent<Ragdoll>();
        aiAgent = GetComponent<AiAgent>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        SetUp();
    }
    private void Update()
    {
        distance = Vector3.Distance(agent.transform.position, agent.playerTransform.position);  
    }

    public void TakeDamage(float amount, Vector3 direction, Rigidbody rigidbody)
    {
        currentHealth -= amount;     
        if (currentHealth <= 0f)
        {   
            Die(direction, rigidbody);
        }
        StartCoroutine(EnemyFlash());
    }

    private void SetUp()
    {
        var rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in rigidBodies)
        {
            HitBox hitBox = rigidbody.gameObject.AddComponent<HitBox>();
            hitBox.health = this;
            hitBox.rb = rigidbody;
        }
    }

    private IEnumerator EnemyFlash()
    {
        skinnedMeshRenderer.material.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(blinkDuration);
        skinnedMeshRenderer.material.DisableKeyword("_EMISSION");
        StopCoroutine(nameof(EnemyFlash));
    }

    private void Die(Vector3 direction , Rigidbody rigidbody)
    {
        AiDeathState deathState = aiAgent.stateMachine.GetState(AiStateID.Death) as AiDeathState;
        deathState.direction = direction;
        deathState.rigidbody = rigidbody;
        aiAgent.stateMachine.ChangeState(AiStateID.Death);
    }

    public void DestroyWhenDeath()
    {
        Destroy(this.gameObject, timeDestroyAI);
    }
    public void DealDamage()
    {
        Debug.Log("Total Player Health"+playerHeath.currentHealth);
        Debug.Log("Enemy Deal Damage"+DataManager.Instance.GlobalConfig.damage);
        playerHeath.currentHealth -= DataManager.Instance.GlobalConfig.damage;
    }
}
