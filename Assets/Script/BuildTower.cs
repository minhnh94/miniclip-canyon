using UnityEngine;

public class BuildTower : MonoBehaviour {

	public GameManagerBehavior gameManager;
	public MapManager mapManager;

	Color initialColor;
	UIButton refButton;

	void Start() {
		refButton = gameObject.GetComponent<UIButton>();
		initialColor = refButton.defaultColor;
	}

	void OnClick() {

		SetToSelectedState();

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
		else if (gameObject.tag == Constant.TowerAdvanced1Tag)
		{
			selection = 5;
		}
		else if (gameObject.tag == Constant.TowerAdvanced2Tag)
		{
			selection = 6;
		}
		else if (gameObject.tag == Constant.TowerAdvanced3Tag)
		{
			selection = 7;
		}
		else if (gameObject.tag == Constant.TowerAdvanced4Tag)
		{
			selection = 8;
		}
		else if (gameObject.tag == Constant.TowerAdvanced5Tag)
		{
			selection = 9;
		}
			
		if (GameManagerBehavior.whatTowerIsPressed != -1)
		{
			SetToNormalState();
		}

		GameManagerBehavior.whatTowerIsPressed = GameManagerBehavior.whatTowerIsPressed == selection ? -1 : selection;
		mapManager.ToggleGridPreview(GameManagerBehavior.whatTowerIsPressed != -1);
	}

	public void SetToNormalState() {
		var currentBtn = gameManager.towerButtons[GameManagerBehavior.whatTowerIsPressed];
		currentBtn.GetComponent<BuildTower>().refButton.defaultColor = initialColor;
		TweenColor.Begin(currentBtn.GetComponent<UIButton>().tweenTarget, 0, initialColor);
		TweenScale.Begin(currentBtn, 0, new Vector3(1, 1, 1));
	}

	public void SetToSelectedState() {
		refButton.defaultColor = refButton.hover;
		TweenScale.Begin(gameObject, 0, new Vector3(1.2f, 1.2f, 1));
	}
}
