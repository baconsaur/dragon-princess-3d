using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName="New Response", menuName="Response")]
public class Response : ScriptableObject {

	[TextArea(3, 10)]
	public string sentence;

	public Dialogue nextDialogue;
}
