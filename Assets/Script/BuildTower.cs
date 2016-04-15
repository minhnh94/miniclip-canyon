using UnityEngine;

public class BuildTower : MonoBehaviour {

	public GameManagerBehavior gameManager;

	Color initialColor;
	UIButton refButton;

	void Start() {
		refButton = gameObject.GetComponent<UIButton>();
		initialColor = refButton.defaultColor;
	}

	void OnClick() {

		refButton.defaultColor = refButton.hover;
		int selection = -1;

		if (gameObject.tag == Constant.TowerBasic1Tag)
		{
			selection = 0;
		}
		else if (gameObject.tag == Constant.TowerBasic2Tag)
		{
			selection = 1;
		}
		else if (gameObject.tag == Constant.TowerBasic3Tag)
		{
			selection = 2;
		}
		else if (gameObject.tag == Constant.TowerBasic4Tag)
		{
			selection = 3;
		}
		else if (gameObject.tag == Constant.TowerBasic5Tag)
		{
			selection = 4;
		}
			
		if (GameManagerBehavior.whatTowerIsPressed != -1)
		{
			print("reset");
			var currentBtn = gameManager.towerButtons[GameManagerBehavior.whatTowerIsPressed];
			currentBtn.GetComponent<BuildTower>().refButton.defaultColor = initialColor;
			TweenColor.Begin(currentBtn.GetComponent<UIButton>().tweenTarget, 0, initialColor);
		}

		GameManagerBehavior.whatTowerIsPressed = GameManagerBehavior.whatTowerIsPressed == selection ? -1 : selection;
	}

	public void SetToNormalState() {
		refButton.defaultColor = initialColor;
	}
}
