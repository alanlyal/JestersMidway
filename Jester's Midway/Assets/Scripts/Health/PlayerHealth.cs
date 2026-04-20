using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem; 

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 100f;
    private float currentHealth;
    public Image fillImage;
    [SerializeField] private VoidEventChannel playerDeathChannel;
    private Color greenColor = new Color(0.18f, 0.8f, 0.18f);
    private Color yellowColor = new Color(1f, 0.85f, 0f); 
    private Color redColor = new Color(0.85f, 0.1f, 0.1f);

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.value = currentHealth;
        UpdateHealthColor();
    }

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
        Time.timeScale = 0f; 
    }

    private void Update()
    {
       
        if (Keyboard.current != null)
        {
           
            if (Keyboard.current.zKey.wasPressedThisFrame)
            {
                TakeDamage(10f);
            }

           
            if (Keyboard.current.xKey.wasPressedThisFrame)
            {
                Heal(10f);
            }
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