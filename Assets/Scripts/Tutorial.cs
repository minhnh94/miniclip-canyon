using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject tutorialScreen;

	public void OnClick() {
		tutorialScreen.GetComponent<Tutorial> ().DisplayTutorial ();
	}

	public void DisplayTutorial() {
		gameObject.GetComponent<Animator> ().SetTrigger ("displayTutorial");
	}
}
