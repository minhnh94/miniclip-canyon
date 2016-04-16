using UnityEngine;
using System.Collections.Generic;

public class TowerAction : MonoBehaviour {
	
	public List<GameObject> enemiesInRange;
	public GameObject towerGun;

	float lastShotTime;
	TowerData towerData;

	// Use this for initialization
	void Start () {
		enemiesInRange = new List<GameObject>();
		lastShotTime = Time.time;
		towerData = gameObject.GetComponentInChildren<TowerData> ();
	}

	// Update is called once per frame
	void Update () {
		GameObject target = null;

		float minimalEnemyDistance = float.MaxValue;
		foreach (GameObject enemy in enemiesInRange) {
			float distanceToGoal = enemy.GetComponent<MoveToGoal> ().distanceToGoal ();
			if (distanceToGoal < minimalEnemyDistance) {
				target = enemy;
				minimalEnemyDistance = distanceToGoal;
			}
		}

		if (target != null) {
			if (Time.time - lastShotTime > towerData.fireRate) {
				if (gameObject.GetComponent<TowerData> ().isSlowTower) {
					foreach (GameObject enemy in enemiesInRange) {
						Shoot (enemy.GetComponent<Collider2D> ());
					}
				} else {
					Shoot (target.GetComponent<Collider2D> ());
				}
				lastShotTime = Time.time;
			}

			Vector3 direction = towerGun.transform.position - target.transform.position;
			towerGun.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI + 90,	new Vector3(0, 0, 1));
		}
	}

	void OnEnemyDestroy(GameObject enemy) {
		enemiesInRange.Remove (enemy);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals("Enemy"))
		{
			enemiesInRange.Add(other.gameObject);
			EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
			del.enemyDelegate += OnEnemyDestroy;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag.Equals("Enemy"))
		{
			enemiesInRange.Remove(other.gameObject);
			EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
			del.enemyDelegate -= OnEnemyDestroy;
		}
	}

	void Shoot(Collider2D target) {
		GameObject bulletPrefab = towerData.bullet;

		Vector3 startPosition = gameObject.transform.position;
		Vector3 targetPosition = target.transform.position;
		startPosition.z = bulletPrefab.transform.position.z;
		targetPosition.z = bulletPrefab.transform.position.z;

		GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
		newBullet.transform.position = startPosition;
		BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();
		bulletComp.target = target.gameObject;
		bulletComp.startPosition = startPosition;
	}
}
