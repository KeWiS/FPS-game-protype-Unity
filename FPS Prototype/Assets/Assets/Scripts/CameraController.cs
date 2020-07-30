using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Public variables
    public Transform playerBody;

    public GameManager gameManager;


    public float mouseSensitivity = 125f;

    //Private variables
    float xRotation = 0f;

	//Use this for initialization
	void Start ()
    {
        //Assigning GameManager component to gameManager variable
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //Locking cursor for camera movement
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	//Update is called once per frame
	void Update ()
    {
        //Checking if game is still running
        if (!gameManager.gameOver)
        {
            //Getting mouse inputs
            float xAxis = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float yAxis = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            //Calling vertical look method
            LookVertical(yAxis);
            //Calling horizontal look method
            LookHorizontal(xAxis);
        }
    }
    //Player looking vertical method
    void LookVertical (float yAxis)
    {
        //Preventing from view leaping
        xRotation -= yAxis;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //Allowing player to look around vertical
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
    //Player looking horizontal method
    void LookHorizontal (float xAxis)
    {
        //Allowing player to look around horizontal
        playerBody.Rotate(Vector3.up * xAxis);
    }
}
