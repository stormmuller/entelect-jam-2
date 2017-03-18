using UnityEngine;

public class Controller : MonoBehaviour
{
    public float MaxSpeed = 10.0f;
    public float JumpModifier = 5.0f;

    private float horizontalInput;
    private Rigidbody2D rigidbody2D;
    private bool jumpButtonPressed;
    private bool canJump;
    
	private void Start ()
	{
	    rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        canJump = true;
	}
	
	private void Update ()
	{
	    horizontalInput = Input.GetAxis("Horizontal");
	    jumpButtonPressed = Input.GetButtonDown("Jump");
	}
    
    void FixedUpdate()
    {
        var speed = MaxSpeed * horizontalInput;
        var moveSpeed = new Vector2(speed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = moveSpeed;

        if(jumpButtonPressed && canJump)
        {
            var jumpForce = new Vector2(0, JumpModifier);
            rigidbody2D.AddForce(jumpForce, ForceMode2D.Impulse);

            canJump = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Floor")
        {
            canJump = true;
        }
    }
}
