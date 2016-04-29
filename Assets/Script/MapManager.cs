using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;

public class MapManager : MonoBehaviour
{
	public GameObject gridBoxSample;
	public GameObject currentMap;
	public Camera mainCamera;

	Grid[,] gridData = new Grid[14, 14];
	List<GameObject> gridPrefabs = new List<GameObject>();

	public GameObject sellButton;

	// Use this for initialization
	void Start()
	{
		createGridMapData();
		createGrid();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (getSelectedGridBox () != null) {
			sellButton.SetActive (true);
		} else {
			sellButton.SetActive (false);
		}
	}

	public void ToggleGridPreview(bool isTurnedOn) {
		if (isTurnedOn)
		{
			foreach (var grid in gridPrefabs)
			{
				var gridAction = grid.GetComponent<GridBoxAction>();
				gridAction.towerPreviewRender.SetActive(gridAction.isPressable);
			}
		}
		else
		{
			foreach (var grid in gridPrefabs)
			{
				var gridAction = grid.GetComponent<GridBoxAction>();
				gridAction.towerPreviewRender.SetActive(false);
			}
		}
	}

	public void deselectOtherGridBox() {
		foreach (var grid in gridPrefabs) {
			var gridAction = grid.GetComponent<GridBoxAction> ();
			gridAction.isSelected = false;
		}
	}

	public bool hasSelectedGridBox() {
		foreach (var grid in gridPrefabs) {
			var gridAction = grid.GetComponent<GridBoxAction> ();
			if (gridAction.isSelected == true)
				return true;
		}
		return false;
	}

	public GameObject getSelectedGridBox() {
		foreach (var grid in gridPrefabs) {
			var gridAction = grid.GetComponent<GridBoxAction> ();
			if (gridAction.isSelected == true)
				return grid;
		}
		return null;
	}

	public float getBuiltTowersCost() {
		float result = 0f;
		foreach (var grid in gridPrefabs) {
			if (grid.transform.childCount != 2) {
				GameObject tower = grid.transform.GetChild (2).gameObject;
				result += tower.GetComponent<TowerData> ().cost;
			}
		}
		return result;
	}

	#region Private inits

	void createGridMapData()
	{
		var reader = new StreamReader("Assets/Script/Map1.txt");

		int i = 0;
		string line;
		while ((line = reader.ReadLine()) != null)
		{
			string[] points = line.Split(',');

			for (int j = 0; j < points.Length; j++) {
				gridData[i, j] = points[j] == "0" ? new Grid(false) : new Grid(true);
			}

			i++;
		}
	}

	void createGrid()
	{
		int index = 0;
		for (int i = 0; i < 14; i++)
		{
			for (int j = 0; j < 14; j++)
			{
				GameObject grid = (GameObject)Instantiate(gridBoxSample);
				gridPrefabs.Add(grid);
				grid.GetComponent<GridBoxAction>().towerPreviewRender.SetActive(false);
				grid.GetComponent<GridBoxAction>().indexInMapManagerArray = index;
				grid.name = i + "," + j;

				grid.GetComponent<GridBoxAction>().currentMap = currentMap;
				grid.GetComponent<GridBoxAction>().isPressable |= gridData[i, j].isBuildable;
//				grid.GetComponent<BoxCollider2D>().enabled = !gridData[i, j].isRoad;
				grid.GetComponent<GridBoxAction>().gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
				grid.GetComponent<GridBoxAction>().mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();

//				grid.transform.parent = currentMap.transform;

//				float gridSize = grid.GetComponent<Renderer>().bounds.size.x;
				float gridSize = grid.GetComponent<GridBoxAction>().normalRender.GetComponent<Renderer>().bounds.size.x;
				float mapSize = currentMap.GetComponent<Renderer>().bounds.size.x;

				grid.transform.position = new Vector2(-mapSize / 2 + gridSize / 2 + gridSize * j, mapSize / 2 - gridSize / 2 - (gridSize * i));
				grid.SetActive(true);
				index++;
			}
		}
	}

	#endregion
}
