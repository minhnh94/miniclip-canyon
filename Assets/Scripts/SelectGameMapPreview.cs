using UnityEngine;
using System.Collections;

public class SelectGameMapPreview : MonoBehaviour {

	public GameObject[] mapRenderers;

	public void SetMapPreview(int mapNumber) {
		// Index starts from 0,1,2 accordingly
		for (int i = 0; i < mapRenderers.Length; i++)
		{
			var map = mapRenderers[i];
			if (i == mapNumber)
			{
				map.SetActive(true);
			}
			else
			{
				map.SetActive(false);	
			}
		}
	}
}
