using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;

    public ParticleSystem dustLeft, dustRight;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    public bool isGrounded;

    private Rigidbody2D rb;

    private Animator Anim;

    private PlayerCloneScript replaySystem;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        Anim = GetComponent<Animator>();
        replaySystem = GetComponent<PlayerCloneScript>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        Anim.SetBool("isJumping", !isGrounded);

        if(Mathf.Abs(rb.linearVelocityX) > 0 && (replaySystem.inputRight ||replaySystem.inputLeft ))
        {
            Anim.SetBool("isRunning", true);
                
        }
        else
        {
            Anim.SetBool("isRunning", false);
        }


        if (isGrounded && replaySystem.inputJump)
        {
            rb.linearVelocityY = jumpSpeed;
            Anim.SetTrigger("takeOff");
        }


        if(rb.linearVelocityY > 0)
        {
            rb.gravityScale = 2f;
        }
        else
        {
            rb.gravityScale = 4f;
        }


        if (replaySystem.inputRight && isGrounded)
        {
            dustRight.Play();
            dustLeft.Stop();
        }
        else if (replaySystem.inputLeft && isGrounded)
        {
            dustLeft.Play();
            dustRight.Stop();
        }

        else
        {
            dustLeft.Stop();
            dustRight.Stop();
        }
    }

    private void FixedUpdate()
    {
        if (replaySystem.inputRight)
        {
            rb.linearVelocityX = speed;
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else if(replaySystem.inputLeft)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
            rb.linearVelocityX = -speed;

        }
        else
        {
            rb.linearVelocityX = 0f;
        }



    }
    void OnDrawGizmos()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
