using UnityEngine;
using System.Collections;

public class SanjiControllerScript : MonoBehaviour {
	public float maxSpeed = 10f;
	public bool isFacingRight = true;
	public Transform groundCheck;
	public LayerMask whatIsGround; // what layers are considered ground

	bool isGrounded = false;
	const float groundRadius = 0.2f;  // how big circles will be when we check for the ground
	public float jumpForce = 700;
	public float oldY = 0.0f;
	public float oldX = 0.0f;

	Animator anim;
	Camera mainCamera;
	GameObject player;
	float sum = 0;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); // get animator
		mainCamera = Camera.main;
		player = GameObject.Find ("Character");
	}
	
	void Update() {
		mainCamera.transform.Translate (player.transform.position.x - oldX, player.transform.position.y - oldY, -0.0f);
		oldY = player.transform.position.y;
		oldX = player.transform.position.x;

		if (isGrounded && Input.GetButtonDown ("Jump")) {
			anim.SetBool ("IsGrounded", false);
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
		}
	}

	// update physics stuff
	void FixedUpdate () { // do not need to use time delta time because we are in fixed update
		float move = Input.GetAxis ("Horizontal"); // how much we are moving

		// check to see if we are on the ground or not
		// check to see if we are hitting any colliders in this circle projected right below the characters feet
		// generate the circle at groundCheck.position
		// groundRadius is the radius of the circle we are generating
		// whatisGround is all the things the circle will collide with
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		anim.SetBool ("IsGrounded", isGrounded);
		anim.SetFloat ("Speed", Mathf.Abs (move)); // set speed
		anim.SetFloat ("VerticalSpeed", rigidbody2D.velocity.y); // how fast we are moving up or down

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y); // taking current y velocity and move left or right based on the key you are pressing times the max speed

		if (move > 0 && !isFacingRight) {
			Flip ();
		} 
		else if (move < 0 && isFacingRight) {
			Flip();
		}
	}

	void Jump() {

	}

	void Flip() {
		isFacingRight = !isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
