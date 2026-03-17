using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 3;
    public float attackRange = 1f;
    public LayerMask enemyLayer;

    public Transform attackPoint;

    public float attackCooldown = 0.5f;
    private float nextAttackTime = 0f;

    void Update()
    {
        // Check if player can attack (cooldown)
        if (Time.time >= nextAttackTime)
        {
            // Check for input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    void Attack()
    {
        Debug.Log("ATTACK TRIGGERED");

        // Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange,
            enemyLayer
        );

        // Damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);

            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }

    // Visualize attack range in editor
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
