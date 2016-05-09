﻿using UnityEngine;
using System.Collections;

public class EnemyDestructionDelegate : MonoBehaviour {

	public int gold;
	public float hpMod;
	public delegate void EnemyDelegate (GameObject enemy);
	public EnemyDelegate enemyDelegate;
	public GameObject healthBarWrapper;
	public AudioClip destroySound;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayAnimation(){
		Destroy (healthBarWrapper);
		PlayAudio ();
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

	public void PlayAudio(){
		if (!GameManagerBehavior.AudioMute)
		{
			AudioSource.PlayClipAtPoint(destroySound, transform.position);	
		}
	}
}
