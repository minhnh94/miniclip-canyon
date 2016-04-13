using UnityEngine;
using System.Collections;

public class GridBoxAction : MonoBehaviour {

	public bool isPressable;
	public GameObject currentMap;
	public GameObject towerPrefab;

	Vector3 mouseDownMapTransform;

	void OnMouseDown() {
		mouseDownMapTransform = Camera.main.transform.position;
	}

	void OnMouseUpAsButton() {
		// Action goes here
		if (isPressable)
		{
			if (mouseDownMapTransform == Camera.main.transform.position)
			{
				if (TowerDefenseManager.whatTowerIsPressed != 0)
				{
					print(TowerDefenseManager.whatTowerIsPressed);
					GameObject tower = (GameObject)Instantiate(towerPrefab, transform.position, Quaternion.identity);

					isPressable = false;
				}
			}
		}
	}
}
