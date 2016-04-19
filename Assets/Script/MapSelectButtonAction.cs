using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapSelectButtonAction : MonoBehaviour {

	public GameObject mapPreview;

	void Start() {
		GetComponent<Button>().onClick.AddListener(() =>
			{
				var btnTag = gameObject.tag;
				if (btnTag.Equals(Constant.SelectMap1Btn)) {
					mapPreview.GetComponent<SelectGameMapPreview>().SetMapPreview(0);
					GameObject.Find("LevelText").GetComponent<Text>().text = "Desert";
				} else if (btnTag.Equals(Constant.SelectMap2Btn)) {
					mapPreview.GetComponent<SelectGameMapPreview>().SetMapPreview(1);
					GameObject.Find("LevelText").GetComponent<Text>().text = "Wasteland";
				} else if (btnTag.Equals(Constant.SelectMap3Btn)) {
					mapPreview.GetComponent<SelectGameMapPreview>().SetMapPreview(2);
					GameObject.Find("LevelText").GetComponent<Text>().text = "Canyon";
				}
			});
	}

}
