using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Events;

public class Values : MonoBehaviour {

	public static bool soundOn = true;

	public static UnityEvent UpdatedValues;

	public void Awake()
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

	}

	void Start()
	{
		UpdatedValues.Invoke ();
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

		UpdatedValues.Invoke ();
	}

}
