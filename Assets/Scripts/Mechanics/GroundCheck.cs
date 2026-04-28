using UnityEngine;

public class GroundCheck
{
    private bool _isGrounded = false;
    private Rigidbody2D rb;
    private Collider2D col;
    private float radius;
    private LayerMask groundlayer;

    private Vector2 groundCheckPos => new Vector2(col.bounds.center.x, col.bounds.min.y);

    public GroundCheck(Collider2D col, Rigidbody2D rb, float radius, LayerMask groundLayer)
    {
        this.col = col;
        this.rb = rb;
        this.radius = radius;
        this.groundlayer = groundLayer;
    }

    public bool IsGrounded()
    {
        if (!_isGrounded && rb.linearVelocityY <= 0 || _isGrounded)
        {
            _isGrounded = Physics2D.OverlapCircle(groundCheckPos, radius, groundlayer);
        }
        return _isGrounded;
    }
}
