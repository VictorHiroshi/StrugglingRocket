using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public Transform player;

	private float distance;

	void Start()
	{
		distance = 0f;
	}

	void LateUpdate()
	{
		if (player.position.y > distance)
			distance = player.position.y;

		scoreText.text = "Distance: " + distance.ToString ("F2");
	}
}
