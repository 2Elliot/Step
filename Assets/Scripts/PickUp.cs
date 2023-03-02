using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

  [SerializeField] private InputHandler inputHandler;

  [SerializeField] private GameObject selectedGraphics;

  private bool inRange;

  private void Update() {
    if (inputHandler.GetInteractKey() == 1 && inRange) {
      InitiatePickUp();
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.TryGetComponent<Player>(out Player Component)) {
      inRange = true;
      ShowGraphics();
    }
  }

  private void OnTriggerExit2D(Collider2D other) {
    if (other.TryGetComponent<Player>(out Player Component)) {
      inRange = false;
      HideGraphics();
    }
  }

  private void ShowGraphics() {
    selectedGraphics.SetActive(true);
  }

  private void HideGraphics() {
    selectedGraphics.SetActive(false);
  }

  private void InitiatePickUp() {
    Debug.Log("Collect");
    gameObject.SetActive(false);
  }

}
