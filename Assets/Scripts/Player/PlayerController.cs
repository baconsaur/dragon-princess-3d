using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
	public Camera camera;
	public NavMeshAgent navMeshAgent;

	public Animator dialogueAnimator;

	private InventoryManager inventorymanager;

	private Animator animator;
	private Vector3 previousPosition;

	void Start() {
		animator = GetComponent<Animator>();
		inventorymanager = FindObjectOfType<InventoryManager> ();
	}

	void Update() {
		if (!dialogueAnimator.GetBool ("IsOpen")) {
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				Ray ray = camera.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit)) {
					navMeshAgent.SetDestination (hit.point);
				}
			}
			UpdatePlayer ();
		}
	}

	public void OnTriggerStay(Collider other) {
		if (Input.GetButtonDown("Fire2") && !dialogueAnimator.GetBool ("IsOpen")) {
			if (other.CompareTag("NPC")) {
				NPC npc = other.GetComponent<NPC>();
				if (npc.dialogue != null) {
					npc.TriggerDialogue ();
				}
			}
			if (other.CompareTag("Chest")) {
				Chest npc = other.GetComponent<Chest>();
				if (npc.item != null) {
					npc.TriggerItem ();
				}
			}
		}
	}

	private void UpdatePlayer() {
		if (Input.GetButtonDown ("Cancel")) {
			inventorymanager.ToggleInventory ();
		}

		Vector3 currentPosition = transform.position - previousPosition;
		float currentSpeed = currentPosition.magnitude / Time.deltaTime;
		previousPosition = transform.position;

		Debug.Log (currentSpeed);

		bool shouldWalk = currentSpeed > 1f;
		bool shouldRun = currentSpeed > 3.8f;

		if (animator.GetBool("walking") != shouldWalk) {
			animator.SetBool("walking", shouldWalk);
		} else if (animator.GetBool("running") != shouldRun) {
			animator.SetBool("running", shouldRun);
		}
	}
}