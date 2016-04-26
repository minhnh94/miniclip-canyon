using UnityEngine;
using System.Collections.Generic;

public class FlyToGoal : MonoBehaviour{

	private float normalSpeed;
	public float baseSlowDuration = 3f;
	private float bulletSlowDuration = 0f;
	private bool isSlowed = false;
	private float slowBegin;

//	[HideInInspector]
	public GameObject[] waypoints;
	private int currentWaypoint = 0;
	private float lastWaypointSwitchTime;
	public float speed;

	void Start() {
		lastWaypointSwitchTime = Time.time;
		RotateIntoMoveDirection ();
	}

	void Update() {
		Vector3 startPosition = waypoints [currentWaypoint].transform.position;
		Vector3 endPosition = waypoints [currentWaypoint + 1].transform.position;

		float pathLength = Vector3.Distance (startPosition, endPosition);
		float totalTimeForPath = pathLength / speed;
		float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
		gameObject.transform.position = Vector3.Lerp (startPosition, endPosition, currentTimeOnPath / totalTimeForPath );

		if (gameObject.transform.position.Equals(endPosition)) {
			if (currentWaypoint < waypoints.Length - 3) {
				currentWaypoint++;
				lastWaypointSwitchTime = Time.time;
			} else {
				Destroy(gameObject);

//				AudioSource audioSource = gameObject.GetComponent<AudioSource>();
//				AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
				GameManagerBehavior gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();
				gameManager.Health -= 1;
			}
		}
		if (isSlowed && (Time.time - slowBegin) >= (baseSlowDuration + bulletSlowDuration)) {
			ClearSlowEffect();
		}
	}

	private void RotateIntoMoveDirection() {
		gameObject.GetComponent<SpriteRenderer> ().flipY = true;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Bullet") {
			if (other.gameObject.GetComponent<BulletBehavior> ().isSlowBullet) {
				if (!isSlowed) {
//					speed /= 2;
				}
				isSlowed = true;
				bulletSlowDuration = other.gameObject.GetComponent <BulletBehavior> ().bulletSlowDuration;
				slowBegin = Time.time;
			}
		}
	}

	public float distanceToGoal() {
		float distance = 0;
		distance += Vector3.Distance(
			gameObject.transform.position, 
			waypoints [currentWaypoint + 1].transform.position);
		return distance;
	}

	void ClearSlowEffect()
	{
		isSlowed = false;
//		speed *= 2;
	}
}