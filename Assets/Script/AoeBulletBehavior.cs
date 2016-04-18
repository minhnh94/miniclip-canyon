using UnityEngine;
using System.Collections;

public class AoeBulletBehavior : MonoBehaviour {
	public int damage;
	public bool isSlowBullet;
	public float bulletSlowDuration;
	private float radius;

	public GameObject tower;
	public GameObject target;
	public Vector3 startPosition;
	private GameManagerBehavior gameManager;
	private float distance;
	private EnemyDestructionDelegate subDel;

	private float areaRadius;
	private float spriteScale;

	private SpriteRenderer spRend;
	private Color col;

	// Use this for initialization
	void Start () {
		distance = Vector3.Distance(startPosition, target.transform.position);
		Vector3 direction = target.transform.position - gameObject.transform.position;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.forward, direction), 1f);

		GameObject gm = GameObject.Find ("GameManager");
		gameManager = gm.GetComponent<GameManagerBehavior> ();

		radius = tower.GetComponent<CircleCollider2D> ().radius;
		spriteScale = tower.GetComponent<AoeTowerAction> ().aoeBulletSizeScale;
		gameObject.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (radius * spriteScale, radius * spriteScale, 0);

		spRend = transform.GetComponent<SpriteRenderer>();
		col = spRend.color;
		col.a = 0.6f; // 0.5f = half transparent
		spRend.color = col;

		Collider2D[] subTargets = Physics2D.OverlapCircleAll(gameObject.transform.position, radius);
		foreach (Collider2D subTarget in subTargets) {
			if (subTarget.transform.Find ("HealthBarWrapper/HealthBar") != null) {
				subDel = subTarget.gameObject.GetComponent<EnemyDestructionDelegate> ();

				Transform healthBarTransform = subTarget.transform.Find ("HealthBarWrapper/HealthBar");

				if (healthBarTransform != null) {
					HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar> ();
					healthBar.currentHealth -= Mathf.Max (damage, 0);

					if (healthBar.currentHealth <= 0) {
						gameManager.Gold += subTarget.gameObject.GetComponent<EnemyDestructionDelegate> ().gold;
						subDel.PlayAnimation ();
					}
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (col.a <= 0) {
			Destroy (gameObject);
		} else {
			col.a -= 0.08f;
			spRend.color = col;
		}
	}
}