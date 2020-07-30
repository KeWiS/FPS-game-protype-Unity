using UnityEngine;

public class HitTarget : MonoBehaviour
{
    //Public variables
    public float health = 20f;
    public int scoreForKill = 1;

    public GameManager gameManager;
    //Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Taking damage method
    public void TakeDamage (float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
            gameManager.ScoreUpdate(scoreForKill);
            gameManager.enemyCount--;
        }
    }
    //Dying after passing 0 health
    void Die()
    {
        Destroy(gameObject);
    }
}
