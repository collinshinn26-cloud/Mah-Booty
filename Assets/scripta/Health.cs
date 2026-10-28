using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public object OnHealthChanged { get; internal set; }
    public float CurrentHealth { get; internal set; }
    public float MaxHealth { get; internal set; }

    void Start()
    {
        currentHealth = maxHealth; // Initialize health at the start
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount; // Subtract damage from health

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // If it's an enemy or player, handle death
        if (gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has died.");
            // Add respawn or game over logic here
        }
        else
        {
            Destroy(gameObject); // Remove enemy from the scene
        }
    }
}

