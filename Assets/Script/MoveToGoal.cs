using UnityEngine;
using System.Collections.Generic;

//example
[RequireComponent(typeof(PolyNavAgent))]
public class MoveToGoal : MonoBehaviour{

	private PolyNavAgent _agent;
	public PolyNavAgent agent{
		get
		{
			if (!_agent)
				_agent = GetComponent<PolyNavAgent>();
			return _agent;			
		}
	}

	void Update() {
		agent.SetDestination(GameObject.Find("Goal").transform.position);
	}

	void OnTriggerEnter2D (Collider2D other) {
		// If the enemy hits the goal
		if (other.tag == "Goal") {
			Destroy (gameObject);
		} 
	}

	public float distanceToGoal() {
		float distance = 0;
		distance = gameObject.GetComponent<PolyNavAgent> ().remainingDistance;
		return distance;
	}
}