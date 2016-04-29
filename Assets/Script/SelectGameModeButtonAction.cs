using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectGameModeButtonAction : MonoBehaviour {
	void Start() {
		if (gameObject.tag.Equals(Constant.EasyModeBtn))
		{
			GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button_select");
		}

		GetComponent<Button>().onClick.AddListener(() =>
			{
				var difficultyText = GameObject.Find("DifficultyText").GetComponent<Text>();
				var btnTag = gameObject.tag;
				if (btnTag.Equals(Constant.EasyModeBtn)) {
					difficultyText.text = "Waves: 20\nDelay per wave: 2 min\nScore bonus: 0%";

					GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button_select");
					GameObject.Find("Button (2)").GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button");
					GameObject.Find("Button (1)").GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button");

					GameManagerBehavior.DifficultyBonus = 0;
					GameManagerBehavior.GameWaveLength = 20;
				} else if (btnTag.Equals(Constant.NormalModeBtn)) {
					difficultyText.text = "Waves: 30\nDelay per wave: 1.5 min\nScore bonus: 20%";

					GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button_select");
					GameObject.Find("Button (2)").GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button");
					GameObject.Find("Button").GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button");

					GameManagerBehavior.DifficultyBonus = 20;
					GameManagerBehavior.GameWaveLength = 30;
				} else if (btnTag.Equals(Constant.HardModeBtn)) {
					difficultyText.text = "Waves: 50\nDelay per wave: 1 min\nScore bonus: 50%";

					GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button_select");
					GameObject.Find("Button").GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button");
					GameObject.Find("Button (1)").GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button");

					GameManagerBehavior.DifficultyBonus = 50;
					GameManagerBehavior.GameWaveLength = 50;
				}
			});
	}
}
