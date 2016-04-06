using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class MapManager : MonoBehaviour
{

	public GameObject gridBoxSample;
	public GameObject currentMap;

	Grid[,] gridData = new Grid[14, 14];

	// Use this for initialization
	void Start()
	{
		createGridMapData();
		createGrid();
	}
	
	// Update is called once per frame
	void Update()
	{
	
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
		for (int i = 0; i < 14; i++)
		{
			for (int j = 0; j < 14; j++)
			{
				GameObject nobj = GameObject.Instantiate(gridBoxSample);

				if (gridData[i, j].isBuildable)
				{
					nobj.GetComponent<GridBoxAction>().isPressable = true;
				}

				nobj.transform.SetParent(currentMap.transform);

				float gridSize = nobj.GetComponent<Renderer>().bounds.size.x;

//				nobj.transform.position = new Vector2(gridBoxSample.transform.position.x + gridSize * j, gridBoxSample.transform.position.y - (gridSize * i));
				nobj.transform.localPosition = new Vector2(-190+gridSize * j, 191-gridSize * i);

				nobj.SetActive(true);
			}
		}
	}

	#endregion
}
