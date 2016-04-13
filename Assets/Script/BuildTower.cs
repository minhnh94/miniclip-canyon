using UnityEngine;
using System.Collections;

public class BuildTower : MonoBehaviour {
	void OnPress() {
		print(gameObject.tag);
		if (gameObject.tag == "Tower1")
		{
			TowerDefenseManager.whatTowerIsPressed = 1;
		}
		else if (gameObject.tag == "Tower2")
		{
			TowerDefenseManager.whatTowerIsPressed = 2;
		}
		else if (gameObject.tag == "Tower3")
		{
			TowerDefenseManager.whatTowerIsPressed = 3;
		}
		else if (gameObject.tag == "Tower4")
		{
			TowerDefenseManager.whatTowerIsPressed = 4;
		}
		else if (gameObject.tag == "Tower5")
		{
			TowerDefenseManager.whatTowerIsPressed = 5;
		}
	}
}
