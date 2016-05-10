using UnityEngine;
using UnityEngine.SceneManagement;
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

	public void Restart(){
		if (PlayerPrefs.GetString("Selected Map") != "") {
			SceneManager.LoadScene(PlayerPrefs.GetString("Selected Map"));
		} else {
			SceneManager.LoadScene("Menu");
		}
		isPaused = false;
	}

	public void Quit(){
		SceneManager.LoadScene("Menu");
		isPaused = false;
	}
}
