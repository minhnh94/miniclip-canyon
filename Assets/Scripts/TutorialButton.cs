using UnityEngine;
using System.Collections;

public class TutorialButton : MonoBehaviour {

	public GameObject gameManager;
	public GameObject tutorialBasic;
	public GameObject tutorialAdvanced;

	public void OnClick() {
		if (!gameManager.GetComponent<GameManagerBehavior> ().isShowingAdvanceButton) {
			tutorialBasic.GetComponent<TutorialWeapons> ().DisplayTutorial ();
		} else {
			tutorialAdvanced.GetComponent<TutorialWeapons> ().DisplayTutorial ();
		}
	}
}
