using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByName : MonoBehaviour {
	public string gameSceneName;
	public bool playAd = false;

	public void Load()
	{
		if (playAd) {
			PlayAd.instance.PlayAdAndLoadScene (gameSceneName);
		}
		else {
			SceneManager.LoadScene (gameSceneName);
		}
	}
}
