using UnityEngine;
using System.Collections;

public class BackgroundDragging : MonoBehaviour {

	Vector3 screenPoint;
	Vector3 offset;
	float firstMousePosX;

	void OnMouseDown() {
		offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		firstMousePosX = Input.mousePosition.x;
	}

	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(firstMousePosX, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		if (curPosition.y < 0)
		{
			// Bg is outta screen
			curPosition.y = 0;
		}
		transform.position = curPosition;
	}

}
