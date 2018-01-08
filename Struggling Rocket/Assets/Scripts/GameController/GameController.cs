using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Runtime.Serialization;
/*using System.Linq;*/

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
		UserData temporaryUser;

		for(int i = 0; i<15; i++)
		{
			temporaryUser = new UserData ();
			temporaryUser.nickName = "monkey" + i + "@";
			temporaryUser.distanceTraveled = Random.Range (10f, 2000f);

			AddRankedUser (temporaryUser);
		}

		temporaryUser = new UserData ();
		temporaryUser.nickName = "Karin";
		temporaryUser.distanceTraveled = 2000f;
		AddRankedUser (temporaryUser);

	}

	public void AddRankedUser(UserData user)
	{
		bool changedList = false;

		for(int i = 0; i<localRanking.Count; i++)
		{
			if(user.IsGreaterThan (localRanking[i]))
			{
				localRanking.Insert (i, user);
				changedList = true;
				break;
			}
		}

		if(!changedList)
		{
			localRanking.Add (user);
		}

		if(localRanking.Count>maxInstancesInRanking)
		{
			localRanking.RemoveAt (localRanking.Count - 1);

			if(!changedList)
			{
				return;
			}
		}

		UpdateRankingFile ();
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
		// TODO.

		Debug.Log ("Updating file!");
	}
}
