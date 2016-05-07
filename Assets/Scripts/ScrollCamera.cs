using UnityEngine;
using System.Collections;

public class ScrollCamera : MonoBehaviour {

	public GameObject tutorialGoal;

	public void DisplayTutorialGoal() {
		tutorialGoal.GetComponent<TutorialGoal> ().DisplayTutorial ();
	}

	public void RemoveAnimator() {
		GetComponent<Animator> ().enabled = false;
	}
}
