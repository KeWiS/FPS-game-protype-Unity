using UnityEngine;

public class HitTarget : MonoBehaviour
{
    //Public variables
    public float health = 20f;

    //Taking damage method
    public void TakeDamage (float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }
    //Dying after passing 0 health
    void Die()
    {
        Destroy(gameObject);
    }
}
