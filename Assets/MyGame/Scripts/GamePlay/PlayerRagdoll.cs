using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRagdoll : MonoBehaviour
{
    private Animator animator;
    private Rigidbody[] rigidBodies;
    private CharacterController characterController;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        characterController = GetComponent<CharacterController>();

         DeactiveRagdoll();
    }

    public void DeactiveRagdoll()
    {
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.isKinematic = true;
        }

        animator.enabled = true;
        characterController.enabled = true;

    }

    public void ActiveRagdoll()
    {
        
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.isKinematic = false;
        }
        characterController.enabled = false;
        animator.enabled = false;
        if (PlayerManager.HasInstance)
        {
            PlayerManager.Instance.characterAiming.enabled = false;
            PlayerManager.Instance.activeWeapon.enabled = false;
        }
    }
    public void ApplyForce(Vector3 force, Rigidbody rigidbody)
    {
        rigidbody.AddForce(force, ForceMode.VelocityChange);
    }
}
