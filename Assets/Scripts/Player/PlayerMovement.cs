using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int playerMovementSpeed;
    [SerializeField] private Rigidbody playerRigidBody;
    
    [SerializeField] private Animator anim;

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRigidBody.velocity = new Vector3(horizontalInput * playerMovementSpeed, verticalInput * playerMovementSpeed, 0);

        if (horizontalInput >= 0.1f)
        {
            transform.localScale = Vector3.one;
        }else if (horizontalInput <= -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
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
