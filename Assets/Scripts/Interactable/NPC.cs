using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
	
	public Dialogue dialogue;

	private DialogueManager dialogueManager;

	public void Start() {
		dialogueManager = FindObjectOfType<DialogueManager>();
	}

	public void TriggerDialogue() {
		dialogueManager.StartDialogue (dialogue);
	}
}
