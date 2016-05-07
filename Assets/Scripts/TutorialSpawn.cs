using UnityEngine;
using System.Collections;

public class TutorialSpawn : MonoBehaviour {

	public void ScrollScreen () {
		Camera.main.GetComponent<Animator> ().SetTrigger ("scrollScreen");
	}
}
