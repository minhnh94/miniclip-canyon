using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
	public float speed = 10;
	public int damage;
	public GameObject target;
	public Vector3 startPos;
	public Vector3 endPos;

	float distance;
	float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		distance = Vector3.Distance(startPos, endPos);
	}

	// Update is called once per frame
	void Update () {
		float timeInterval = Time.time - startTime;
		gameObject.transform.position = Vector3.Lerp(startPos, endPos, timeInterval * speed / distance);

		if (gameObject.transform.position.Equals(endPos))
		{
			Destroy(gameObject);
		}
	}
}
