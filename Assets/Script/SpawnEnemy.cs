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

	public GameObject enemyPrefab;
	public Wave[] waves;
	public int timeBetweenWaves = 5;
	public int currentWave = 0;

	private GameManagerBehavior gameManager;

	private float lastSpawnTime;
	private int enemiesSpawned = 0;
	private float betweenWavesTimer;

	// Use this for initialization
	void Start () {
		lastSpawnTime = Time.time;
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();
	}
	
	// Update is called once per frame
	void Update () {
		// 1
		int currentWave = gameManager.Wave;
		if (currentWave < waves.Length) {
			// 2
			float timeInterval = Time.time - lastSpawnTime;
			float spawnInterval = waves[currentWave].spawnInterval;
//			Debug.Log (enemiesSpawned);
//			Debug.Log (timeInterval);
//			Debug.Log (timeBetweenWaves);
//			Debug.Log (timeInterval > spawnInterval);
			if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) || (enemiesSpawned != 0 && timeInterval > spawnInterval)) && enemiesSpawned < waves[currentWave].maxEnemies) {
				// 3  
				lastSpawnTime = Time.time;
				GameObject newEnemy = (GameObject) Instantiate(waves[currentWave].enemyPrefab);
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
				betweenWavesTimer = Time.time;
			}
			// 4 
			if ((enemiesSpawned == waves[currentWave].maxEnemies) && (Time.time - betweenWavesTimer >= 5) && (GameObject.FindGameObjectWithTag("Ground Enemy") == null) && (GameObject.FindGameObjectWithTag("Air Enemy") == null)) {
				gameManager.Wave++;
				gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
				enemiesSpawned = 0;
				lastSpawnTime = Time.time;
			}
			// 5 
		} else {
			gameManager.gameOver = true;
//			GameObject gameOverText = GameObject.FindGameObjectWithTag ("GameWon");
//			gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
//			SceneManager.LoadScene("GameOverScene");
		}
	}
}
