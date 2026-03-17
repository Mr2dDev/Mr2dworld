using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 5;
    public float attackRange = 1.2f;
    public float attackCooldown = 1f;

    private float nextAttackTime = 0f;

    public Transform player;

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void Attack()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}