using UnityEngine;
using System.Collections;

public class JumpingObject : MonoBehaviour
{
	private float jumpForce = 100f;
	private int jumpForceCount = 0;
	private int maxJumpForceCount = 5;
	private bool isJumping = false;
}

