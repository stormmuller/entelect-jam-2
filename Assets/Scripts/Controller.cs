using UnityEngine;

public class Controller : MonoBehaviour
{
    public float WalkMaxSpeed = 10.0f;
    public float RunMaxSpeed = 15f;
    public float WalkJumpModifier = 7.0f;
    public float RunJumpModifier = 10.0f;
    public Animator anim;
    public ParticleSystem dustParticles;

    private float horizontalInput;
    private float maxSpeed;
    private float jumpModifier;
    private Rigidbody2D rigidbody2D;
    private bool jumpButtonPressed;
    private bool canJump;
    private bool isRunning;
    private SpriteRenderer renderer;
    
	private void Start ()
	{
	    rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        canJump = true;
	}
	
	private void Update ()
	{
	    horizontalInput = Input.GetAxis("Horizontal");
	    jumpButtonPressed = Input.GetButtonDown("Jump");
        isRunning = Input.GetButton("Run");

        maxSpeed = isRunning ? RunMaxSpeed : WalkMaxSpeed;
        jumpModifier = isRunning ? RunJumpModifier : WalkJumpModifier;

        float walkingSpeed = rigidbody2D.velocity.x;
        renderer.flipX = walkingSpeed < 0;   

        anim.SetFloat("WalkingSpeed", Mathf.Abs(walkingSpeed));
        anim.SetBool("CanJump", canJump);
	}
    
    void FixedUpdate()
    {
        var speed = maxSpeed * horizontalInput;
        var moveSpeed = new Vector2(speed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = moveSpeed;

        if(jumpButtonPressed && canJump)
        {
            var jumpForce = new Vector2(0, jumpModifier);
            rigidbody2D.AddForce(jumpForce, ForceMode2D.Impulse);

            canJump = false;
            dustParticles.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Floor")
        {
            canJump = true;
            dustParticles.Play();
        }
    }
}
