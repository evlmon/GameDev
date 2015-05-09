using UnityEngine;
using System.Collections;

public class CharacterControlScript : MonoBehaviour {

	public LayerMask whatIsGround;
	public LayerMask floor;
	public float jumpForce = 10f;
	public Transform groundCheck;
    public float CATCH_UP_SPEED = 3f;
    public float BOLT_SPEED = 5;

    public GameObject shot;
    public Transform shotSpawn;

    private Vector2 originalPosition;
	bool grounded = false;
	float groundRadius = 0.2f;
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
		if (Input.GetButtonDown("Jump") && grounded)
		{
			jump = true;
		}

        if(Input.GetMouseButtonDown(0))
        {
            var mouseClickPosition = Input.mousePosition;
            mouseClickPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);
            var xvelocityVector = (shotSpawn.position.x) - (mouseClickPosition.x);
            var yvelocityVector = (shotSpawn.position.y) - (mouseClickPosition.y);
            var rotation = Quaternion.FromToRotation(Vector3.up, shotSpawn.position - mouseClickPosition);
            Rigidbody2D newShotrb2d = Instantiate(shot, shotSpawn.position, rotation) as Rigidbody2D;
            newShotrb2d.velocity = new Vector2(1, xvelocityVector / yvelocityVector) * BOLT_SPEED;
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
