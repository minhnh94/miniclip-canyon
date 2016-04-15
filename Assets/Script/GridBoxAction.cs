using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridBoxAction : MonoBehaviour {

	public bool isPressable;
	public GameObject normalRender;
	public GameObject towerPreviewRender;
	public GameObject currentMap;
	public GameManagerBehavior gameManager;
	public GameObject[] towerPrefabs;

	Vector3 mouseDownMapTransform;

	void OnMouseDown() {
		mouseDownMapTransform = Camera.main.transform.position;
	}

	void OnMouseUpAsButton() {
		// Action goes here
		if (mouseDownMapTransform == Camera.main.transform.position)
		{
			if (GameManagerBehavior.whatTowerIsPressed != -1)
			{
				if (CanBuildTower())
				{
					GameObject tower = (GameObject)Instantiate(towerPrefabs[GameManagerBehavior.whatTowerIsPressed], transform.position, Quaternion.identity);
					gameManager.Gold -= tower.GetComponent<TowerData>().cost;
					isPressable = false;
				}
			}
		}
	}

	bool CanBuildTower() {
		GameObject towerPrefab = towerPrefabs[GameManagerBehavior.whatTowerIsPressed];
		int cost = towerPrefab.GetComponent<TowerData>().cost;
		return isPressable && (gameManager.Gold >= cost);
	}
}
