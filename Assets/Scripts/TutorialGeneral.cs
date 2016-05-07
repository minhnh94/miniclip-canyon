using UnityEngine;
using System.Collections;

public class TutorialGeneral : MonoBehaviour {

	public void DisplayTutorial() {
		gameObject.GetComponent<Animator> ().SetTrigger ("displayTutorial");
	}
}
