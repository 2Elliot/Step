using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualMove : MonoBehaviour
{

	public float rotationSpeed;
	[SerializeField] private float rotationOffset;

	private void Update() {
		HandleRotation();
	}

	private void HandleRotation() {
		var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - rotationOffset;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

}
