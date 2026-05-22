using UnityEngine;

public class GroundCheck
{
    private bool isGrounded = false;

    private LayerMask ground;
    private Rigidbody2D rb;
    private Collider2D col;
    private float radius;

    private Vector2 groundCheckPos => new Vector2(col.bounds.center.x, col.bounds.min.y);
    public GroundCheck(Collider2D col, Rigidbody2D rb, float radius, LayerMask Ground)
    {
        this.col = col;
        this.rb = rb;
        this.radius = radius;
        this.ground = Ground;
    }

    public bool CheckGrounded()
    {
        if (!isGrounded && rb.linearVelocityY <= 0 || isGrounded)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckPos, radius, ground);
        }

        return isGrounded;
    }
}
