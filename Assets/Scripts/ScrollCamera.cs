using UnityEngine;
using System.Collections;

public class ScrollCamera : MonoBehaviour {

	public GameObject tutorialGoal;
	public GameObject tutorialGeneral;

	public void DisplayTutorialGoal() {
		tutorialGoal.GetComponent<TutorialGoal> ().DisplayTutorial ();
	}

	public void DisplayTutorialGeneral() {
		tutorialGeneral.GetComponent<TutorialGeneral> ().DisplayTutorial ();
	}

	public void RemoveAnimator() {
		GetComponent<Animator> ().enabled = false;
	}
}
