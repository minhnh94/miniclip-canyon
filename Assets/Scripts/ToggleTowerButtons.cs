using UnityEngine;
using System.Collections;

public class ToggleTowerButtons : MonoBehaviour {

	public GameManagerBehavior gameManager;
	public MapManager mapManager;

	void OnClick() {
		gameManager.isShowingAdvanceButton = !gameManager.isShowingAdvanceButton;
		gameManager.ToggleTowerButton();

		// Reset click state
		mapManager.ToggleGridPreview(false);
		if (GameManagerBehavior.whatTowerIsPressed != -1)
		{
			var btn = gameManager.towerButtons[GameManagerBehavior.whatTowerIsPressed];
			btn.GetComponent<BuildTower>().SetToNormalState();
			GameManagerBehavior.whatTowerIsPressed = -1;	
		}
	}

}
