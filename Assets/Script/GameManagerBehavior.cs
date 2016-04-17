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
			goldLabel.GetComponent<Text> ().text = "" + gold;
		}
	}

	public Text healthLabel;
	private int health;
	public int Health {
		get {
			return health;
		}
		set {
			if (value < health) {
				Camera.main.GetComponent<CameraShake> ().Shake ();
			}
			health = value;
			healthLabel.GetComponent<Text> ().text = "" + health;
			Debug.Log (healthLabel.GetComponent<Text> ().text);
		}
	}

	private int wave;
	public int Wave {
		get { return wave; }
		set {
			wave = value;
		}
	}

	// Use this for initialization
	void Start () {
		Gold = 500;
		Health = 5;
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
