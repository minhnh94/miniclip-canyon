using UnityEngine;
using System.Collections;

public class EnemyDestructionDelegate : MonoBehaviour {

	public delegate void EnemyDelegate (GameObject enemy);
	public EnemyDelegate enemyDelegate;
	public GameObject healthBarWrapper;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayAnimation(){
		Destroy (healthBarWrapper);
		Animator animator = GetComponent<Animator>();
		animator.SetBool ("die", true);
		OnDestroy ();
	}

	void GoodDaySir()
	{
		DestroyObject( gameObject );
	}

	void OnDestroy () {
		if (enemyDelegate != null) {
			enemyDelegate (gameObject);
		}
	}
}
