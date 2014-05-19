using UnityEngine;
using System.Collections;

public class CustomAnimation
{
	private Animator animator;
	private float animationLength;
	private float mecanimAnimationHashValue;
	private string mecanimAnimationName;
	private float animationDelay;
	private string animationName;

	public CustomAnimation(string mecanimAnimationName, float animationDelay, float animationLength, Animator animator) {
		this.animator = animator;
		this.mecanimAnimationName = mecanimAnimationName;
		this.animationDelay = animationDelay;
		this.animationLength = animationLength;
	}

	public WaitForSeconds WaitForAnimationDelay() {
		return new WaitForSeconds(animationDelay);
	}

	public WaitForSeconds WaitForAnimationToFinish() {
		return new WaitForSeconds(animationLength);
	}
}

