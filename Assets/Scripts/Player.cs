using UnityEngine;
using UnityEngine.InputSystem;
// I loooove Chocolate
// But I can't eat it because then I'll get fat
public class Player : MonoBehaviour
{
    float movementX;
    float movementY;
    [SerializeField] float speed = 6;

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

        Debug.Log(v);
    }

    void FixedUpdate()
    {
        float XmoveDistance = movementX * speed * Time.fixedDeltaTime;
        float YmoveDistance = movementY * speed * Time.fixedDeltaTime;
        rb.AddForce(new Vector2(XmoveDistance, YmoveDistance));
        //transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);
    }
}
