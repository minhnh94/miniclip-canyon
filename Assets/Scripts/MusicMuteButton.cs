using UnityEngine;
using UnityEngine.UI;

public class MusicMuteButton : MonoBehaviour {

	public GameObject btnSprite;

	// Use this for initialization
	void Start () {
		btnSprite.GetComponent<Text>().text = !GameManagerBehavior.MusicMute ? "MUSIC: ON" : "MUSIC: OFF";

		GetComponent<Button>().onClick.AddListener(() => {
			GameManagerBehavior.MusicMute = !GameManagerBehavior.MusicMute;
			if (GameManagerBehavior.MusicMute)
			{
				btnSprite.GetComponent<Text>().text = "MUSIC: OFF";
			}
			else
			{
				btnSprite.GetComponent<Text>().text = "MUSIC: ON";
			}
		});
	}
}
