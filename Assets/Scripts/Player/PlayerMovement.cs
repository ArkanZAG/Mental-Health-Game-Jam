using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int playerMovementSpeed;
    [SerializeField] private Rigidbody playerRigidBody;

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRigidBody.velocity = new Vector3(horizontalInput * playerMovementSpeed, 0, verticalInput * playerMovementSpeed);
    }

    private void Update()
    {
        Movement();
    }
}
