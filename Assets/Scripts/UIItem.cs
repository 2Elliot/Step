using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Item item;
    public Image spriteImage;

    private void Awake() {
        spriteImage = GetComponent<Image>();
        UpdateTime(null);
    } 

    public void UpdateTime(Item item) {
        if (this.item != null) {
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.icon;
        } else {
            spriteImage.color = Color.clear;
        }
    }
}
