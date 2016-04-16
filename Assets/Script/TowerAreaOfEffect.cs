using UnityEngine;
using System.Collections;

public class TowerAreaOfEffect : MonoBehaviour {

	// Config
	public GameObject areaImage;
	private float areaRadius;
	private GameObject effectArea;
	private bool onClickFlag = false;
	public float aoeImageScale;

	// Use this for initialization
	void Start () 
	{
		areaRadius = gameObject.GetComponent<CircleCollider2D> ().radius;
		aoeImageScale = gameObject.GetComponent<TowerData> ().aoeImageScale;
		effectArea = Instantiate(areaImage, transform.position,	transform.rotation) as GameObject;
		effectArea.transform.SetParent(gameObject.GetComponent<TowerAction>().towerGun.transform);
		effectArea.transform.localScale = new Vector3(areaRadius * aoeImageScale, areaRadius * aoeImageScale, 0);
		effectArea.SetActive(false);
	}

	// Update is called once per frame
	void Update () 
	{
		if (gameObject.transform.parent.gameObject.GetComponent<GridBoxAction> ().isSelected) {
			effectArea.SetActive (true);
		} else {
			effectArea.SetActive (false);
		}
	}
}
