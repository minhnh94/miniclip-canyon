using UnityEngine;
using System.Collections;

public class TowerAreaOfEffect : MonoBehaviour {

	// Config
	public GameObject areaImage;
	private float areaRadius;
	private float aoeImageScale;
	private GameObject effectArea;
	private bool onClickFlag = false;

	// Use this for initialization
	void Start () 
	{
		areaRadius = gameObject.GetComponent<CircleCollider2D> ().radius;
		aoeImageScale = gameObject.GetComponent<TowerData> ().aoeImageScale;
		if (!gameObject.transform.Find("Area of Effect(Clone)")) {
			effectArea = Instantiate (areaImage, transform.position, transform.rotation) as GameObject;
			effectArea.transform.SetParent (gameObject.GetComponent<TowerAction> ().towerGun.transform);
			effectArea.transform.localScale = new Vector3 (areaRadius * aoeImageScale, areaRadius * aoeImageScale, 0);
		}
		deactivateAoE ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (gameObject.transform.parent.gameObject.GetComponent<GridBoxAction> ().isSelected) {
			activateAoE ();
		} else {
			deactivateAoE ();
		}
	}

	public void activateAoE() {
		effectArea.SetActive (true);
	}

	public void deactivateAoE() {
		effectArea.SetActive (false);
	}
}
