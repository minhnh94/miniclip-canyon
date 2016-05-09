using UnityEngine;
using System.Collections;

public class TutorialSpawn : MonoBehaviour {

	public void DisableCameraDragging () {
		Camera.main.GetComponent<DragCamera> ().enabled = false;
	}

	public void ScrollScreen () {
		Camera.main.GetComponent<Animator> ().SetTrigger ("scrollScreen");
	}
}
