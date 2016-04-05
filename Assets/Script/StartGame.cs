using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	void OnMouseDown() {
		print ("clicked");
		Application.LoadLevel("Map1");
	}
}
