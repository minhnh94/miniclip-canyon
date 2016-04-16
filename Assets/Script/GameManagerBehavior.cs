using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour {

	public static int whatTowerIsPressed = -1;
	public GameObject[] towerButtons;
	public bool isShowingAdvanceButton;
	public Text goldLabel;

	private int gold;
	public int Gold {
		get { return gold; }
		set {
			gold = value;
			goldLabel.GetComponent<Text> ().text = "Gold: " + gold;
		}
	}

	// Use this for initialization
	void Start () {
		Gold = 500;
		Debug.Log (Gold);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToggleTowerButton() {
		if (isShowingAdvanceButton)
		{
			for (int i = 0; i < 5; i++)
			{
				var btn = towerButtons[i];
				btn.SetActive(false);
			}
			for (int i = 5; i < 10; i++)
			{
				var btn = towerButtons[i];
				btn.SetActive(true);
			}
		} else {
			for (int i = 0; i < 5; i++)
			{
				var btn = towerButtons[i];
				btn.SetActive(true);
			}
			for (int i = 5; i < 10; i++)
			{
				var btn = towerButtons[i];
				btn.SetActive(false);
			}
		}
	}
}
