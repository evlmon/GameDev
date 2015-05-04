using UnityEngine;
using System.Collections;

public class CharacterControlScript : MonoBehaviour {

	public LayerMask whatIsGround;
	public LayerMask floor;
	public float jumpForce = 10f;
	public Transform groundCheck;
    public float CATCH_UP_SPEED = 3f;

    private Vector2 originalPosition;
	bool grounded = false;
	float groundRadius = 0.2f;
	bool touchingFloor = false;
	float speed = 0f;

	private Rigidbody2D rb2d;
	private bool jump = false;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
        originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		touchingFloor = Physics2D.OverlapCircle (groundCheck.position, groundRadius, floor);
		if (Input.GetButtonDown("Jump") && (grounded || touchingFloor))
		{
			jump = true;
		}
	}

	void FixedUpdate()
	{
		if (jump) {
			rb2d.AddForce (new Vector2 (0f, jumpForce));
			jump = false;
		}

        if (transform.position.x < originalPosition.x)
        {
            speed = CATCH_UP_SPEED;
        }
        else
        {
            speed = 0f;
        }

		rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
	}
}
