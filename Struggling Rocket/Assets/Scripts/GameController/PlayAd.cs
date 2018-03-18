using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class PlayAd : MonoBehaviour {

	public static PlayAd instance;

	void Awake () {
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
		else if(instance != this)
		{
			Destroy (gameObject);
			return;
		}
	}

	public void PlayAdAndLoadScene (string sceneName) {
		StartCoroutine (WaitAdAndLoad (sceneName));
	}

	private IEnumerator WaitAdAndLoad (string sceneName) {
		SceneManager.LoadScene ("AdScene");

		if (Advertisement.IsReady ()) {
			Advertisement.Show ();
		}

		while (Advertisement.isShowing) {
			yield return null;
		}

		yield return new WaitForSecondsRealtime (0.2f);

		SceneManager.LoadScene (sceneName);
	}
}
