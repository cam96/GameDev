using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour
{
	public float horizontalMovementSpeed = 15f;

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
		MovementController.MoveObjectHorizontally (playerGameObject, Input.GetAxis ("Horizontal"), horizontalMovementSpeed);
		animator.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
	}

	private void UpdateCharsLastLocation() {
		if (playerGameObject != null && lastLocation == null) {
			lastLocation = new Point (playerGameObject.GameObject.transform.position.x, playerGameObject.GameObject.transform.position.y);
		} else if (playerGameObject != null) {
			lastLocation.SetPoint(playerGameObject.GameObject.transform.position.x, playerGameObject.GameObject.transform.position.y);
		}
	}
}

