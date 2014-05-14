using UnityEngine;
using System.Collections;

public class Character
{
	private GameObject characterGameObject;

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
}

