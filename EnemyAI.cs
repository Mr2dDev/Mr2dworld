using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float roamSpeed = 0.6f;
    public float chaseSpeed = 2f;

    public float roamRadius = 1.5f;
    public float attackRange = 1.2f;

    public float roamPauseTime = 2f;

    private Rigidbody2D rb;
    private Transform player;

    private Vector2 roamTarget;
    private float pauseTimer;

    private bool isAggro = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChooseNewRoamTarget();
        pauseTimer = roamPauseTime;
    }

    void FixedUpdate()
    {
        if (isAggro && player != null)
        {
            ChasePlayer();
        }
        else
        {
            Roam();
        }
    }

    void Roam()
    {
        pauseTimer -= Time.fixedDeltaTime;

        if (pauseTimer > 0)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        float distance = Vector2.Distance(transform.position, roamTarget);

        if (distance < 0.2f)
        {
            pauseTimer = roamPauseTime;
            ChooseNewRoamTarget();
        }

        Vector2 direction = (roamTarget - (Vector2)transform.position).normalized;
        rb.linearVelocity = direction * roamSpeed;
    }

    void ChooseNewRoamTarget()
    {
        Vector2 randomPoint = Random.insideUnitCircle * roamRadius;
        roamTarget = (Vector2)transform.position + randomPoint;
    }

    void ChasePlayer()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * chaseSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void AggroPlayer(Transform playerTransform)
    {
        player = playerTransform;
        isAggro = true;
    }
}