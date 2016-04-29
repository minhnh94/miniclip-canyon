using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var highscore = GetComponent<Text>();
		highscore.text = Mathf.FloorToInt(GameManagerBehavior.TotalScore).ToString();
	}
}
