using UnityEngine;
using System.Collections;

public class GridBoxAction : MonoBehaviour {

	public bool isPressable;
	public GameObject currentMap;

	Vector3 mouseDownMapTransform;

	void OnMouseDown() {
		mouseDownMapTransform = currentMap.transform.position;
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
