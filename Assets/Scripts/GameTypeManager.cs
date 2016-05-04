using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameTypeManager : MonoBehaviour {
	
	public GameObject selectMenuCanvas;
	public AudioClip startGameSound;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator PlayStartGameSoundThenLoad(){
		AudioSource.PlayClipAtPoint(startGameSound, transform.position);
		yield return new WaitForSeconds(startGameSound.length);

		if (PlayerPrefs.GetString("Selected Map") != "") {
			SceneManager.LoadScene(PlayerPrefs.GetString("Selected Map"));
		} else {
			SceneManager.LoadScene("Menu");
		}
	}


	public void StartGame() {
		StartCoroutine(PlayStartGameSoundThenLoad ());
	}
}
