using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int xpReward = 25;
    public GameObject xpTextPrefab;

    private int currentHealth;

    private EnemyAI enemyAI;

    void Start()
    {
        currentHealth = maxHealth;
        enemyAI = GetComponent<EnemyAI>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Trigger enemy aggression when hit
        if (enemyAI != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                enemyAI.AggroPlayer(player.transform);
            }
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        ShowXP();
        Destroy(gameObject);
    }

    void ShowXP()
    {
        if (xpTextPrefab == null) return;

        Canvas canvas = FindFirstObjectByType<Canvas>();

        if (canvas == null) return;

        GameObject xpText = Instantiate(xpTextPrefab, canvas.transform);

        xpText.transform.position = Camera.main.WorldToScreenPoint(transform.position);

        FloatingXP floatingXP = xpText.GetComponent<FloatingXP>();

        if (floatingXP != null)
        {
            floatingXP.SetText("+" + xpReward + " XP");
        }
    }
}