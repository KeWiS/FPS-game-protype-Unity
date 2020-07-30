using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Public variables
    public Text scoreText;
    public GameObject endScreen;

    public List<GameObject> targets;

    public int enemyCount;

    public bool gameOver = false;

    //Private variables
    float spawnMinX = -40f;
    float spawnMaxX = 50f;
    float spawnMinZ = -8f;
    float spawnMaxZ = 85f;

    int score;
    int smallGunTargets = 2;
    int sniperRifleTargets = 3;

    //Use this for initialization
    void Start ()
    {
        //Score variable and method
        score = 0;
        ScoreUpdate(0);
        //SmallGun targets
        for (int i = 0; i <= smallGunTargets - 1; i++)
        {
            Instantiate(targets[0], GenerateSpawnPosition(), Quaternion.Euler(0f, 0f, 0f));
            enemyCount++;
        }
        //SniperRifle targets
        for (int j = 0; j <= sniperRifleTargets - 1; j++)
        {
            Instantiate(targets[1], GenerateSpawnPosition(), Quaternion.Euler(0f, 0f, 0f));
            enemyCount++;
        }
    }

    //Update is called once per frame
    private void Update ()
    {
        if (enemyCount <= 0)
        {
            endScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameOver = true;
        }
    }

    //Score updating method
    public void ScoreUpdate (int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    //Random spawn positions method
    Vector3 GenerateSpawnPosition ()
    {
        float spawnPosX = Random.Range(spawnMinX, spawnMaxX);
        float spawnPosZ = Random.Range(spawnMinZ, spawnMaxZ);
        Vector3 spawnPosition = new Vector3(spawnPosX, 0.5f, spawnPosZ);
        return spawnPosition;
    }

    //Restarting game method
    public void RestartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOver = false;
        Debug.Log("restart");
    }

    //Main menu game method
    public void MainMenu ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("Main menu");
    }
}
