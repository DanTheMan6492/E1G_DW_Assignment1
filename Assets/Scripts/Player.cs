using UnityEngine;
using UnityEngine.InputSystem;
// I loooove Chocolate
// But I can't eat it because then I'll get fat
public class Player : MonoBehaviour
{
    float movementX;
    [SerializeField] float speed = 6;
    [SerializeField] float jumppower = 1;
    bool jumping = false;
    bool touchingGround;
    [SerializeField] float rayCastDist = 6;
    int layerMask = 0b111001;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        animator.SetBool("Walking", movementX != 0f);
        if (movementX != 0f)
        {
            spriteRenderer.flipX = rb.linearVelocityX < 0f;
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
    }

    void OnJump()
    {
        jumping = touchingGround;
    }

    void FixedUpdate()
    {

        float XmoveDistance = movementX * speed * Time.fixedDeltaTime;
        rb.linearVelocityX = XmoveDistance;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayCastDist, layerMask);

        // Floor is beneath feet
        touchingGround = hit.collider != null;

        Debug.Log(hit.collider);

        // Handle Jumping
        if (jumping)
        {
            rb.AddForce(Time.fixedDeltaTime * jumppower * Vector2.up, ForceMode2D.Impulse);
            jumping = false;
        }
        //transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);
    }
}
