using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
	public float speed = 10;
	public int damage;
	public bool isSlowBullet;
	public float bulletSlowDuration;
	public bool isAoeBullet;
	public float radius;

	public GameObject target;
	public Vector3 startPosition;
	private Vector3 oldTargetPosition;
	private EnemyDestructionDelegate del;
	private EnemyDestructionDelegate subDel;
	private bool enemyDestruction;
	private bool enemyCollision;

	float distance;
	float startTime;

	private GameManagerBehavior gameManager;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		distance = Vector3.Distance(startPosition, target.transform.position);
		GameObject gm = GameObject.Find ("GameManager");
		gameManager = gm.GetComponent<GameManagerBehavior> ();
		del = target.gameObject.GetComponent<EnemyDestructionDelegate>();
		del.enemyDelegate += OnEnemyDestroy;
		enemyDestruction = false;
		enemyCollision = false;
	}

	// Update is called once per frame
	void Update () {
		float timeInterval = Time.time - startTime;

		if (target != null && !enemyDestruction) {
			gameObject.transform.position = Vector3.Lerp (startPosition, target.transform.position, timeInterval * speed / distance);
			Vector3 direction = gameObject.transform.position - target.transform.position;
			gameObject.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI + 90, new Vector3(0, 0, 1));
		} else {
			gameObject.transform.Translate (Vector3.up * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		// If bullet hit the enemy
		if ((target != null) && (other == target.transform.GetComponent<PolygonCollider2D> ())) {
			if (isAoeBullet) {
				areaOfEffect (other, radius);
			} else {
				Transform healthBarTransform = target.transform.Find ("HealthBarWrapper/HealthBar");

				if (healthBarTransform != null) {
					HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar> ();
					healthBar.currentHealth -= Mathf.Max (damage, 0);

					if (healthBar.currentHealth <= 0) {
						del.PlayAnimation ();
						enemyCollision = true;
						gameManager.Gold += 20;
					}
				}
			}

			Destroy (gameObject);
		}

		if (other.tag == "World Boundary") {
			Destroy (gameObject);
		}
	}

	void areaOfEffect (Collider2D mainTarget, float radius) {
		Collider2D[] subTargets = Physics2D.OverlapCircleAll(mainTarget.gameObject.transform.position, radius);
		foreach (Collider2D subTarget in subTargets) {
			if (subTarget.transform.Find ("HealthBarWrapper/HealthBar") != null) {
				subDel = subTarget.gameObject.GetComponent<EnemyDestructionDelegate> ();

				Transform healthBarTransform = subTarget.transform.Find ("HealthBarWrapper/HealthBar");

				if (healthBarTransform != null) {
					HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar> ();
					healthBar.currentHealth -= Mathf.Max (damage, 0);

					if (healthBar.currentHealth <= 0) {
						subDel.PlayAnimation ();
						enemyCollision = true;
						gameManager.Gold += 20;
					}
				}
			}
		}
	}

	void OnEnemyDestroy(GameObject enemy) {
		del.enemyDelegate -= OnEnemyDestroy;
		enemyDestruction = true;
		if (enemyCollision) {
			Destroy (gameObject);
		}
	}
}