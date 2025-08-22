using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 2f;

    [Header("Ground & Wall Detection")]
    public Transform groundCheck;   // Empty object at enemy’s feet, a little ahead
    public Transform wallCheck;     // Empty object at enemy’s front
    public float checkRadius = 0.1f;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private int direction = 1; // 1 = right, -1 = left

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Move enemy
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        // Check for ground ahead
        bool groundAhead = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        // Check for wall ahead
        bool wallAhead = Physics2D.OverlapCircle(wallCheck.position, checkRadius, whatIsGround);

        // If no ground or there’s a wall, turn around
        if (!groundAhead || wallAhead)
        {
            Flip();
        }
    }

    void Flip()
    {
        direction *= -1; // reverse direction
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        if (wallCheck != null)
            Gizmos.DrawWireSphere(wallCheck.position, checkRadius);
    }
}