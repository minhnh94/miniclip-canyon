using UnityEngine;
using System.Collections;

public class GameTypeManager : MonoBehaviour {

	// Use this for initialization

	public GameObject selectMenuCanvas;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void StartGame() {
		Application.LoadLevel("Map1");
	}
}
