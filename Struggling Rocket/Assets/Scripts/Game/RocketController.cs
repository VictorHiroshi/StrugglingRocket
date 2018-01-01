using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour {

	public float forwardSpeed = 1f;
	public float rotationSpeed = 30f;
	public Sprite[] explodingSprites;
	public ParticleSystem particles;
	public Canvas gameOverCanvas;
	public float maxFuelCapacity = 100f;
	[Space]

	public AudioSource audioSource;
	public AudioClip[] explosionsSounds;

	[Space]

	public GameObject leftJet;
	public GameObject rightJet;

	[HideInInspector]public bool canBeMoved;

	private IEnumerator alignRotationCoroutine;
	private float rotation;
	private Rigidbody2D mRigidBody;


	void Awake()
	{
		mRigidBody = GetComponent <Rigidbody2D> ();

		gameOverCanvas.enabled = false;

		leftJet.SetActive (false);
		rightJet.SetActive (false);

		rotation = 0f;
		alignRotationCoroutine = RealignSpaceship ();
	}

	void Start()
	{
		MovingEvents.moveLeft.AddListener (MoveLeft);
		MovingEvents.moveRight.AddListener (MoveRight);
		MovingEvents.stopMoving.AddListener (StopMoving);
	}

	void Update()
	{
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

		if(rotation<1f)
		{
			rotation += 0.1f;
		}

		StopCoroutine (alignRotationCoroutine);

		rightJet.SetActive (true);

		mRigidBody.MoveRotation (rotationSpeed * rotation);
	}

	public void MoveRight()
	{

		if(rotation>-1f)
		{
			rotation -= 0.1f;
		}

		StopCoroutine (alignRotationCoroutine);

		leftJet.SetActive (true);

		mRigidBody.MoveRotation (rotationSpeed * rotation);
	}

	public void StopMoving()
	{

		StopCoroutine (alignRotationCoroutine);
		StartCoroutine (alignRotationCoroutine);

		leftJet.SetActive (false);
		rightJet.SetActive (false);
	}

	public void Restart()
	{
		Attractor.ResetAtrractionSpeed ();
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void GameOver()
	{
		mRigidBody.simulated = false;

		StartCoroutine (Explode ());

		particles.Stop ();

		SpawnPlanets.GameOver ();

		MovingEvents.moveLeft.RemoveListener (MoveLeft);
		MovingEvents.moveRight.RemoveListener (MoveRight);
	}

	private IEnumerator Explode()
	{
		SpriteRenderer sprite = GetComponent <SpriteRenderer> ();
		WaitForSeconds delay = new WaitForSeconds (0.2f);

		audioSource.clip = explosionsSounds [Random.Range (0, explosionsSounds.Length)];
		audioSource.Play ();

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

		yield return delay;

		gameOverCanvas.enabled = true;
	}

	private IEnumerator RealignSpaceship()
	{
		while(rotation != 0)
		{
			rotation = Mathf.SmoothStep (rotation, 0f, 0.2f);

			mRigidBody.MoveRotation (rotationSpeed * rotation);

			yield return null;
		}
	}
}
