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
		transform.position = waypoints [currentWaypoint].transform.position;
	}

	void Update() {
		Vector3 startPosition = waypoints [currentWaypoint].transform.position;
		Vector3 endPosition = waypoints [currentWaypoint + 1].transform.position;

		float pathLength = Vector3.Distance (startPosition, endPosition);
		Vector3 direction = endPosition - startPosition;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.forward, direction), 1f);
		transform.Translate (Vector3.up * speed * Time.deltaTime);

		if (isSlowed && ((Time.time - slowBegin) >= (baseSlowDuration + bulletSlowDuration))) {
				ClearSlowEffect ();
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Bullet") {
			if (other.gameObject.GetComponent<BulletBehavior> ().isSlowBullet) {
				if (!isSlowed) {
					speed /= 2;
				}
				isSlowed = true;
				bulletSlowDuration = other.gameObject.GetComponent <BulletBehavior> ().bulletSlowDuration;
				slowBegin = Time.time;
			}
		}

		if (other.tag == "Finish") {
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
		speed *= 2;
	}
}