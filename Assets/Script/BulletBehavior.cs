using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
	public float speed = 5;
	public int damage;
	public GameObject target;
	public Vector3 startPosition;
	private Vector3 oldTargetPosition;
	private EnemyDestructionDelegate del;
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

		// The bullet will keep moving, staying below the enemy until the enemy is destroyed
		// Dunno how to fix tbh
		if (target != null && !enemyDestruction) {
			gameObject.transform.position = Vector3.Lerp (startPosition, target.transform.position, timeInterval * speed / distance);
		} else {
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, oldTargetPosition, - (timeInterval * speed / (distance * 25)) );
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		// If bullet hit the enemy
		if ((target != null) && (other == target.transform.GetComponent<PolygonCollider2D> ())) {
			Transform healthBarTransform = target.transform.Find ("HealthBarWrapper/HealthBar");
			HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar> ();
			healthBar.currentHealth -= Mathf.Max (damage, 0);
			Debug.Log (healthBar.currentHealth);

			if (healthBar.currentHealth <= 0) {
				oldTargetPosition = target.transform.position;
				Destroy (target);
				Destroy (gameObject);
				enemyCollision = true;
				gameManager.Gold += 20;
			}
		}

		if (other.tag == "World Boundary") {
			Destroy (gameObject);
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
