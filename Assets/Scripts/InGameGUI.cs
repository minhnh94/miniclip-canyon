using UnityEngine;
using System.Collections;

public class InGameGUI : MonoBehaviour {
	private bool menuPanelOpen = false;
	public TweenPosition menuPanelTweener;
	public TweenRotation menuPanelArrowTweener;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ToggleMenuPanel(){
		if (menuPanelOpen) {
			menuPanelTweener.Play (false);
			menuPanelArrowTweener.Play (false);
			menuPanelOpen = false;
		} else {
			menuPanelTweener.Play (true);
			menuPanelArrowTweener.Play (true);
			menuPanelOpen = true;
		}
	}
}
