using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public Button[] responseText;

	public Animator dialogueAnimator;

	private Queue<string> sentences;
	private Response[] responses;
	private InventoryManager inventoryManager;

	void Start () {
		sentences = new Queue<string> ();
		inventoryManager = FindObjectOfType<InventoryManager> ();
	}

	public void StartDialogue(Dialogue dialogue) {
		dialogueAnimator.SetBool ("IsOpen", true);

		if (dialogue.reward != null) {
			inventoryManager.AddItem (dialogue.reward);
		}

		nameText.text = dialogue.name;
		if (dialogue.responses.Length > 0) {
			responses = dialogue.responses;
		} else {
			responses = null;
		}

		sentences.Clear ();

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}

		DisplayNextSentence ();
	}

	public void DisplayNextSentence() {
		if (sentences.Count == 0) {
			if (responses == null) {
				EndDialogue ();
				return;
			}
			ShowResponses ();
			return;
		}

		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
	}

	public void ShowResponses() {
		for (int i = 0; i < responses.Length; i++) {
			responseText[i].GetComponentInChildren<Text>().text = responses [i].sentence;
			// Show button
			responseText[i].gameObject.SetActive(true);
		}
	}


	public void Respond(int responseIndex) {
		HideResponses ();
		StartDialogue (responses [responseIndex].nextDialogue);
	}

	IEnumerator TypeSentence (string sentence) {
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return null;
		}
	}

	void HideResponses() {
		for (int i = 0; i < responseText.Length; i++) {
			responseText[i].GetComponentInChildren<Text>().text = "";
			// Hide button
			responseText[i].gameObject.SetActive(false);
		}
	}

	void EndDialogue() {
		dialogueAnimator.SetBool ("IsOpen", false);
		HideResponses ();
	}
}
