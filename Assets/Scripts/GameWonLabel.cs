using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameWonLabel : MonoBehaviour {

	public void LoadGameOverScene () {
		SceneManager.LoadScene("GameOverScene");;
	}
}
