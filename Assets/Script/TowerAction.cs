using UnityEngine;
using System.Collections.Generic;

public class TowerAction : MonoBehaviour {
	
	public List<GameObject> enemiesInRange;
	public GameObject bullet;
	public GameObject towerGun;

	float lastShotTime;

	// Use this for initialization
	void Start () {
		enemiesInRange = new List<GameObject>();
		lastShotTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		GameObject target = null;

		if (enemiesInRange.Count != 0)
		{
			target = enemiesInRange[0];	
		}

		if (target != null)
		{
			if (Time.time - lastShotTime > 1)
			{
				shoot(target.GetComponent<Collider2D>());
				lastShotTime = Time.time;
			}

			Vector3 direction = gameObject.transform.position - target.transform.position;
			gameObject.transform.rotation = Quaternion.AngleAxis(
				Mathf.Atan2 (direction.y, direction.x) * 180 / Mathf.PI,
				new Vector3 (0, 0, 1));
		}
	}

	void OnEnemyDestroy(GameObject enemy) {
		enemiesInRange.Remove(enemy);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals("Enemy"))
		{
			enemiesInRange.Add(other.gameObject);
//			EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
//			del.enemyDelegate += OnEnemyDestroy;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag.Equals("Enemy"))
		{
			enemiesInRange.Remove(other.gameObject);
//			EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
//			del.enemyDelegate -= OnEnemyDestroy;
		}
	}

	void shoot(Collider2D target) {
		GameObject bulletPrefab = bullet;
		Vector3 startPos = gameObject.transform.position;
		Vector3 targetPos = target.transform.position;
		startPos.z = bulletPrefab.transform.position.z;
		targetPos.z = bulletPrefab.transform.position.z;

		GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
		newBullet.transform.position = startPos;
		BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();
		bulletComp.target = target.gameObject;
		bulletComp.startPos = startPos;
		bulletComp.endPos = targetPos;
	}
}
