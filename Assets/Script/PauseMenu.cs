using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public static bool isPaused;
	public GameObject pauseMenuCanvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}
	}

	public void Resume(){
		isPaused = false;
	}

	public void Quit(){
		Application.LoadLevel ("Menu");
	}
}
