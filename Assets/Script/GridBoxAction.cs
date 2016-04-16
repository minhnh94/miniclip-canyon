using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridBoxAction : MonoBehaviour {

	public bool isSelected = false;
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
					tower.transform.SetParent(gameObject.transform);
					gameManager.Gold -= tower.GetComponent<TowerData>().cost;
					isPressable = false;
				}
			}
		}
		isSelected = !isSelected;
	}

	bool CanBuildTower() {
		GameObject towerPrefab = towerPrefabs[GameManagerBehavior.whatTowerIsPressed];
		int cost = towerPrefab.GetComponent<TowerData>().cost;
		return isPressable && (gameManager.Gold >= cost);
	}
}
