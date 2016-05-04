using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapSelectButtonAction : MonoBehaviour {

	public GameTypeManager gameTypeManager;
	public GameObject mapPreview;

	void Start() {
		gameTypeManager = GameObject.FindGameObjectWithTag ("SelectMapCanvas").GetComponent<GameTypeManager> ();
		if (gameObject.tag.Equals(Constant.SelectMap1Btn))
		{
			GetComponent<Image>().sprite = Resources.Load<Sprite>("map/map1_selected");
		}

		GetComponent<Button>().onClick.AddListener(() =>
			{
				var btnTag = gameObject.tag;
				if (btnTag.Equals(Constant.SelectMap1Btn)) {
					PlayerPrefs.SetString("Selected Map", "Map1");
					mapPreview.GetComponent<SelectGameMapPreview>().SetMapPreview(0);
					GameObject.Find("LevelText").GetComponent<Text>().text = "Desert";

					GetComponent<Image>().sprite = Resources.Load<Sprite>("map/map1_selected");
					GameObject.Find("map2_button").GetComponent<Image>().sprite = Resources.Load<Sprite>("map/map2");
					GameObject.Find("map3_button").GetComponent<Image>().sprite = Resources.Load<Sprite>("map/map3");
				} else if (btnTag.Equals(Constant.SelectMap2Btn)) {
					PlayerPrefs.SetString("Selected Map", "Map2");
					mapPreview.GetComponent<SelectGameMapPreview>().SetMapPreview(1);
					GameObject.Find("LevelText").GetComponent<Text>().text = "Wasteland";

					GetComponent<Image>().sprite = Resources.Load<Sprite>("map/map2_selected");
					GameObject.Find("map1_button").GetComponent<Image>().sprite = Resources.Load<Sprite>("map/map1");
					GameObject.Find("map3_button").GetComponent<Image>().sprite = Resources.Load<Sprite>("map/map3");
				} else if (btnTag.Equals(Constant.SelectMap3Btn)) {
					PlayerPrefs.SetString("Selected Map", "Map3");
					mapPreview.GetComponent<SelectGameMapPreview>().SetMapPreview(2);
					GameObject.Find("LevelText").GetComponent<Text>().text = "Canyon";

					GetComponent<Image>().sprite = Resources.Load<Sprite>("map/map3_selected");
					GameObject.Find("map2_button").GetComponent<Image>().sprite = Resources.Load<Sprite>("map/map2");
					GameObject.Find("map1_button").GetComponent<Image>().sprite = Resources.Load<Sprite>("map/map1");
				}
			});
	}

}
