using UnityEngine;
using System.Collections;

public class TutorialGoal : MonoBehaviour {

	public GameObject gameManager;

	public void DisplayWaveLabels () {
		gameManager.GetComponent<GameManagerBehavior> ().DisplayWaveLabels ();
	}

	public void DisplayTutorial () {
		gameObject.GetComponent<Animator> ().SetTrigger ("displayTutorial");
	}
}
