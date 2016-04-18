using UnityEngine;
using System.Collections;

public class GameTypeManager : MonoBehaviour {

	// Use this for initialization

	public GameObject selectMenuCanvas;
	public AudioClip startGameSound;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PlayStartGameSound(){
		AudioSource.PlayClipAtPoint(startGameSound, transform.position);
	}


	public void StartGame() {
		PlayStartGameSound ();
		Application.LoadLevel("Map1");
	}
}
