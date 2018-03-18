using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public static GameOver instance;
	public Text gameOverText;
	public Button restartButton;
	[Space]
	public GameObject rankedUserPanel;
	public Text getUserText;
	public Text getUserInputText;

	private bool finishedInput;

	void Awake () {
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy (this);
		}

		gameOverText.gameObject.SetActive (false);
		restartButton.gameObject.SetActive (false);
		rankedUserPanel.SetActive (false);
	}

	public void Restart()
	{
		Attractor.ResetAtrractionSpeed ();

		PlayAd.instance.PlayAdAndLoadScene ("GameScene");
	}

	public void RunGameOver(float distance)
	{
		SpawnPlanets.GameOver ();

		int index;
		UserData newUser = new UserData ();
		newUser.distanceTraveled = distance;

		gameOverText.gameObject.SetActive (true);

		if(GameController.instance.CheckIfTop (newUser, out index))
		{
			StartCoroutine (GetUserName (newUser, index));
		}

		else
		{
			restartButton.gameObject.SetActive (true);
		}
	}

	public void ConfirmUserName()
	{
		finishedInput = true;
	}

	private IEnumerator GetUserName(UserData newUser, int index)
	{
		rankedUserPanel.SetActive (true);
		getUserText.text = string.Format ("Congratulations. You're new {0}{1} position in ranking!", index+1, GetCardinal (index));

		finishedInput = false;

		while(!finishedInput)
		{
			yield return null;
		}

		newUser.nickName = getUserInputText.text;
		GameController.instance.AddRankedUser (newUser, index);

		rankedUserPanel.gameObject.SetActive (false);

		restartButton.gameObject.SetActive (true);
	}

	public string GetCardinal(int i)
	{
		i++;
		if(i == 1)
		{
			return "st";
		}
		else if(i == 2)
		{
			return "nd";
		}
		else if(i == 3)
		{
			return "rd";
		}

		return "th";
	}
}
