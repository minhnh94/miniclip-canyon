using UnityEngine;
using System.Collections;

public class GameTypeManager : MonoBehaviour {
	
	public GameObject selectMenuCanvas;
	public AudioClip startGameSound;
	private string selectedMap;
	public string SelectedMap {
		get { return selectedMap; }
		set {
			selectedMap = value;
		}
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator PlayStartGameSoundThenLoad(){
		AudioSource.PlayClipAtPoint(startGameSound, transform.position);
		yield return new WaitForSeconds(startGameSound.length);

		Application.LoadLevel(SelectedMap);
	}


	public void StartGame() {
		StartCoroutine(PlayStartGameSoundThenLoad ());
	}
}
