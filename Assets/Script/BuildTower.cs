using UnityEngine;
using System.Collections;

public class BuildTower : MonoBehaviour {
	void OnPress() {
		if (gameObject.tag == Constant.TowerBasic1Tag)
		{
			GameManagerBehavior.whatTowerIsPressed = 0;
		}
		else if (gameObject.tag == Constant.TowerBasic2Tag)
		{
			GameManagerBehavior.whatTowerIsPressed = 1;
		}
		else if (gameObject.tag == Constant.TowerBasic3Tag)
		{
			GameManagerBehavior.whatTowerIsPressed = 2;
		}
		else if (gameObject.tag == Constant.TowerBasic4Tag)
		{
			GameManagerBehavior.whatTowerIsPressed = 3;
		}
		else if (gameObject.tag == Constant.TowerBasic5Tag)
		{
			GameManagerBehavior.whatTowerIsPressed = 4;
		}
	}
}
