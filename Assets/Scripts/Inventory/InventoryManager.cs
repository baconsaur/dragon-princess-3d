using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
	public Animator inventoryAnimator;

	public Item[] items;
	public Image[] itemImages;

	public void OpenInventory() {
		inventoryAnimator.SetBool ("IsOpen", true);
	}

	public void CloseInventory() {
		inventoryAnimator.SetBool ("IsOpen", false);
	}

	public void AddItem(Item item) {
		for (int i = 0; i < items.Length; i++) {
			if (items[i] == null) {
				items [i] = item;
				itemImages [i].sprite = item.sprite;
				itemImages [i].enabled = true;
				return;
			}
		}
	}
}
