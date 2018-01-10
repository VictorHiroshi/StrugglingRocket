using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public RocketController player;

	private float distance;

	void Start()
	{
		distance = 0f;
	}

	void Update()
	{
		scoreText.text = "Distance: " + player.distance.ToString ("F2");
	}
}
