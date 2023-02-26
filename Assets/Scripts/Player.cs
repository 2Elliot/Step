using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] private InputHandler inputHandler;

	[SerializeField] private LayerMask collidableLayerMask;
	
	[SerializeField][Range(0.0f, 10.0f)] private float playerSpeed;
	[SerializeField] private float sprintSpeedMultiplier;
	[SerializeField] private float rotationSpeed;

	private void Update() {
		HandleMovement();
		HandleRotation();
	}

	private void HandleMovement() {
		Vector2 inputVector = inputHandler.GetMovementVector();

		inputVector = inputVector.normalized;

		Vector2 moveDirection = inputVector;

		float additionalSpeedCoefficient = Convert.ToBoolean(inputHandler.GetSprintKey()) ? sprintSpeedMultiplier : 1;
		float moveDistance = playerSpeed * additionalSpeedCoefficient * Time.deltaTime;
		float raycastDistance = 0.1f;
		bool canMove = !Physics2D.Raycast(transform.position, inputVector, raycastDistance, collidableLayerMask); // Return true if no raycast returned

		if (!canMove) {

			Vector2 moveDirectionX = new Vector2(inputVector.x, 0f);
			bool canMoveX = !Physics2D.Raycast(transform.position, inputVector, raycastDistance, collidableLayerMask);
			if (canMoveX) { // Can move in the X direction
				moveDirection = moveDirectionX;
			}

			Vector2 moveDirectionY = new Vector2(0f, inputVector.y);
			bool canMoveY = !Physics2D.Raycast(transform.position, inputVector, raycastDistance, collidableLayerMask);
			if (canMoveY) { // Can move in the Y direction 
				moveDirection = moveDirectionY;
			}

		}

		transform.position += (Vector3)(moveDistance * moveDirection);
	}

	private void HandleRotation() {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector3 rotation = mousePosition - transform.position;

		float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
		float rotationOffset = 90f;
		Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle - rotationOffset));

		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
	}
}
