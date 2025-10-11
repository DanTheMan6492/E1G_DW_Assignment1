using UnityEngine;
using UnityEngine.InputSystem;
// I loooove Chocolate
// But I can't eat it because then I'll get fat
public class Player : MonoBehaviour
{
    float movementX;
    float movementY;
    [SerializeField] float speed = 6;
    [SerializeField] float jumppower = 1;
    bool jumping = false;

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    void OnJump()
    {
        if (touchingGround)
        {
            jumping = true;
        }
    }

    void FixedUpdate()
    {
        float XmoveDistance = movementX * speed * Time.fixedDeltaTime;
        float YmoveDistance = movementY * Time.fixedDeltaTime;
        rb.linearVelocityX = XmoveDistance;

        // Handle Jumping
        if (touchingGround)
        {
            rb.AddForce(YmoveDistance * jumppower * Vector2.up, ForceMode2D.Impulse);
        }
        //transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);
    }

    bool touchingGround;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("ground"))
        {
            touchingGround = true;
            jumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("ground"))
        {
            touchingGround = false;
        }
    }
}
