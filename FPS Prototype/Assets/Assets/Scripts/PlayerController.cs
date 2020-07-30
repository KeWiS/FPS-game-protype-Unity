﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public variables
    public float playerSpeed = 10f;
    public float gravity = -9.81f;
    public float checkSphereRadius = 0.3f;
    public float jumpHeight = 2.5f;

    public CharacterController characterController;

    public Transform groundCheck;

    public LayerMask groundMask;
    //Private variables
    bool isGrounded;

    Vector3 gravityVelocity;

    // Update is called once per frame
    void Update ()
    {
        //Getting keyboard inputs
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");
        //Allowing player to move
        Vector3 movingDirection = transform.right * xAxis + transform.forward * zAxis;
        characterController.Move(movingDirection * playerSpeed * Time.deltaTime);
        //Allowing player to jump y = sqrt(h * -2 * g)
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            gravityVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        //Calculating gravity delta y = (1/2*g)*t^2
        gravityVelocity.y += gravity * Time.deltaTime;
        characterController.Move(gravityVelocity * Time.deltaTime);
        //Checking if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, checkSphereRadius, groundMask);
        if(isGrounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = -2f;
        }
    }
}
