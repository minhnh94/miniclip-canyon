using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridBoxAction : MonoBehaviour {

	public bool isSelected = false;
	public bool isPressable;
	public int indexInMapManagerArray;

	public GameObject normalRender;
	public GameObject towerPreviewRender;
	public GameObject currentMap;
	public GameManagerBehavior gameManager;
	public MapManager mapManager;
	public GameObject[] towerPrefabs;

	public AudioClip placeTowerSound;

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
		if (UICamera.hoveredObject == null) {
			if (mouseDownMapTransform == Camera.main.transform.position) {
				isSelected = !isSelected;

				if (GameManagerBehavior.whatTowerIsPressed != -1) {
					if (CanBuildTower ()) {
						PlayPlaceTowerSound ();

						tower = (GameObject)Instantiate (towerPrefabs [GameManagerBehavior.whatTowerIsPressed], transform.position, Quaternion.identity);
						tower.transform.SetParent (gameObject.transform);
						gameManager.Gold -= tower.GetComponent<TowerData> ().cost;
						isPressable = false;
						isSelected = false;

						// Delete the preview grid
						towerPreviewRender.SetActive (false);
					} else {
						if (!isPressable) {
							mapManager.ToggleGridPreview (false);
							var btn = gameManager.towerButtons [GameManagerBehavior.whatTowerIsPressed];
							btn.GetComponent<BuildTower> ().SetToNormalState ();
							GameManagerBehavior.whatTowerIsPressed = -1;
						}
					}
				}

				if (isSelected) {
					if (gameObject.transform.childCount == 2) {
						isSelected = false;
						return;
					}
					mapManager.deactivateOtherGridBox ();
					isSelected = true;
				}
			}
		}
	}

	void PlayPlaceTowerSound(){

		AudioSource.PlayClipAtPoint(placeTowerSound, transform.position);
	}


	public bool CanBuildTower() {
		GameObject towerPrefab = towerPrefabs[GameManagerBehavior.whatTowerIsPressed];
		int cost = towerPrefab.GetComponent<TowerData>().cost;
		return isPressable && (gameManager.Gold >= cost);
	}
}
