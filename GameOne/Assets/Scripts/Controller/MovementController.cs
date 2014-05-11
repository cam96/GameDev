using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
	public static void MoveObjectHorizontally(MovableObject movableObject, float movementDirection, float movementSpeed) {
		movableObject.GameObject.rigidbody2D.velocity = new Vector2 (movementDirection * movementSpeed, movableObject.GameObject.rigidbody2D.velocity.y);

		if (movementDirection > 0 && !movableObject.IsFacingRight) {
			FlipMovableObjectLocalScaleHorizontally(movableObject);
		} 
		else if (movementDirection < 0 && movableObject.IsFacingRight) {
			FlipMovableObjectLocalScaleHorizontally(movableObject);
		}
	}
	
	private static void FlipMovableObjectLocalScaleHorizontally(MovableObject movableObject) {
		Vector3 theScale = movableObject.GameObject.transform.localScale;
		theScale.x *= -1;
		movableObject.GameObject.transform.localScale = theScale;
		movableObject.IsFacingRight = !movableObject.IsFacingRight;
	}
}

