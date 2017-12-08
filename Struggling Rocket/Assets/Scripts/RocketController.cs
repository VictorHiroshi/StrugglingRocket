using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

	public float forwardSpeed = 1f;
	public float rotationSpeed = 30f;

	private Rigidbody2D mRigidBody;
	private Vector2 speed;

	void Awake()
	{
		mRigidBody = GetComponent <Rigidbody2D> ();

		speed = new Vector2 (0f, forwardSpeed);

		//mRigidBody.velocity = speed;
	}

	void Start()
	{
		MovingEvents.moveLeft.AddListener (MoveLeft);
		MovingEvents.moveRight.AddListener (MoveRight);
	}

	void Update()
	{
		mRigidBody.MoveRotation (-1f * rotationSpeed * Input.GetAxis ("Horizontal"));

		mRigidBody.AddForce (transform.up * forwardSpeed);
	}

	public void MoveLeft()
	{
		// TODO: Correctly move the player to the left.

		Debug.Log ("MoveLeft");

	}

	public void MoveRight()
	{
		// TODO: Correctly move the player to the left.

		Debug.Log ("MoveRight");
	}
}
