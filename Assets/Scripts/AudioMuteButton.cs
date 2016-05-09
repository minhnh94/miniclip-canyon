using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

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
				AudioMixer mixer = Resources.Load<AudioMixer>("etc/AudioMixer");
				mixer.SetFloat("audioVolume", -70);
			}
			else
			{
				btnSprite.GetComponent<Text>().text = "SOUND: ON";
				AudioMixer mixer = Resources.Load<AudioMixer>("etc/AudioMixer");
				mixer.SetFloat("audioVolume", 0);
			}
		});
	}
}
