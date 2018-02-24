using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
	public string nextScene;

	private Animator fadeAnimator;

	public void Start() {
		fadeAnimator = FindObjectOfType<InventoryManager>().fadeAnimator;
	}

	public void OnTriggerEnter(Collider other) {
		StartCoroutine (FadeScene ());
	}

	IEnumerator FadeScene() {
		fadeAnimator.SetBool ("IsOut", true);

		AsyncOperation sceneLoad = SceneManager.LoadSceneAsync (nextScene);
		sceneLoad.allowSceneActivation = false;

		yield return new WaitForSeconds (0.5f);

		if (sceneLoad.progress < 0.9f) {
			yield return null;
		}

		sceneLoad.allowSceneActivation = true;
		fadeAnimator.SetBool ("IsOut", false);
	}
}
