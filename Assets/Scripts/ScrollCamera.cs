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

	public void EnableCameraDragging () {
		Camera.main.GetComponent<DragCamera> ().enabled = true;
	}

	public void RemoveAnimator() {
		GameManagerBehavior.playedTutorial = true;
		GetComponent<Animator> ().enabled = false;
	}
}
