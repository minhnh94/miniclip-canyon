using UnityEngine;
using System.Collections;

public class SellTowerButton : MonoBehaviour {

	public GameManagerBehavior gameManager;
	public MapManager mapManager;

	void OnClick () {
		GameObject selectedGridBox = mapManager.getSelectedGridBox ();
		selectedGridBox.GetComponent<GridBoxAction> ().isPressable = true;
		selectedGridBox.GetComponent<GridBoxAction> ().isSelected = false;

		GameObject selectedTower = selectedGridBox.transform.GetChild (2).gameObject;
		gameManager.Gold += Mathf.RoundToInt(selectedTower.GetComponent<TowerData> ().cost * 0.75f);
		Destroy (selectedTower);
	}
}
