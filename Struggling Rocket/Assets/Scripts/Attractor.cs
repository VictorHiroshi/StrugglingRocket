using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

	private Rigidbody2D playerRB;
	private float attractionSpeed = 4f;

	void Awake () 
	{
		playerRB = GameObject.FindGameObjectWithTag ("Player").GetComponent <Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		Vector2 distance = transform.position - playerRB.transform.position;

		playerRB.AddForce (distance.normalized * (1/distance.magnitude) * attractionSpeed);
	}
}
