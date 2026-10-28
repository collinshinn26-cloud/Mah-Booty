using System.Collections;
using UnityEngine;

public class EnemyHealth2D : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private Rigidbody2D rb;
    private bool isKnockedBack = false;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, Vector2 knockbackDir, float force)
    {
        if (isKnockedBack) return; // Prevent knockback stacking glitches

        currentHealth -= damage;
        Debug.Log($"Enemy hit! Health: {currentHealth}");

        // Apply physics thrust
        if (rb != null)
        {
            StartCoroutine(ApplyKnockback(knockbackDir, force));
        }

        if (currentHealth <= 0) Die();
    }

    private IEnumerator ApplyKnockback(Vector2 direction, float force)
    {
        isKnockedBack = true;

        // Zero out current velocity for a consistent pushback distance
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction * force, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.2f); // Duration of the stun/push

        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

