using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
	public Animator inventoryAnimator;
	public Animator notificationAnimator;

	public Text notificationText;

	public Item[] items;
	public Image[] itemImages;

	public void ToggleInventory() {
		inventoryAnimator.SetBool ("IsOpen", !inventoryAnimator.GetBool ("IsOpen"));
	}

	public void AddItem(Item item) {
		for (int i = 0; i < items.Length; i++) {
			if (items[i] == null) {
				items [i] = item;
				itemImages [i].sprite = item.sprite;
				itemImages [i].enabled = true;
				notificationText.text = "You got " + item.name + "!";
				notificationAnimator.SetBool ("IsOpen", true);
				StartCoroutine (ShowNotification ());
				return;
			}
		}
	}

	IEnumerator ShowNotification () {
		yield return new WaitForSeconds (2);
		notificationAnimator.SetBool ("IsOpen", false);
		notificationText.text = "";
	}
}
