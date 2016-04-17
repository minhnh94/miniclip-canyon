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
	public MapManager mapManager;
	public GameObject[] towerPrefabs;
	private GameObject tower;

	Vector3 mouseDownMapTransform;

	void Start() {
		mapManager = GameObject.Find ("MapManager").GetComponent<MapManager> ();
	}

	void OnMouseDown() {
		mouseDownMapTransform = Camera.main.transform.position;
	}

	void OnMouseUpAsButton() {
		// Action goes here
		if (mouseDownMapTransform == Camera.main.transform.position)
		{
			isSelected = !isSelected;

			if (GameManagerBehavior.whatTowerIsPressed != -1)
			{
				if (CanBuildTower())
				{
					tower = (GameObject)Instantiate(towerPrefabs[GameManagerBehavior.whatTowerIsPressed], transform.position, Quaternion.identity);
					tower.transform.SetParent(gameObject.transform);
					gameManager.Gold -= tower.GetComponent<TowerData>().cost;
					isPressable = false;
					isSelected = false;
				}
			}

			if (isSelected) {
				mapManager.deactivateOtherGridBox ();
				isSelected = true;
			}
		}
	}

	public bool CanBuildTower() {
		GameObject towerPrefab = towerPrefabs[GameManagerBehavior.whatTowerIsPressed];
		int cost = towerPrefab.GetComponent<TowerData>().cost;
		return isPressable && (gameManager.Gold >= cost);
	}
}
