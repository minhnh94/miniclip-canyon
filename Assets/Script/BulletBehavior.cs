using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
	public float speed;
	private float muzzleSpeed;
	public float speedDecay;
	private int _damage;
	public int Damage {
		get { return _damage; }
		set {
			_damage = value;
		}
	}
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

	private float startDistance;
	private float currentDistance;
	private float startTime;
	private bool closeEnough = false;
	private float closeStartTime;

	private GameManagerBehavior gameManager;

	// Use this for initialization
	void Start () {
		muzzleSpeed = speed * 2f;
		startTime = Time.time;
		startDistance = Vector3.Distance(startPosition, target.transform.position);
		Vector3 direction = target.transform.position - gameObject.transform.position;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.forward, direction), 1f);

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
		if (muzzleSpeed > speed) {
			muzzleSpeed -= speedDecay;
		}

		if (target != null && !enemyDestruction) {
			Vector3 direction = target.transform.position - gameObject.transform.position;
			currentDistance = direction.magnitude;
			if ((currentDistance <= (speed / 10f)) || closeEnough) {
				if (!closeEnough) {
					closeEnough = true;
					startPosition = transform.position;
					closeStartTime = Time.time;
				}

				float closeTimeInterval = Time.time - closeStartTime;
				muzzleSpeed = (muzzleSpeed >= (speed * 0.75f)) ? (muzzleSpeed - speedDecay) : muzzleSpeed;
				gameObject.transform.position = Vector3.Lerp (startPosition, target.transform.position, closeTimeInterval * muzzleSpeed / currentDistance);

				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.forward, direction), timeInterval * 0.5f);
				return;
			}
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.forward, direction), timeInterval * 0.5f);
			gameObject.transform.Translate (Vector3.up * muzzleSpeed * Time.deltaTime);
		} else {
			gameObject.transform.Translate (Vector3.up * muzzleSpeed * Time.deltaTime);
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
					healthBar.currentHealth -= Mathf.Max (_damage, 0);
					Destroy (gameObject);

					if (healthBar.currentHealth <= 0) {
						gameManager.Gold += target.gameObject.GetComponent<EnemyDestructionDelegate> ().gold;
						del.PlayAnimation ();
						enemyCollision = true;
					}
				}
			}
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
					healthBar.currentHealth -= Mathf.Max (_damage, 0);
					Destroy (gameObject);

					if (healthBar.currentHealth <= 0) {
						gameManager.Gold += subTarget.gameObject.GetComponent<EnemyDestructionDelegate> ().gold;
						subDel.PlayAnimation ();
						enemyCollision = true;
					}
				}
			}
		}
	}

	void OnEnemyDestroy(GameObject enemy) {
		del.enemyDelegate -= OnEnemyDestroy;
		enemyDestruction = true;
	}
}