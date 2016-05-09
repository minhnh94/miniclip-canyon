using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public void StartSelectMap() {
		print ("clicked");
		Application.LoadLevel("SelectMap");
	}

	public void GoToOption() {
		SceneManager.LoadScene("OptionScene");
	}
}
