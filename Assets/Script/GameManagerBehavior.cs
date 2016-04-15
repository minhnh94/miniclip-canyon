using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerBehavior : MonoBehaviour {

	public static int whatTowerIsPressed = 1;
	public Text goldLabel;

	private int gold;
	public int Gold {
		get { return gold; }
		set {
			gold = value;
			goldLabel.GetComponent<Text> ().text = "Gold: " + gold;
		}
	}

	// Use this for initialization
	void Start () {
		Gold = 500;
		Debug.Log (Gold);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
