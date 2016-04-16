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
					Debug.Log ("Before build");
					GameObject tower = (GameObject)Instantiate(towerPrefabs[GameManagerBehavior.whatTowerIsPressed], transform.position, Quaternion.identity);
					Debug.Log ("After build");
					Debug.Log (isPressable);
					tower.transform.SetParent(gameObject.transform);
					Debug.Log (gameManager.Gold);
					gameManager.Gold -= tower.GetComponent<TowerData>().cost;
					Debug.Log (gameManager.Gold);
					isPressable = false;
				}
			}
			isSelected = !isSelected;
		}
	}

	public bool CanBuildTower() {
		GameObject towerPrefab = towerPrefabs[GameManagerBehavior.whatTowerIsPressed];
		int cost = towerPrefab.GetComponent<TowerData>().cost;
		return isPressable && (gameManager.Gold >= cost);
	}
}
