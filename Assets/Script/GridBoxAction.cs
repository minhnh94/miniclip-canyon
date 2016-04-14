using UnityEngine;
using System.Collections;

public class GridBoxAction : MonoBehaviour {

	public bool isPressable;
	public GameObject currentMap;
	public GameObject towerPrefab;
	public GameManagerBehavior gameManager;

	Vector3 mouseDownMapTransform;

	void OnMouseDown() {
		mouseDownMapTransform = Camera.main.transform.position;
	}

	void OnMouseUpAsButton() {
		// Action goes here
		if (CanBuildTower())
		{
			Debug.Log (mouseDownMapTransform);
			Debug.Log (currentMap.transform.position);
			if (mouseDownMapTransform == currentMap.transform.position)
			{
				Debug.Log (GameManagerBehavior.whatTowerIsPressed);
				if (GameManagerBehavior.whatTowerIsPressed != 0)
				{
					print(GameManagerBehavior.whatTowerIsPressed);
					GameObject tower = (GameObject)Instantiate(towerPrefab, transform.position, Quaternion.identity);
					gameManager.Gold -= tower.GetComponent<TowerData> ().CurrentLevel.cost;
					isPressable = false;
				}
			}
		}
	}

	private bool CanBuildTower() {
		Debug.Log (towerPrefab.GetComponent<TowerData> ().levels [0].cost);
		Debug.Log (GameManagerBehavior.whatTowerIsPressed);
		int cost = towerPrefab.GetComponent<TowerData> ().levels[0].cost;
		return isPressable && (towerPrefab != null) && (gameManager.Gold >= cost);
	}
}
