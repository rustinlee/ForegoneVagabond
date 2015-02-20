using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	private Transform target; //the target to follow (main player)
	private Vector2 boundsMin;
	private Vector2 boundsMax;

	void Start() {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void LateUpdate() {
		Vector3 targetPosition = target.position;
		targetPosition.x = Mathf.Clamp(targetPosition.x, boundsMin.x, boundsMax.x);
		targetPosition.y = Mathf.Clamp(targetPosition.y, boundsMin.y, boundsMax.y);
		targetPosition.z = transform.position.z;
		transform.position = targetPosition;
	}

	public void SetConstraints(Vector2 min, Vector2 max) {
		boundsMin = min;
		boundsMax = max;
	}
}
