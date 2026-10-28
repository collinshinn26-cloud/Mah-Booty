using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 10f;

    private void OnCollisionEnter2D(Collision2D collision) // Use OnCollisionEnter for 3D
    {
        Health targetHealth = collision.gameObject.GetComponent<Health>();

        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damageAmount); // Apply damage
            Destroy(gameObject); // Destroy the projectile/enemy if needed
        }
    }
}

