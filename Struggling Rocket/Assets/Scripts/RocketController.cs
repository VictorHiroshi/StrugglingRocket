using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

	public float forwardSpeed = 1f;
	public float rotationSpeed = 30f;
	public Sprite[] explodingSprites;
	public ParticleSystem particles;

	[HideInInspector]public bool canBeMoved;

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

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "Planet")
		{
			GameOver ();
		}
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

	private void GameOver()
	{
		mRigidBody.simulated = false;

		StartCoroutine (Explode ());

		particles.Stop ();

		SpawnPlanets.GameOver ();
	}

	private IEnumerator Explode()
	{
		SpriteRenderer sprite = GetComponent <SpriteRenderer> ();
		WaitForSeconds delay = new WaitForSeconds (0.2f);

		if(sprite != null)
		{
			yield return delay;

			for(int i=0; i< explodingSprites.Length; i++)
			{
				sprite.sprite = explodingSprites [i];
				yield return delay;
			}

			sprite.enabled = false;
		}
	}
}
