using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Send movement value to Animator
        anim.SetFloat("Speed", movement.sqrMagnitude);

        // Flip character
        if (movement.x > 0) sr.flipX = true;
        else if (movement.x < 0) sr.flipX = false;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}