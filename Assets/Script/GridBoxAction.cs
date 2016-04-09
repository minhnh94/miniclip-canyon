using UnityEngine;
using System.Collections;

public class GridBoxAction : MonoBehaviour {

	public bool isPressable;
	public GameObject currentMap;

	Vector3 mouseDownMapTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		mouseDownMapTransform = currentMap.transform.position;
		print("mouse down");
	}

	void OnMouseUpAsButton() {
		// Action goes here
		if (isPressable)
		{
			if (mouseDownMapTransform == currentMap.transform.position)
			{
				print("Pressed!");	
			}
		}
	}
}
