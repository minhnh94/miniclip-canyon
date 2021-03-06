﻿using UnityEngine;
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
		ShowTutorialToggle.playedTutorial = true;
		Camera.main.GetComponent<Animator> ().enabled = false;
	}
}
