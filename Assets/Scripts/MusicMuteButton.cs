using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

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
				AudioMixer mixer = Resources.Load<AudioMixer>("etc/AudioMixer");
				mixer.SetFloat("musicVolume", -40);
			}
			else
			{
				btnSprite.GetComponent<Text>().text = "MUSIC: ON";
				AudioMixer mixer = Resources.Load<AudioMixer>("etc/AudioMixer");
				mixer.SetFloat("musicVolume", 0);
			}
		});
	}
}
