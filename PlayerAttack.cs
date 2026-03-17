using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 3;
    public float attackRange = 1f;
    public Transform attackPoint;

    public float attackCooldown = 0.5f;
    private float nextAttackTime = 0f;

    void Update()
    {
        // Press Space to attack
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    void Attack()
    {
        Debug.Log("ATTACK");

        // Get everything in range (no layers to avoid bugs)
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange
        );

        foreach (Collider2D hit in hits)
        {
            // Ignore hitting yourself
            if (hit.gameObject == gameObject)
                continue;

            Debug.Log("Hit: " + hit.name);

            // Damage enemy if it has EnemyHealth
            EnemyHealth enemy = hit.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
