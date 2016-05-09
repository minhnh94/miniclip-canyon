using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowTutorialToggle : MonoBehaviour {

	public static bool playedTutorial;

	void Start () {
		Toggle toggle = GetComponent<Toggle> ();
		if (playedTutorial) {
			toggle.isOn = !playedTutorial;
		}

		toggle.onValueChanged.AddListener ((value) => {
			MyListener (value);
		});
	}

	public void MyListener (bool value) {
		if (value) {
			playedTutorial = false;
		} else {
			playedTutorial = true;
		}

	}
}
