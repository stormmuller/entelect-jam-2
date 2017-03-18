using UnityEngine;

public class Controller : MonoBehaviour
{
    public float MaxSpeed = 10.0f;
    public float JumpModifier = 5.0f;
    private float horizontalInput;
    private Rigidbody2D rigidbody2D;
    private bool jumpButtonPressed;

    // Use this for initialization
	private void Start ()
	{
	    this.rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	private void Update ()
	{
	    this.horizontalInput = Input.GetAxis("Horizontal");

	    this.jumpButtonPressed = Input.GetButtonDown("Jump");
	}

    //FixedUpdate is called every fixed framerate frame
    private void FixedUpdate()
    {
        var speed = this.MaxSpeed * this.horizontalInput;
        var moveSpeed = new Vector2(speed, this.rigidbody2D.velocity.y);
        this.rigidbody2D.velocity = moveSpeed;

        if(this.jumpButtonPressed)
        {
            var jumpForce = new Vector2(0, this.JumpModifier);

            this.rigidbody2D.AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }
}
