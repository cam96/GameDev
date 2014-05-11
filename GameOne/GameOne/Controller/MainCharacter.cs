using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour
{
	public float horizontalMovementSpeed = 15f;

	private bool isFacingRight = true;
	private Point lastLocation;
	private GameObject playerGameObject;
	private Camera mainCamera;

	public void Start ()
	{
		playerGameObject = GameObject.Find("Character");
		mainCamera = Camera.main;
		UpdateCharsLastLocation();
	}

	public void Update ()
	{
		UpdateMainCameraToFollowChar();
		UpdateCharsLastLocation();
	}
	
	public void FixedUpdate () {
		MoveCharHorizontally();
	}

	private void MoveCharHorizontally() {
		float move = Input.GetAxis ("Horizontal"); // how much we are moving
		rigidbody2D.velocity = new Vector2 (move * horizontalMovementSpeed, rigidbody2D.velocity.y);
		
		if (move > 0 && !isFacingRight) {
			FlipLocalScaleHorizontally();
		} 
		else if (move < 0 && isFacingRight) {
			FlipLocalScaleHorizontally();
		}
	}

	private void FlipLocalScaleHorizontally() {
		isFacingRight = !isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	private void UpdateCharsLastLocation() {
		if (playerGameObject != null && lastLocation == null) {
			lastLocation = new Point (playerGameObject.transform.position.x, playerGameObject.transform.position.y);
		} else if (playerGameObject != null) {
			lastLocation.SetPoint(playerGameObject.transform.position.x, playerGameObject.transform.position.y);
		}
	}

	private void UpdateMainCameraToFollowChar() {
		if (playerGameObject != null && lastLocation != null) {
			mainCamera.transform.Translate (playerGameObject.transform.position.x - lastLocation.X, playerGameObject.transform.position.y - lastLocation.Y, -0.0f);
		}
	}
}

