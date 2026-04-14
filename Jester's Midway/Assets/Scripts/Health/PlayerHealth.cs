using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 100f;
    private float currentHealth;
    public Image fillImage;
   [SerializeField] private VoidEventChannel playerDeathChannel;
    private Color greenColor = new Color(0.18f, 0.8f, 0.18f);
    private Color yellowColor = new Color(18f, 0.85f, 0f);
    private Color redColor = new Color(0.85f, 0.1f, 0.1f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.value = currentHealth;
        UpdateHealthColor();
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
        UpdateHealthColor();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.value = currentHealth;
        UpdateHealthColor();
    }

    void Die()
    {
        Debug.Log("Player has died.");
        if (playerDeathChannel != null)
            playerDeathChannel.RaiseEvent();
        SceneManager.LoadScene("game over");
        Time.timeScale = 0f; // Pause the game
    }

    private void Update()
    {
        // For testing purposes, press the space key to take damage
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(10f);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Heal(10f);
        }
    }

    private void UpdateHealthColor()
    {
        if (currentHealth > 60f)
        {
            fillImage.color = greenColor;
        }
        else if (currentHealth > 30f)
        {
            fillImage.color = yellowColor;
        }
        else
        {
            fillImage.color = redColor;
        }
    }
}
