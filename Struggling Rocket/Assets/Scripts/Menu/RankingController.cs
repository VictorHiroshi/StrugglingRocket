using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingController : MonoBehaviour {

	public Transform rankingCanvas;
	public GameObject rankedUserPrefab;
	public int maxInstances = 10;

	private List<GameObject> rankObjects = new List<GameObject> ();

	void Start () 
	{
		PopulateRanking ();
		GameController.UpdatedValues.AddListener (UpdateRanking);
	}
	
	private void PopulateRanking()
	{
		int count = 0;

		foreach(UserData user in GameController.instance.localRanking)
		{
			count++;
			if (count > maxInstances)
				return;
			
			GenerateInstance (user.nickName, user.distanceTraveled);
		}
	}

	private void GenerateInstance(string name, float distance)
	{
		GameObject rankedUserInstance = Instantiate (rankedUserPrefab, rankingCanvas);

		rankedUserInstance.GetComponent <RankedUserScript>().SetValues (name, distance.ToString ("F2"));

		rankObjects.Add (rankedUserInstance);
	}

	private void UpdateRanking () 
	{
		foreach(GameObject rankedUser in rankObjects)
		{
			Destroy (rankedUser);
		}

		rankObjects.Clear ();
	}
}
