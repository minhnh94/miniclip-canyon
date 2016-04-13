using UnityEngine;
using System.Collections;

public class BackgroundDragging : MonoBehaviour {

	Vector3 offset;
	float firstMousePosX;

	void OnMouseDown() {
		offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
		firstMousePosX = Input.mousePosition.x;
	}

	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(firstMousePosX, Input.mousePosition.y, 0);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		if (curPosition.y < 0)
		{
			// Bg is outta screen
			curPosition.y = 0;
		}
		else if (curPosition.y > 5.940788f)
		{
			curPosition.y = 5.940788f;
		}
		transform.position = curPosition;
	}


}
