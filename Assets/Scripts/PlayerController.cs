using UnityEngine;

public interface IDamageable { void TakeDamage(int dmg); }

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float jumpForce = 12f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.15f;
    public LayerMask groundMask;

    [Header("Combat")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyMask;
    public int attackDamage = 1;
    public float attackCooldown = 0.25f;

    Rigidbody2D rb;
    bool canAttack = true;
    bool facingRight = true;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        // Horizontal move
        float x = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(x * moveSpeed, rb.linearVelocity.y);

        // Flip sprite
        if (x > 0 && !facingRight) Flip();
        else if (x < 0 && facingRight) Flip();

        // Jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        // Attack
        if (Input.GetButtonDown("Fire1") && canAttack)
            StartCoroutine(DoAttack());
    }

    bool IsGrounded() =>
        Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

    System.Collections.IEnumerator DoAttack()
    {
        canAttack = false;

        // Detect enemies in range
        var hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyMask);
        foreach (var h in hits)
        {
            var dmg = h.GetComponent<IDamageable>();
            if (dmg != null) dmg.TakeDamage(attackDamage);
        }

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    void Flip()
    {
        facingRight = !facingRight;
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
        if (groundCheck)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
