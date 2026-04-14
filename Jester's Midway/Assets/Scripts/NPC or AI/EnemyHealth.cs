using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Action OnDeath;
    private bool isDead = false;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        if (isDead) return;
        currentHealth -= damage;
        Debug.Log("Enemy HP: " + currentHealth);
        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        if (isDead) return;
        isDead = true;
        Debug.Log("Enemy died");
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}