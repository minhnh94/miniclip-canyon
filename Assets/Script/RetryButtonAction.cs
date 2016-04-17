using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class RetryButtonAction : MonoBehaviour, IPointerClickHandler {
	#region IPointerClickHandler implementation

	public void OnPointerClick(PointerEventData eventData)
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

	#endregion
}
