using UnityEngine;
using System.Collections.Generic;

public class AoeTowerAction : MonoBehaviour {

	public bool canAttackAir;
	public bool canAttackGround;
	public float aoeBulletSizeScale;
	public List<GameObject> enemiesInRange;
	public GameObject towerGun;
	public AudioClip shootSound;

	GameObject oldTarget = null;
	float t;
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
			float distanceToGoal = float.MaxValue;
			if (enemy.tag == "Ground Enemy" && canAttackGround) {
				distanceToGoal = enemy.GetComponent<MoveToGoal> ().distanceToGoal ();
			} else {
				if (enemy.tag == "Air Enemy" && canAttackAir) {
					distanceToGoal = enemy.GetComponent<FlyToGoal> ().distanceToGoal ();
				}
			}
			if (distanceToGoal < minimalEnemyDistance) {
				target = enemy;
				minimalEnemyDistance = distanceToGoal;
			}
		}

		if (target != null) {
			if (Time.time - lastShotTime > towerData.fireRate) {
				Shoot (target.GetComponent<Collider2D> ());
				lastShotTime = Time.time;
			}

//			Vector3 direction = towerGun.transform.position - target.transform.position;
//			if (oldTarget == target) {
//				t = Time.time - lastShotTime;
//			} else {
//				t = Time.time - lastShotTime + towerData.fireRate;
//			}
//			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.forward, direction), t * 0.25f);
//			oldTarget = target;
		}
	}

	void OnEnemyDestroy(GameObject enemy) {
		enemiesInRange.Remove (enemy);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (canAttackGround) {
			if (other.gameObject.tag.Equals ("Ground Enemy")) {
				enemiesInRange.Add (other.gameObject);
				EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate> ();
				del.enemyDelegate += OnEnemyDestroy;
			}
		}

		if (canAttackAir) {
			if (other.gameObject.tag.Equals ("Air Enemy")) {
				enemiesInRange.Add (other.gameObject);
				EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate> ();
				del.enemyDelegate += OnEnemyDestroy;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (canAttackGround) {
			if (other.gameObject.tag.Equals ("Ground Enemy")) {
				enemiesInRange.Remove (other.gameObject);
				EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate> ();
				del.enemyDelegate -= OnEnemyDestroy;
			}
		}

		if (canAttackAir) {
			if (other.gameObject.tag.Equals ("Air Enemy")) {
				enemiesInRange.Remove (other.gameObject);
				EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate> ();
				del.enemyDelegate -= OnEnemyDestroy;
			}
		}
	}

	void PlayShootSound(){
		AudioSource.PlayClipAtPoint(shootSound, transform.position);
	}

	void Shoot(Collider2D target) {
		PlayShootSound ();
		GameObject bulletPrefab = towerData.bullet;

		Vector3 startPosition = gameObject.transform.position;
		Vector3 targetPosition = target.transform.position;
		startPosition.z = bulletPrefab.transform.position.z;
		targetPosition.z = bulletPrefab.transform.position.z;

		GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
		newBullet.transform.position = startPosition;
		AoeBulletBehavior bulletComp = newBullet.GetComponent<AoeBulletBehavior>();
		bulletComp.tower = gameObject;
		bulletComp.target = target.gameObject;
		bulletComp.startPosition = startPosition;
	}
}
