using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Public variables
    public Text scoreText;
    public Text endText;

    public GameObject endScreen;
    public GameObject sniperScope;
    public GameObject sniperCrosshair;

    public Camera gameCamera;

    public WeaponSwitch gun;

    public List<GameObject> targets;


    public int enemyCount;

    public bool gameOver = false;

    //Private variables
    float spawnMinX = -40f;
    float spawnMaxX = 50f;
    float spawnMinZ = -7f;
    float spawnMaxZ = 82f;
    float restartTime = 5f;
    float normalCameraFov = 60f;
    float scopedCameraFov = 20f;

    int score;
    int smallGunTargets = 2;
    int sniperRifleTargets = 3;

    //Use this for initialization
    void Start()
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
    private void Update()
    {

        //If right mouse button is pressed sniper scope appear
        if (Input.GetButton("Fire2"))
        {
            //Changing to scope crosshair and camera fov
            Scope();
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            //Changing to normal scope and camera fov
            Unscope();
        }

        //What happens when game end (every target is dead)
        if (enemyCount <= 0)
        {
            //Showing ending screen
            endScreen.SetActive(true);
            //Changing to normal scope and camera fov
            Unscope();
            //Unlocking and showing cursor
            CursorUnlock();
            //Setting game to gameOver state
            gameOver = true;
            //Starting coroutine to automatically restart game
            StartCoroutine(GameRestart(restartTime));
        }
    }

    //Score updating method
    public void ScoreUpdate(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    //Random spawn positions method
    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(spawnMinX, spawnMaxX);
        float spawnPosZ = Random.Range(spawnMinZ, spawnMaxZ);
        Vector3 spawnPosition = new Vector3(spawnPosX, 0.5f, spawnPosZ);
        return spawnPosition;
    }

    //Restarting game method
    public void RestartGame()
    {
        //Reloading scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Setting gameOver state to false
        gameOver = false;
        //Hiding and locking cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //Main menu game method
    public void MainMenu()
    {
        //Loading menu scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //Setting sniper to scope mode method
    void Scope()
    {
        //Checking if sniper is equiped and game is not over
        if (!gun.smallGunDrawed && !gameOver)
        {
            sniperCrosshair.SetActive(false);
            sniperScope.SetActive(true);
            Camera.main.fieldOfView = scopedCameraFov;
        }
    }
    //Setting sniper to normal mode method
    public void Unscope()
    {
        //Checking if sniper is equiped and game is not over
        if (!gun.smallGunDrawed && !gameOver)
        {
            sniperScope.SetActive(false);
            sniperCrosshair.SetActive(true);
            Camera.main.fieldOfView = normalCameraFov;
        }
    }
    //Unlocking and showing cursor method
    void CursorUnlock ()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Coroutine for game restarting
    IEnumerator GameRestart(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
