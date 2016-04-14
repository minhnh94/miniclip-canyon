using UnityEngine;
using System.Collections;

public class GridBoxAction : MonoBehaviour {

	public bool isPressable;
	public GameObject currentMap;
	public GameObject towerPrefab;
	public GameManagerBehavior gameManager;

	Vector3 mouseDownMapTransform;

	void OnMouseDown() {
		mouseDownMapTransform = currentMap.transform.position;
	}

	void OnMouseUpAsButton() {
		// Action goes here
		if (CanBuildTower())
		{
			if (mouseDownMapTransform == currentMap.transform.position)
			{
				if (GameManagerBehavior.whatTowerIsPressed != 0)
				{
					print(GameManagerBehavior.whatTowerIsPressed);
					GameObject tower = (GameObject)Instantiate(towerPrefab, transform.position, Quaternion.identity);
					gameManager.Gold -= tower.GetComponent<TowerData>().cost;
					isPressable = false;
				}
			}
		}
	}

	bool CanBuildTower() {
		int cost = towerPrefab.GetComponent<TowerData> ().cost;
		return isPressable && (towerPrefab != null) && (gameManager.Gold >= cost);
	}
}
