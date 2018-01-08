using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public static UnityEvent UpdatedValues;
	public static bool soundOn = true;


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

		Initialize ();
	}

	public void Initialize()
	{
		UpdatedValues = new UnityEvent ();

		if (PlayerPrefs.HasKey ("soundOn"))
		{
			soundOn = (PlayerPrefs.GetInt ("soundOn") == 1);
			Debug.Log ("Has sound key. Value = " + soundOn);
		}

		else
		{
			PlayerPrefs.SetInt ("soundOn", 1);
		}

		StartCoroutine (InvokeUpdatedValues ());
	}

	public void LoadRanking()
	{
		// TODO: Load Ranking.
	}

	public void ChangeSoundStatus()
	{
		soundOn = !soundOn;

		if(soundOn)
		{
			PlayerPrefs.SetInt ("soundOn", 1);
		}
		else
		{
			PlayerPrefs.SetInt ("soundOn", 0);
		}

		StartCoroutine (InvokeUpdatedValues ());
	}

	private IEnumerator InvokeUpdatedValues()
	{
		yield return null;
		UpdatedValues.Invoke ();
	}
}
