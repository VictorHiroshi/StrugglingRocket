using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

public class Attractor : MonoBehaviour {

	private Rigidbody2D playerRB;
	private float attractionSpeed;
	private static float globalSpeedValue = 4f;

	void Awake () 
	{
		playerRB = GameObject.FindGameObjectWithTag ("Player").GetComponent <Rigidbody2D> ();
		attractionSpeed = globalSpeedValue;
	}

	void FixedUpdate ()
	{
		Vector2 distance = transform.position - playerRB.transform.position;

		playerRB.AddForce (distance.normalized * (1/distance.magnitude) * attractionSpeed);
	}

	public static void IncreaseAttractionSpeed(float extraSpeed)
	{
		globalSpeedValue += extraSpeed;
	}
}
