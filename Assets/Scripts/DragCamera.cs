﻿using UnityEngine;
using System.Collections;

public class DragCamera : MonoBehaviour {

	public float dragSpeed = 2;
	private Vector3 dragOrigin;

	private Vector3 ResetCamera;
	private Vector3 Origin;
	private Vector3 Diference;
	private bool Drag=false;

	void Start () {
		ResetCamera = transform.position;
	}

	void LateUpdate () {
		if (Input.GetMouseButton (0)) {
			Diference=(Camera.main.ScreenToWorldPoint (Input.mousePosition))- Camera.main.transform.position;
			if (Drag==false){
				Drag=true;
				Origin=Camera.main.ScreenToWorldPoint (Input.mousePosition);
			}
		} else {
			Drag=false;
		}
		if (Drag==true){
			Camera.main.transform.position = Origin-Diference;
		}

		//RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
//		if (Input.GetMouseButton (1)) {
//			Camera.main.transform.position=ResetCamera;
//		}

		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, 0, 0),
			Mathf.Clamp(transform.position.y, -3.910183f, 3.859064f),
			Mathf.Clamp(transform.position.z, -10, -10));
	}
}
