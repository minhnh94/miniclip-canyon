using UnityEngine;
using UnityEngine.UI;

public class VibrateMuteButton : MonoBehaviour {

	public GameObject btnSprite;

	// Use this for initialization
	void Start () {
		btnSprite.GetComponent<Text>().text = !GameManagerBehavior.VibrateMute ? "VIBRATE: ON" : "VIBRATE: OFF";

		GetComponent<Button>().onClick.AddListener(() => {
			GameManagerBehavior.VibrateMute = !GameManagerBehavior.VibrateMute;
			if (GameManagerBehavior.VibrateMute)
			{
				btnSprite.GetComponent<Text>().text = "VIBRATE: OFF";
			}
			else
			{
				btnSprite.GetComponent<Text>().text = "VIBRATE: ON";
			}
		});
	}
}
