using UnityEngine;
using System;
using System.Collections;
using UnityEditor;

public class MainCharacter : MonoBehaviour
{
	public float horizontalMovementSpeed = 3f;
	public float walkingMovementSpeed = 3f; // walking
	public float runningMovementSpeed = 10f; // running
	public float increaseSpeedBy = 0.05f;

	public float jumpForce = 100f;
	public int jumpForceCount = 0;
	public int maxJumpForceCount = 5;
	public bool isJumping = false;

	public bool isCharOnGround = false;
	public Transform checkForGround;
	public float groundCircleColliderRadius = 0.2f;
	public LayerMask layersThatAreGround;

	private bool isCrouching = false;
	
	private Point lastLocation;
	private MovableObject playerGameObject;
	private Camera mainCamera;
	private Animator animator;

	public void Start ()
	{
		playerGameObject = new MovableObject (GameObject.Find ("Megaman"), true);
		animator = GetComponent<Animator> ();
		mainCamera = Camera.main;
		UpdateCharsLastLocation();
	}

	public void Update ()
	{
		Crouch ();
		JumpHeightBasedOnHoldingDownJumpButton ();
		CameraController.UpdateCameraToFollowGameObject (playerGameObject.GameObject, lastLocation, mainCamera);
		UpdateCharsLastLocation();
	}
	
	public void FixedUpdate () {
		UpdatePlayerStateIsOnGround ();
		MovePlayerObjectBasedOnHorizontalMovement ();
	}

	private void Crouch() {
		Vector3 playerSize = playerGameObject.GameObject.renderer.bounds.size;
		if (Input.GetButtonDown ("Crouch")) {
			isCrouching = !isCrouching;
			animator.SetBool("IsCrouched", isCrouching);
			UpdateBoxCollider2DSize (playerGameObject.GameObject, playerSize.x, playerSize.y / 2);
		}

		if (!isCrouching) {
			UpdateBoxCollider2DSize (playerGameObject.GameObject, playerSize.x, playerSize.y);
		}
	}

	private void UpdateBoxCollider2DSize(GameObject gameObject, float x, float y) {
		BoxCollider2D boxCollider2D = playerGameObject.GameObject.GetComponent<BoxCollider2D>();
		boxCollider2D.size = new Vector2 (x, y);
	}
	
	private void UpdatePlayerStateIsOnGround() {
		isCharOnGround = Physics2D.OverlapCircle (checkForGround.position, groundCircleColliderRadius, layersThatAreGround);
		animator.SetBool ("IsCharOnGround", isCharOnGround);
	}

	private void MovePlayerObjectBasedOnHorizontalMovement() {
		float horizontalMovement = Input.GetAxis ("Horizontal");
		UpdateHorizontalMovementSpeed (horizontalMovement);
		MovementController.MoveObjectHorizontally (playerGameObject, horizontalMovement, horizontalMovementSpeed);
		animator.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
	}

	private void JumpHeightBasedOnHoldingDownJumpButton() {
		if (Input.GetButtonUp("Jump")) {
			isJumping = false;
			jumpForceCount = 0;
		}
		else if (Input.GetButtonDown ("Jump") && isCharOnGround) {
			isJumping = true;
		}
		else if (Input.GetButton ("Jump") && isJumping && !isCrouching) {
			if (jumpForceCount < maxJumpForceCount) {
				jumpForceCount++;
				rigidbody2D.AddForce (new Vector2 (0, jumpForce));
			}
		}
	}

	private float UpdateHorizontalMovementSpeed(float horizontalMovement) {
		if (Input.GetButton ("Fire1")) {
			if (IsCharChangingHorizontalDirection(horizontalMovement)) {
				animator.SetBool("IsRunning", false);
				horizontalMovementSpeed = walkingMovementSpeed; // changed directions
			}
			else if (horizontalMovementSpeed < runningMovementSpeed) {
				animator.SetBool("IsRunning", true);
				horizontalMovementSpeed += increaseSpeedBy;
			}
		} 
		else {
			horizontalMovementSpeed = walkingMovementSpeed;
			animator.SetBool("IsRunning", false);
		}

		return horizontalMovementSpeed;
	}

	private bool IsCharChangingHorizontalDirection(float horizontalMovement) {
		return (playerGameObject.IsFacingRight && horizontalMovement < 0) ||
			(!playerGameObject.IsFacingRight && horizontalMovement > 0);
	}

	private void UpdateCharsLastLocation() {
		if (playerGameObject != null && lastLocation == null) {
			lastLocation = new Point (playerGameObject.GameObject.transform.position.x, playerGameObject.GameObject.transform.position.y);
		} else if (playerGameObject != null) {
			lastLocation.SetPoint(playerGameObject.GameObject.transform.position.x, playerGameObject.GameObject.transform.position.y);
		}
	}
}

