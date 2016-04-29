using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectGameModeButtonAction : MonoBehaviour {
	void Start() {
		if (gameObject.tag.Equals(Constant.EasyModeBtn))
		{
			GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button_select");
			// Default is easy
			GameManagerBehavior.DifficultyBonus = 0;
			GameManagerBehavior.GameWaveLength = 20;
		}

		GetComponent<Button>().onClick.AddListener(() =>
			{
				var difficultyText = GameObject.Find("DifficultyText").GetComponent<Text>();
				var btnTag = gameObject.tag;
				if (btnTag.Equals(Constant.EasyModeBtn)) {
					difficultyText.text = "Waves: 20\nEnemy HP bonus: 0%\nBounty bonus: 0%";

					GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button_select");
					GameObject.Find("Button (2)").GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button");
					GameObject.Find("Button (1)").GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button");

					GameManagerBehavior.DifficultyBonus = 1.0f;
					GameManagerBehavior.GameWaveLength = 20;
				} else if (btnTag.Equals(Constant.NormalModeBtn)) {
					difficultyText.text = "Waves: 30\nEnemy HP bonus: +50%\nBounty bonus: +10%";

					GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button_select");
					GameObject.Find("Button (2)").GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button");
					GameObject.Find("Button").GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button");

					GameManagerBehavior.DifficultyBonus = 1.5f;
					GameManagerBehavior.GameWaveLength = 30;
				} else if (btnTag.Equals(Constant.HardModeBtn)) {
					difficultyText.text = "Waves: 50\nEnemy HP bonus: +100%\nBounty bonus: 20%";

					GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button_select");
					GameObject.Find("Button").GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button");
					GameObject.Find("Button (1)").GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/border_button");

					GameManagerBehavior.DifficultyBonus = 2.0f;
					GameManagerBehavior.GameWaveLength = 50;
				}
			});
	}
}
