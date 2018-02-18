using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

	public Item item;

	private InventoryManager inventoryManager;

	public void Start() {
		inventoryManager = FindObjectOfType<InventoryManager>();
	}

	public void TriggerItem() {
		inventoryManager.AddItem (item);
		item = null;
	}
}
