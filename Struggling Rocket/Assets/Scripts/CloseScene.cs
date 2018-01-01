using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseScene : MonoBehaviour {
	
	void LateUpdate () {
		if(Input.GetKeyUp (KeyCode.Escape))
		{
			if (SceneManager.GetActiveScene ().buildIndex != 0)
				SceneManager.LoadScene (0);
			else
			{
				Application.Quit ();
			}
		}
	}
}
