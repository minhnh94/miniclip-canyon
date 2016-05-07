using UnityEngine;
using System.Collections;

public class TutorialButton : MonoBehaviour {

	public GameObject tutorialScreen;

	public void OnClick() {
		tutorialScreen.GetComponent<TutorialButton> ().DisplayTutorial ();
	}

	public void DisplayTutorial() {
		gameObject.GetComponent<Animator> ().SetTrigger ("displayTutorial");
	}
}
