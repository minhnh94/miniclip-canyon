using UnityEngine;
using System.Collections.Generic;

//example
[RequireComponent(typeof(PolyNavAgent))]
public class MoveToGoal : MonoBehaviour{

	private float normalSpeed;
	public float baseSlowDuration = 3f;
	private float bulletSlowDuration = 0f;
	private bool isSlowed = false;
	private float slowBegin;

	private PolyNavAgent _agent;
	public PolyNavAgent agent{
		get
		{
			if (!_agent)
				_agent = GetComponent<PolyNavAgent>();
			return _agent;			
		}
	}

	void Start() {
		normalSpeed = agent.maxSpeed;
	}

	void Update() {
		agent.SetDestination(GameObject.Find("Goal").transform.position);
		if (isSlowed && (Time.time - slowBegin) >= (baseSlowDuration + bulletSlowDuration)) {
			ClearSlowEffect();
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		// If the enemy hits the goal
		if (other.tag == "Goal") {
			Destroy (gameObject);

			GameManagerBehavior gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();
			gameManager.Health -= 1;
		}

		if (other.tag == "Bullet") {
			if (other.gameObject.GetComponent<BulletBehavior> ().isSlowBullet) {
				if (!isSlowed) {
					agent.maxSpeed = agent.maxSpeed / 2;
				}
				isSlowed = true;
				bulletSlowDuration = other.gameObject.GetComponent <BulletBehavior> ().bulletSlowDuration;
				slowBegin = Time.time;
			}
		}
	}

	public float distanceToGoal() {
		float distance = 0;
		distance = gameObject.GetComponent<PolyNavAgent> ().remainingDistance;
		return distance;
	}

	void ClearSlowEffect()
	{
		isSlowed = false;
		agent.maxSpeed = agent.maxSpeed * 2;
	}
}