using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
	public float speed = 5;
	public int damage;
	public GameObject target;
	public Vector3 startPosition;
	public Vector3 targetPosition;
	private EnemyDestructionDelegate del;
	private bool enemyDestruction;

	float distance;
	float startTime;

	private GameManagerBehavior gameManager;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		distance = Vector3.Distance(startPosition, targetPosition);
		GameObject gm = GameObject.Find ("GameManager");
		gameManager = gm.GetComponent<GameManagerBehavior> ();
		del = target.gameObject.GetComponent<EnemyDestructionDelegate>();
		del.enemyDelegate += OnEnemyDestroy;
		enemyDestruction = false;
	}

	// Update is called once per frame
	void Update () {
		float timeInterval = Time.time - startTime;

		if (target != null && !enemyDestruction) {
			gameObject.transform.position = Vector3.Lerp(startPosition, target.transform.position, timeInterval * speed / distance);

			if (gameObject.transform.position.Equals(target.transform.position)) {
				Transform healthBarTransform = target.transform.Find("HealthBarWrapper/HealthBar");
				HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar> ();
				healthBar.currentHealth -= Mathf.Max (damage, 0);

				if (healthBar.currentHealth <= 0) {
					Destroy (target);
					Destroy (gameObject);
					gameManager.Gold += 20;
				}
			}
		}
	}

	void OnEnemyDestroy(GameObject enemy) {
		del.enemyDelegate -= OnEnemyDestroy;
		enemyDestruction = true;
		Destroy (gameObject);
	}
}
