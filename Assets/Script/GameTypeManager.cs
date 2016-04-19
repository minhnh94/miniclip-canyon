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

	IEnumerator PlayStartGameSoundThenLoad(){
		AudioSource.PlayClipAtPoint(startGameSound, transform.position);
		yield return new WaitForSeconds(startGameSound.length);


		Application.LoadLevel("Map1");
	}


	public void StartGame() {
		StartCoroutine(PlayStartGameSoundThenLoad ());
	}
}
