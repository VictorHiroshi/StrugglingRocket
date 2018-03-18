using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseScene : MonoBehaviour {
	
	void LateUpdate () {
		if(Input.GetKeyUp (KeyCode.Escape))
		{
			Close ();
		}
	}

	public void Close()
	{
		if (SceneManager.GetActiveScene ().buildIndex != 0 && SceneManager.GetActiveScene ().name != "GameScene")
		{
			SceneManager.LoadScene (0);
		}
		else if (SceneManager.GetActiveScene ().name == "GameScene") 
		{
			PlayAd.instance.PlayAdAndLoadScene ("MainMenu");
		}
		else
		{
			Application.Quit ();
		}
	}
}
