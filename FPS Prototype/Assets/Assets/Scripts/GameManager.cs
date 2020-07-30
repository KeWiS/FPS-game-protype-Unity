using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Public variables
    public Text scoreText;
    //Private variables
    private int score;
    // Use this for initialization
    void Start ()
    {
        score = 0;
        scoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
