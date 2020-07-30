using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Public variables
    public float mouseSensitivity = 125f;

    public Transform playerBody;

    public GameManager gameManager;
    //Private variables
    float xRotation = 0f;

	//Use this for initialization
	void Start ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	//Update is called once per frame
	void Update ()
    {
        if (!gameManager.gameOver)
        {
            //Getting mouse inputs
            float xAxis = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float yAxis = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            LookVertical(yAxis);
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
