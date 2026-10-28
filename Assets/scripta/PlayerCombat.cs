using UnityEngine;

public class PlayerCombat2D : MonoBehaviour
{
    [Header("References")]
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public Animator animator;

    [Header("Combat Stats")]
    public int attackDamage = 20;
    public float attackRange = 0.6f;
    public float attackRate = 2f; // Attacks per second
    public float knockbackForce = 5f;

    private float nextAttackTime = 0f;

    void Update()
    {
        // Enforces attack speed cooldown
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        if (animator != null) animator.SetTrigger("Attack");

        // Detect all colliders in the attack circle
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            // 1. Deal Damage
            EnemyHealth2D enemyHealth = enemy.GetComponent<EnemyHealth2D>();
            if (enemyHealth != null)
            {
                // Calculate knockback direction away from the player
                Vector2 knockbackDirection = (enemy.transform.position - transform.position).normalized;
                enemyHealth.TakeDamage(attackDamage, knockbackDirection, knockbackForce);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
