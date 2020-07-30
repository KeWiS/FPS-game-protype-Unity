using UnityEngine;

public class HitTarget : MonoBehaviour
{
    //Public variables
    public GameManager gameManager;

    public float health = 20f;
    public int scoreForKill = 1;

    //Use this for initialization
    void Start()
    {
        //Assigning GameManager component to gameManager variable
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Taking damage method
    public void TakeDamage (float damage)
    {
        //Reducing target's health after hit
        health -= damage;
        //Checking if target has 0 or less than 0 health
        if (health <= 0f)
        {
            //Starting dying method
            Die();
            //Updating score
            gameManager.ScoreUpdate(scoreForKill);
            //Updating enemy count
            gameManager.enemyCount--;
        }
    }
    //Dying after passing 0 health
    void Die()
    {
        //Destroying object
        Destroy(gameObject);
    }
}
