using UnityEngine;
using System.Collections;

public class PixelPerfectCamera : MonoBehaviour {

//	public float pixelToUnits = 1f;
//	public float scale = 1f;
//
//    public Vector2 nativeResolution = new Vector2(1136, 640);

	public float targetRatio;

	// Use this for initialization
	void Awake () {
		Camera cam = GetComponent<Camera>();
		cam.aspect = targetRatio;
	}
}
