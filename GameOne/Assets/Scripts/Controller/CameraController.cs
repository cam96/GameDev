using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public static void UpdateCameraToFollowGameObject(GameObject gameObject, Point lastLocation, Camera camera) {
		if (gameObject != null && lastLocation != null && camera != null) {
			float gameObjectX = gameObject.transform.position.x;
			float gameObjectY = gameObject.transform.position.y;
			camera.transform.Translate (gameObjectX - lastLocation.X, gameObjectY - lastLocation.Y, -0.0f);
		}
	}
}

