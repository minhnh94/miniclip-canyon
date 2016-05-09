using UnityEngine;
using System.Collections;

public class MusicMuteButton : MonoBehaviour {

	public GameObject backgroundSprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick() {
		GameManagerBehavior.MusicMute = !GameManagerBehavior.MusicMute;
		if (GameManagerBehavior.MusicMute)
		{
			backgroundSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icon/music_mute");
		}
		else
		{
			backgroundSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icon/music");
		}
	}
}
