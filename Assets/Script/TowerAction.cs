using UnityEngine;
using System.Collections.Generic;

public class TowerAction : MonoBehaviour {

	public bool canAttackAir;
	public bool canAttackGround;
	public List<GameObject> enemiesInRange;
	public GameObject towerGun;
	public AudioClip shootSound;

	GameObject oldTarget = null;
	float turnDuration;
	public float turnRate;
	public float canShootAngleThreshold;
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
				distanceToGoal = enemy.GetComponent<MoveToGoal> ().DistanceToGoal ();
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
//		Debug.Log (target);
		if (target != null) {
			Vector3 direction = towerGun.transform.position - target.transform.position;
			if ((Vector2.Angle(towerGun.transform.up, direction) <= canShootAngleThreshold) && (Time.time - lastShotTime > towerData.fireRate)) {
				Shoot (target.GetComponent<Collider2D> ());
				lastShotTime = Time.time;
			}

//			towerGun.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI + 90,	new Vector3(0, 0, 1));
			if (oldTarget == target) {
				turnDuration = Mathf.Min(towerData.fireRate, Time.time - lastShotTime);
			} else {
				turnDuration = Mathf.Min(towerData.fireRate, Time.time - lastShotTime - towerData.fireRate);
			}
			towerGun.transform.rotation = Quaternion.Slerp (towerGun.transform.rotation, Quaternion.LookRotation (Vector3.forward, direction), turnDuration * turnRate);
			oldTarget = target;
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
		newBullet.GetComponent<BulletBehavior> ().Damage = GetComponent<TowerData> ().damage;
		newBullet.transform.position = startPosition;
		BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();
		bulletComp.target = target.gameObject;
		bulletComp.startPosition = startPosition;
	}
}
