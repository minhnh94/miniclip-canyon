using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectGameModeButtonAction : MonoBehaviour {
	void Start() {
		GetComponent<Button>().onClick.AddListener(() =>
			{
				var difficultyText = GameObject.Find("DifficultyText").GetComponent<Text>();
				var btnTag = gameObject.tag;
				if (btnTag.Equals(Constant.EasyModeBtn)) {
					difficultyText.text = "Waves: 20\nDelay per wave: 2 min\nScore bonus: 0%";
				} else if (btnTag.Equals(Constant.NormalModeBtn)) {
					difficultyText.text = "Waves: 30\nDelay per wave: 1.5 min\nScore bonus: 20%";
				} else if (btnTag.Equals(Constant.HardModeBtn)) {
					difficultyText.text = "Waves: 50\nDelay per wave: 1 min\nScore bonus: 50%";
				}
			});
	}
}
