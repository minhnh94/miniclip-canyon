using UnityEngine;
using System.Collections;

public class TutorialWeapons : MonoBehaviour {

	public void DisplayTutorial() {
		gameObject.GetComponent<Animator> ().SetTrigger ("displayTutorial");
	}
}
