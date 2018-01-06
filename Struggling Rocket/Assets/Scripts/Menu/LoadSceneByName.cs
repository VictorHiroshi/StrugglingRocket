using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByName : MonoBehaviour {
	public string gameSceneName;

	public void Load()
	{
		SceneManager.LoadScene (gameSceneName);

	}
}
