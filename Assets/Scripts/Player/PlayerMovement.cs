using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int playerMovementSpeed;
    [SerializeField] private Rigidbody playerRigidBody;
    [FormerlySerializedAs("defaultScale")] [SerializeField] private Vector3 originalScale;
    
    [SerializeField] private Animator anim;

    

    private void Start()
    {
        originalScale = this.transform.localScale;
    }
    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRigidBody.velocity = new Vector3(horizontalInput * playerMovementSpeed, verticalInput * playerMovementSpeed, 0);

        if (horizontalInput >= 0.1f)
        {
            var playerScaleRight = originalScale;
            playerScaleRight.x *= 1;
            transform.localScale = playerScaleRight;
        }else if (horizontalInput <= -0.1f)
        {
            var playerScaleLeft = originalScale;
            playerScaleLeft.x *= -1;
            transform.localScale = playerScaleLeft;
        }
        
        if (verticalInput != 0 || horizontalInput != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        
        
    }
    private void Update()
    {
        Movement();
    }
}
