using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RetryButtonAction : MonoBehaviour
{
	void Start()
	{
		GetComponent<Button>().onClick.AddListener(
			() =>
			{
				GameManagerBehavior.whatTowerIsPressed = -1;
				if (gameObject.tag == "RetryBtn")
				{
					if (PlayerPrefs.GetString("Selected Map") != "") {
						SceneManager.LoadScene(PlayerPrefs.GetString("Selected Map"));
					} else {
						SceneManager.LoadScene("Menu");
					}
				}
				else if (gameObject.tag == "QuitBtn")
				{
					SceneManager.LoadScene("Menu");
				}
			}
		);
	}
}
