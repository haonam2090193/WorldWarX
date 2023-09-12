using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private Animator animator;
    private Rigidbody[] rigidBodies;
    private Collider[] ragdollColliders;
    public float gravity =-10;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        Physics.gravity = new Vector3(0f, gravity, 0f);

        Physics.IgnoreLayerCollision(gameObject.layer, 9);

        DeactiveRagdoll();
    }

    private void Update()
    {
        
    }
    public void DeactiveRagdoll()
    {
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.isKinematic = true;
        }

        animator.enabled = true;
    }

    public void ActiveRagdoll()
    {
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.isKinematic = false;
            
        }
        gameObject.layer = 9;

        animator.enabled = false;
    }
    public void ApplyForce(Vector3 force , Rigidbody rigidbody)
    {
        rigidbody.AddForce(force, ForceMode.VelocityChange);
    }
}
