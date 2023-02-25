using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] private InputHandler inputHandler;

	[SerializeField] private LayerMask collidableLayerMask;
	
	[SerializeField][Range(0.0f, 10.0f)] private float playerSpeed;
	[SerializeField] private float rotationSpeed;

	[SerializeField] float rotationOffset;
	[SerializeField][Range(0.0f, 1.0f)] float leftControllerDeadzone;
	[SerializeField][Range(0.0f, 1.0f)] float rightControllerDeadzone;

	private void Update() {
		HandleMovement();
		HandleRotation();
	}

	private void HandleMovement() {
		Vector2 inputVector = inputHandler.GetMovementVector();

		if (inputVector.magnitude < leftControllerDeadzone) return; // Deadzones

		inputVector = inputVector.normalized;

		Vector2 moveDirection = inputVector;

		float additionalSpeedCoefficient = 1.0f;
		float moveDistance = playerSpeed * additionalSpeedCoefficient * Time.deltaTime;
		float playerRadius = 0.7f;
		float raycastDistance = 0.1f;
		bool canMove = !Physics2D.CircleCast(transform.position, playerRadius, inputVector, raycastDistance, collidableLayerMask); // Return true if no raycast returned

		if (!canMove) {

			Vector2 moveDirectionX = new Vector2(inputVector.x, 0f);
			bool canMoveX = !Physics2D.CircleCast(transform.position, playerRadius, moveDirectionX, raycastDistance, collidableLayerMask);
			if (canMoveX) { // Can move in the X direction
				moveDirection = moveDirectionX;
			}

			Vector2 moveDirectionY = new Vector2(0f, inputVector.y);
			bool canMoveY = !Physics2D.CircleCast(transform.position, playerRadius, moveDirectionY, raycastDistance, collidableLayerMask);
			if (canMoveY) { // Can move in the Y direction 
				moveDirection = moveDirectionY;
			}

		}

		transform.position += (Vector3)(moveDistance * moveDirection);
	}

	private void HandleRotation() {
		Vector2 rotationVector = inputHandler.GetMovementVector();

		if (rotationVector.magnitude < leftControllerDeadzone ) return; // Deadzone

		float angle = Mathf.Atan2(rotationVector.y, rotationVector.x) * Mathf.Rad2Deg - rotationOffset;

		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed);
	}
}
