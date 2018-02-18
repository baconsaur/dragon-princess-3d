using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName="New Dialogue", menuName="Dialogue")]
public class Dialogue : ScriptableObject {
	public string name;

	[TextArea(3, 10)]
	public string[] sentences;

	public Response[] responses;

	public Item reward;
}
