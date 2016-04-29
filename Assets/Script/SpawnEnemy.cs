using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Wave {
	public GameObject enemyPrefab;
	public float spawnInterval = 2;
	public int maxEnemies = 20;
}

public class SpawnEnemy : MonoBehaviour {

	public GameObject[] waypoints;
	public int timeBetweenWaves = 5;
	private int currentWave;
	public Wave[] waves;

	private GameManagerBehavior gameManager;

	private float lastSpawnTime;
	private int enemiesSpawned = 0;
	private bool allDied;

	// Use this for initialization
	void Start () {
		lastSpawnTime = Time.time;
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();

		print(GameManagerBehavior.GameWaveLength);
		print(GameManagerBehavior.DifficultyBonus);
		allDied = false;
	}
	
	// Update is called once per frame
	void Update () {
		// 1
		int theCurrentWave = gameManager.Wave;
		int maxWaveInThisLevel = GameManagerBehavior.GameWaveLength;
		if (theCurrentWave < maxWaveInThisLevel) {
			// 2
			float timeInterval = Time.time - lastSpawnTime;
			float spawnInterval = waves[theCurrentWave].spawnInterval;
			if (((enemiesSpawned == 0 && timeInterval >= 5) || (enemiesSpawned != 0 && timeInterval >= spawnInterval)) && enemiesSpawned < waves[theCurrentWave].maxEnemies) {
				// 3  
				lastSpawnTime = Time.time;
				GameObject newEnemy = (GameObject) Instantiate(waves[theCurrentWave].enemyPrefab);
				newEnemy.GetComponent<EnemyDestructionDelegate> ().hpMod *= (float) (1 + theCurrentWave / 20f);
				newEnemy.GetComponent<EnemyDestructionDelegate> ().hpMod *= GameManagerBehavior.DifficultyBonus;
				newEnemy.GetComponent<EnemyDestructionDelegate> ().healthBarWrapper.GetComponentInChildren<HealthBar> ().AdjustMaxHP ();

				if (newEnemy.tag == "Air Enemy") {
					float randomRoute = Random.value * 3;
					if ((randomRoute >= 0) && (randomRoute < 1)) {
						newEnemy.GetComponent<FlyToGoal> ().waypoints [0] = waypoints [0];
						newEnemy.GetComponent<FlyToGoal> ().waypoints [1] = waypoints [1];
					}
					if ((randomRoute >= 1) && (randomRoute < 2)) {
						newEnemy.GetComponent<FlyToGoal> ().waypoints [0] = waypoints [2];
						newEnemy.GetComponent<FlyToGoal> ().waypoints [1] = waypoints [3];
					}
					if ((randomRoute >= 2) && (randomRoute <= 3)) {
						newEnemy.GetComponent<FlyToGoal> ().waypoints [0] = waypoints [4];
						newEnemy.GetComponent<FlyToGoal> ().waypoints [1] = waypoints [5];
					}
				}
				enemiesSpawned++;
			}
			// 4 
			if ((enemiesSpawned >= waves[theCurrentWave].maxEnemies) && (timeInterval >= 5) && (GameObject.FindGameObjectWithTag("Ground Enemy") == null) && (GameObject.FindGameObjectWithTag("Air Enemy") == null)) {
				if (!allDied) {
					lastSpawnTime = Time.time;
					allDied = true;
					return;
				}
				gameManager.Wave++;
//				gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
				enemiesSpawned = 0;
				lastSpawnTime = Time.time;
				allDied = false;
			}
			// 5 
		} else {
			gameManager.gameOver = true;
//			GameObject gameOverText = GameObject.FindGameObjectWithTag ("GameWon");
//			gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
			SceneManager.LoadScene("GameWonScene");
		}
	}
}
