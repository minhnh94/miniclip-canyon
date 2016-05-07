using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour {

	public MapManager mapManager;

	public static float DifficultyBonus;
	public static int GameWaveLength;
	public static float TotalScore;

	public static int whatTowerIsPressed = -1;
	public GameObject[] towerButtons;
	private bool _isShowingAdvanceButton;
	public bool isShowingAdvanceButton {
		get { return _isShowingAdvanceButton; }
		set {
			_isShowingAdvanceButton = value;
		}
	}

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

	private float score;
	public float Score {
		get { return score; }
		set {
			score = value;
			TotalScore = score;
		}
	}

	public GameObject tutorialSpawn;
	public GameObject[] nextWaveLabels;
	public bool gameOver = false;

	private int wave;
	public int Wave {
		get { return wave; }
		set {
			if ((value == 0)) {
				tutorialSpawn.GetComponent<Animator> ().SetTrigger ("displayTutorial");
			} else {
				if (!gameOver) {
					DisplayWaveLabels (value);
				}
			}

			wave = value;
		}
	}

	public void DisplayWaveLabels(int value = 0) {
		for (int i = 0; i < nextWaveLabels.Length; i++) {
			nextWaveLabels [i].GetComponent<Text> ().text = "Wave " + (value + 1);
			nextWaveLabels [i].GetComponent<Animator> ().SetTrigger ("nextWave");
		}
	}

	// Use this for initialization
	void Start () {
		Gold = 350;
		Health = 10;
		Wave = 0;
		Score = 0;

		if (GameWaveLength == 0)
		{
			GameWaveLength = 20;
		}

		if (DifficultyBonus == 0)
		{
			DifficultyBonus = 1.0f;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Score = ((Health * 10000f) + (Gold + mapManager.getBuiltTowersCost())) * GameManagerBehavior.DifficultyBonus;
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
