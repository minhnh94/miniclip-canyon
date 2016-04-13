using UnityEngine;
using System.Collections;

public class DragCamera : MonoBehaviour {

	public float dragSpeed = 2;
	private Vector3 dragOrigin;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			dragOrigin = Input.mousePosition;
			return;
		}

		if (!Input.GetMouseButton(0)) return;

		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
		Vector3 move = new Vector3(0 , pos.y * dragSpeed, 0);
		transform.Translate(move, Space.World);  

		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, 0, 0),
			Mathf.Clamp(transform.position.y, -3.910183f, 3.859064f),
			Mathf.Clamp(transform.position.z, -10, -10));
	}
}
