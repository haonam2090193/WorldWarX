using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TestAnimation : MonoBehaviour
{
    private CharacterController characterController;
    float moveSpeed;
    float inputX, inputY;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        inputX = Input.GetAxis("Vertical");
        inputY = Input.GetAxis("Horizontal");

        animator.SetFloat("InputX", inputX);
        animator.SetFloat("InputY", inputY);

        Vector3 moveDiration = transform.forward * inputX + transform.right * inputY;
        characterController.Move(moveDiration * moveSpeed * Time.deltaTime);
    }
}
