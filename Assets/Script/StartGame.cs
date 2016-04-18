using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public void StartSelectMap() {
		print ("clicked");
		Application.LoadLevel("SelectMap");
	}
}
