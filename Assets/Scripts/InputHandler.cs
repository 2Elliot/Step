using System;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	private PlayerInputActions playerInputActions;


	private void Awake() {
		playerInputActions = new PlayerInputActions();
		playerInputActions.Player.Enable();
	}

	public Vector2 GetMovementVector() {
		Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

		return inputVector;
	}

	public Vector2 GetRotationVector() {
		Vector2 rotationVector = playerInputActions.Player.Look.ReadValue<Vector2>();

		return rotationVector;
	}

}
