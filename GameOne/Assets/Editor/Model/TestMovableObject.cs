using NUnit.Framework;
using UnityEngine;

[TestFixture()]
public class TestMovableObject
{
	[Test()]
	public void InitializeValidData()
	{
		GameObject gameObject = new GameObject ();
		MovableObject movableObject = new MovableObject (gameObject, true);
		Assert.True (movableObject.IsFacingRight);
		Assert.AreSame (gameObject, movableObject.GameObject);
	}
		
	[Test()]
	public void SetValidData() {
		GameObject gameObject1 = new GameObject ();
		GameObject gameObject2 = new GameObject ();
		MovableObject movableObject = new MovableObject (gameObject1, true);
		Assert.True (movableObject.IsFacingRight);
		Assert.AreSame (gameObject1, movableObject.GameObject);

		movableObject.GameObject = gameObject2;
		movableObject.IsFacingRight = false;
		Assert.False (movableObject.IsFacingRight);
		Assert.AreSame (gameObject2, movableObject.GameObject);
	}
}