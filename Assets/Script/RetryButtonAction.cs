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
				if (gameObject.tag == "RetryBtn")
				{
					SceneManager.LoadScene("Map1");
				}
				else if (gameObject.tag == "QuitBtn")
				{
					SceneManager.LoadScene("Menu");
				}
			}
		);
	}
}
