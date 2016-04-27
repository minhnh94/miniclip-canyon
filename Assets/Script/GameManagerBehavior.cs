using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
			if (health == 0)
			{
				SceneManager.LoadScene("GameOverScene");
			}
		}
	}

	public GameObject[] nextWaveLabels;
	public bool gameOver = false;

	private int wave;
	public int Wave {
		get { return wave; }
		set {
			wave = value;
			if (!gameOver) {
				for (int i = 0; i < nextWaveLabels.Length; i++) {
					nextWaveLabels [i].GetComponent<Text> ().text = "Wave " + (value + 1);
//					Debug.Log (nextWaveLabels [i].GetComponent<Text> ().text);
//					Debug.Log (nextWaveLabels [i].GetComponent<Animator> ());
					nextWaveLabels [i].GetComponent<Animator> ().SetTrigger ("nextWave");
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		Gold = 1000;
		Health = 10;
		Wave = 0;
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
