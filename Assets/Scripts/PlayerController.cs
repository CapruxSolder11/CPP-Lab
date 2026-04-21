using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    private bool isGrounded;
    public LayerMask groundLayer;
    public float groundCheckRadius = 2f;
    
    private Collider2D col;
    private Rigidbody2D playerRB;
    private Vector2 groundCheckPos => CalculateGroundBounds();
    private SpriteRenderer sprite;

    private Animator anim;

    private Vector2 CalculateGroundBounds()
    {
        Bounds bounds = col.bounds;
        return new Vector2(bounds.center.x, bounds.min.y);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPos, groundCheckRadius, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetButton("Jump");

        playerRB.linearVelocityX = horizontalInput * 5f;
        if (jumpInput && isGrounded)
        {
            playerRB.AddForce(Vector2.up * 0.1f, ForceMode2D.Impulse);
           
            anim.SetBool("IsGrounded", false);
        }
        else if (isGrounded && !jumpInput) 
        {
            anim.SetBool("IsGrounded", true);
           

        }

        if (horizontalInput > 0 | horizontalInput < 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);

        }

        if (horizontalInput < 0)
        {
            sprite.flipX = true;

        }
        else
        {
            sprite.flipX = false;
        }
    }


    
}
