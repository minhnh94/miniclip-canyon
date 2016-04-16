using UnityEngine;
using System.Collections;

public class ToggleTowerButtons : MonoBehaviour {

	public GameManagerBehavior gameManager;

	void OnClick() {
		gameManager.isShowingAdvanceButton = !gameManager.isShowingAdvanceButton;
		gameManager.ToggleTowerButton();
	}

}
