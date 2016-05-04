using UnityEngine;
using System.Collections.Generic;

public class FlyToGoal : MonoBehaviour{

	private float normalSpeed;
	public float baseSlowDuration;
	private float bulletSlowDuration = 0f;
	private bool isSlowed = false;
	private float slowBegin;

//	[HideInInspector]
	public GameObject[] waypoints;
	private int currentWaypoint = 0;
	public float speed;

	void Start() {
		transform.position = waypoints [currentWaypoint].transform.position;
	}

	void Update() {
		Vector3 startPosition = waypoints [currentWaypoint].transform.position;
		Vector3 endPosition = waypoints [currentWaypoint + 1].transform.position;

		Vector3 direction = endPosition - startPosition;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.forward, direction), 1f);
		transform.Translate (Vector3.up * speed * Time.deltaTime);

		if (isSlowed && ((Time.time - slowBegin) >= (baseSlowDuration + bulletSlowDuration))) {
				ClearSlowEffect ();
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Finish") {
			if (currentWaypoint < waypoints.Length - 3) {
				currentWaypoint++;
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

	public void SetSlowEffect(float duration) {
		if (!isSlowed) {
			speed /= 2;
		}
		isSlowed = true;
		bulletSlowDuration = duration;
		slowBegin = Time.time;
	}

	private void ClearSlowEffect()
	{
		isSlowed = false;
		speed *= 2;
	}
}