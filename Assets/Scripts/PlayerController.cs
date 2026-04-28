using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
    private GroundCheck groundCheck;
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
        groundCheck = new GroundCheck(col, playerRB, groundCheckRadius, groundLayer);
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);

        isGrounded = groundCheck.IsGrounded();

        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetButton("Jump");
        bool fireInput = Input.GetButton("Fire1");

        playerRB.linearVelocityX = horizontalInput * 7.5f;

        if (jumpInput && isGrounded)
        {
            playerRB.AddForce(Vector2.up * 0.2f, ForceMode2D.Impulse);

            anim.SetBool("IsGrounded", false);
        }
        else if (isGrounded && !jumpInput)
        {
            anim.SetBool("IsGrounded", true);


        }
        if (fireInput && clipInfo[0].clip.name != "BaronFire")

        {
            anim.SetTrigger("BaronFire");
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathTrigger"))
        {
            Debug.Log("Trigger Hit");
            anim.SetTrigger("DeathTrigger");
            StartCoroutine(DeathDelay());
            
        }
    }

    private IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
         
     
    
}
