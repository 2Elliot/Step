using UnityEngine;
using UnityEngine.InputSystem;

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

	public float GetSprintKey() {
		float getSprint = playerInputActions.Player.Sprint.ReadValue<float>();

		return getSprint;
	}

}
