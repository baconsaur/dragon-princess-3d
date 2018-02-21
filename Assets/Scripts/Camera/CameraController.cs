using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 lastPosition;

	void Start() {
		lastPosition = player.transform.position;
	}

	void Update () {
		Vector3 diff = player.transform.position - lastPosition;
		transform.position += diff;
		lastPosition = player.transform.position;
	}
}
