using UnityEngine;
using UnityEngine.UI;

public class AudioMuteButton : MonoBehaviour {

	public GameObject btnSprite;

	// Use this for initialization
	void Start () {
		btnSprite.GetComponent<Text>().text = !GameManagerBehavior.AudioMute ? "SOUND: ON" : "SOUND: OFF";

		GetComponent<Button>().onClick.AddListener(() => {
			GameManagerBehavior.AudioMute = !GameManagerBehavior.AudioMute;
			if (GameManagerBehavior.AudioMute)
			{
				btnSprite.GetComponent<Text>().text = "SOUND: OFF";
			}
			else
			{
				btnSprite.GetComponent<Text>().text = "SOUND: ON";
			}
		});
	}
}
