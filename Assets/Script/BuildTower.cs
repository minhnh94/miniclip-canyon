using UnityEngine;
using System.Collections;

public class BuildTower : MonoBehaviour {
	void OnPress() {
		print(gameObject.tag);
		if (gameObject.tag == "Tower1")
		{
			GameManagerBehavior.whatTowerIsPressed = 1;
		}
		else if (gameObject.tag == "Tower2")
		{
			GameManagerBehavior.whatTowerIsPressed = 2;
		}
		else if (gameObject.tag == "Tower3")
		{
			GameManagerBehavior.whatTowerIsPressed = 3;
		}
		else if (gameObject.tag == "Tower4")
		{
			GameManagerBehavior.whatTowerIsPressed = 4;
		}
		else if (gameObject.tag == "Tower5")
		{
			GameManagerBehavior.whatTowerIsPressed = 5;
		}
	}
}
