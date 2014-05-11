using UnityEngine;
using System.Collections;

public class MovableObject
{
	private bool _isFacingRight;
	private GameObject _gameObject;

	public MovableObject(GameObject gameObject, bool isFacingRight) {
		this._gameObject = gameObject;
		this._isFacingRight = isFacingRight;
	}

	public GameObject GameObject {
		get
		{
			return this._gameObject;
		}
		set
		{
			this._gameObject = value;
		}
	}

	public bool IsFacingRight {
		get
		{
			return this._isFacingRight;
		}
		set
		{
			this._isFacingRight = value;
		}
	}
}

