using UnityEngine;
using System;
using System.Collections;
using UnityEditor;

public class MainCharacter : MonoBehaviour
{
	public float horizontalMovementSpeed = 3f;
	public const float walkingMovementSpeed = 3f; // walking
	public const float runningMovementSpeed = 10f; // running

	private int previousTime;
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
		CameraController.UpdateCameraToFollowGameObject (playerGameObject.GameObject, lastLocation, mainCamera);
		UpdateCharsLastLocation();
	}
	
	public void FixedUpdate () {
		float horizontalMovement = Input.GetAxis ("Horizontal");
		GetHorizontalMovementSpeed (horizontalMovement);
		MovementController.MoveObjectHorizontally (playerGameObject, horizontalMovement, horizontalMovementSpeed);
		animator.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
	}

	private float GetHorizontalMovementSpeed(float horizontalMovement) {
		if (Input.GetButton ("Fire1")) {
			if (IsCharChangingHorizontalDirection(horizontalMovement)) {
				animator.SetBool("IsRunning", false);
				horizontalMovementSpeed = walkingMovementSpeed; // changed directions
			}
			else if (horizontalMovementSpeed < runningMovementSpeed) {
				animator.SetBool("IsRunning", true);
				horizontalMovementSpeed += 0.05f;
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

