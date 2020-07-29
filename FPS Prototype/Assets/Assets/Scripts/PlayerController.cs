using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public variables
    public float playerSpeed = 10f;
    public float gravity = -9.81f;
    public float checkSphereRadius = 0.3f;

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
        //Calculating gravity delta y = (1/2*g)*t^2
        gravityVelocity.y += gravity * Time.deltaTime;
        characterController.Move(gravityVelocity * Time.deltaTime);
        //Checking if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, checkSphereRadius, groundMask);
    }
}
