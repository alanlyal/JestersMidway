using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    [System.Obsolete]
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        Debug.Log("Enemy HP: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    [System.Obsolete]
    void Die()
    {
        Debug.Log("Enemy died");

        // Tell GameManager you won (optional for now)
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            gm.EndMatch();
        }

        Destroy(gameObject);
    }
}