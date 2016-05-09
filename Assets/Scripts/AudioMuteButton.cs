using UnityEngine;
using System.Collections;

public class AudioMuteButton : MonoBehaviour {

	public GameObject backgroundSprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick() {
		GameManagerBehavior.AudioMute = !GameManagerBehavior.AudioMute;
		if (GameManagerBehavior.AudioMute)
		{
			backgroundSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icon/audio_mute");
		}
		else
		{
			backgroundSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icon/audio");
		}
	}
}
