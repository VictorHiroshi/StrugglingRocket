using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Runtime.Serialization;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public static UnityEvent UpdatedValues;
	public static bool soundOn = true;

	public int maxInstancesInRanking = 10;

	public List<UserData> localRanking;


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
		}

		else
		{
			PlayerPrefs.SetInt ("soundOn", 1);
		}
			
		localRanking = new List<UserData> ();

		LoadRanking ();

		StartCoroutine (InvokeUpdatedValues ());
	}

	public void LoadRanking()
	{
		// TODO: Load Ranking from file or create new empty file.
		if (File.Exists (Application.persistentDataPath + "/ranking.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/ranking.dat", FileMode.Open);
			Debug.Log (file);
			List<UserData> data = (List<UserData>)bf.Deserialize (file);
			file.Close ();

			localRanking = data;
		}
	}

	public void ClearRanking() {
		localRanking = new List<UserData> ();

		File.Delete (Application.persistentDataPath + "/ranking.dat");

		UpdateRankingFile ();

		Debug.Log ("clear");
		StartCoroutine (InvokeUpdatedValues ());
	}

	public void AddRankedUser(UserData user)
	{
		int index;

		if(CheckIfTop (user, out index))
		{
			localRanking.Insert (index, user);

			while(localRanking.Count>maxInstancesInRanking)
			{
				localRanking.RemoveAt (localRanking.Count - 1);
			}

			UpdateRankingFile ();
		}
	}

	public void AddRankedUser(UserData user, int index)
	{
		localRanking.Insert (index, user);

		while(localRanking.Count>maxInstancesInRanking)
		{
			localRanking.RemoveAt (localRanking.Count - 1);
		}

		UpdateRankingFile ();
	}

	public bool CheckIfTop(UserData user, out int index)
	{
		index = 0;

		for(int i = 0; i<localRanking.Count; i++)
		{
			if(user.IsGreaterThan (localRanking[i]))
			{
				index = i;
				return true;
			}
		}

		if(localRanking.Count<maxInstancesInRanking)
		{
			index = localRanking.Count;
			return true;
		}

		return false;
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

	private void UpdateRankingFile()
	{
		Debug.Log ("Updating file!");

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/ranking.dat");

		bf.Serialize (file, localRanking);

		file.Close ();
	}
}
