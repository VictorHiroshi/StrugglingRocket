using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankedUserScript : MonoBehaviour {

	public Text userName;
	public Text userScore;

	public void SetValues(string name, string score)
	{
		userName.text = name;
		userScore.text = score;
	}
}
