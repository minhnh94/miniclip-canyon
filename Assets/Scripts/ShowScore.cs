using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text score = GetComponent<Text>();
		score.text = Mathf.FloorToInt(GameManagerBehavior.TotalScore).ToString();

		int highscore = PlayerPrefs.GetInt ("High score", 0);
		if (GameManagerBehavior.TotalScore > highscore) {
			PlayerPrefs.SetInt ("High score", Mathf.FloorToInt(GameManagerBehavior.TotalScore));
		}
	}
}
