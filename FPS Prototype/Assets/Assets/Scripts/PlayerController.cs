﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public variables
    public CharacterController characterController;

    public Transform groundCheck;

    public LayerMask groundMask;

    public GameManager gameManager;


    public float playerSpeed = 13f;
    public float gravity = -9.81f;
    public float checkSphereRadius = 0.3f;
    public float jumpHeight = 2.5f;

    //Private variables
    Vector3 gravityVelocity;

    bool isGrounded;

    //Use this for initialization
    void Start()
    {
        //Assigning GameManager component to gameManager variable
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Update is called once per frame
    void Update ()
    {
        //Checking if game is still running
        if (!gameManager.gameOver)
        {
            //Getting keyboard inputs
            float xAxis = Input.GetAxis("Horizontal");
            float zAxis = Input.GetAxis("Vertical");
            //Calling moving method
            Move(xAxis, zAxis);
            //Calling jumping method
            Jump();
            //Calling gravity calculations method
            Gravity();
            //Calling ground check method
            GroundCheck();
        }
    }
    //Player movement method
    void Move (float xAxis, float zAxis)
    {
        //Allowing player to move
        Vector3 movingDirection = transform.right * xAxis + transform.forward * zAxis;
        characterController.Move(movingDirection * playerSpeed * Time.deltaTime);
    }
    //Player jump method
    void Jump ()
    {
        //Allowing player to jump y = sqrt(h * -2 * g)
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            gravityVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }
    //Gravity calculation and application method
    void Gravity ()
    {
        //Calculating gravity delta y = (1/2*g)*t^2
        gravityVelocity.y += gravity * Time.deltaTime;
        characterController.Move(gravityVelocity * Time.deltaTime);
    }
    //Checking if player is on the ground method
    void GroundCheck ()
    {
        //Checking if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, checkSphereRadius, groundMask);
        if (isGrounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = -2f;
        }
    }
}
