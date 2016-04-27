using UnityEngine;
using System.Collections;

public class SellTowerButton : MonoBehaviour {

	public GameManagerBehavior gameManager;
	public MapManager mapManager;

	void OnClick () {
		GameObject selectedGridBox = mapManager.getSelectedGridBox ();
		Debug.Log (selectedGridBox);
		selectedGridBox.GetComponent<GridBoxAction> ().isPressable = true;
		selectedGridBox.GetComponent<GridBoxAction> ().isSelected = false;
		Debug.Log (selectedGridBox);

		GameObject selectedTower = selectedGridBox.transform.GetChild (2).gameObject;
		Debug.Log (selectedTower);
		gameManager.Gold += Mathf.RoundToInt(selectedTower.GetComponent<TowerData> ().cost * 0.75f);
		Destroy (selectedTower);
	}
}
