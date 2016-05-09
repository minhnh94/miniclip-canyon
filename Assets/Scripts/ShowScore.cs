using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

	public Text scorePhrase;

	// Use this for initialization
	void Start () {
		string playerName = GameManagerBehavior.PlayerName;
		if (playerName == "") {
			playerName = "Player";
		}
		HighScoreManager._instance.SaveHighScore(playerName, Mathf.FloorToInt(GameManagerBehavior.TotalScore));
		if (Mathf.FloorToInt (GameManagerBehavior.TotalScore) == HighScoreManager._instance.GetHighScore () [0].score) {
			scorePhrase.text = "New High Score!";
		} else {
			scorePhrase.text = "Your Score";
		}

		Text score = GetComponent<Text>();
		score.text = Mathf.FloorToInt(GameManagerBehavior.TotalScore).ToString();
	}
}
