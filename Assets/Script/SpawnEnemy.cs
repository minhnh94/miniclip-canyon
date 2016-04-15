using UnityEngine;
using System.Collections;

[System.Serializable]
public class Wave {
	public GameObject enemyPrefab;
	public float spawnInterval = 2;
	public int maxEnemies = 20;
}

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemyPrefab;
	public Wave[] waves;
	public int timeBetweenWaves = 5;
	public int currentWave = 0;

	private float lastSpawnTime;
	private int enemiesSpawned = 0;
	private int maxEnemies = 20;

	// Use this for initialization
	void Start () {
		lastSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float timeInterval = Time.time - lastSpawnTime;
		float spawnInterval = 1.0f;
		if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
		    timeInterval > spawnInterval) &&
		    enemiesSpawned < maxEnemies) {
			Instantiate (enemyPrefab);
			lastSpawnTime = Time.time;
			enemiesSpawned++;
		}
	}
}
