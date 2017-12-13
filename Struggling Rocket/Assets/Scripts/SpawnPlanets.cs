using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnPlanets : MonoBehaviour {

	public GameObject[] planetModel;
	public float extraPlanetForcePerWave = 0.2f;
	[Space]
	public float spawnRangeXAxis = 10f;
	public float spawnDistanceFromCamera = 15f;
	[Space]
	public float delayBetweenPlanetSpawning = 2f;
	public float delayBetwennSpawningWaves = 5f;
	public int SpawnWaveSize = 10;

	private Vector2 position;
	private WaitForSeconds delayTime;
	private WaitForSeconds waveDelay;
	private GameObject instance;
	private static bool gameOver;

	void Start()
	{
		delayTime = new WaitForSeconds (delayBetweenPlanetSpawning);
		waveDelay = new WaitForSeconds (delayBetwennSpawningWaves);
		gameOver = false;

		StartCoroutine (Spawn (SpawnWaveSize));
	}

	public static void GameOver()
	{
		gameOver = true;
		Debug.Log ("Stop Spawning Planets");
	}

	private IEnumerator Spawn(int numPlanets)
	{
		for(int i=0; i<numPlanets; i++)
		{
			if(gameOver)
			{
				break;
			}
			position.x = transform.position.x + Random.Range (-spawnRangeXAxis, spawnRangeXAxis);
			position.y = transform.position.y + spawnDistanceFromCamera;

			instance = planetModel [Random.Range (0, planetModel.Length)];

			instance = Instantiate (instance, position, Quaternion.identity);

			float scale = Random.Range (0.8f, 3f);

			instance.transform.localScale = new Vector3 (scale, scale, -1f);


			if(CollideWithOderPlanet (instance))
			{
				i--;
			}

			yield return delayTime;
		}

		SpawnWaveSize++;
		Attractor.IncreaseAttractionSpeed (extraPlanetForcePerWave);

		yield return waveDelay;

		if (!gameOver)
		{
			StartCoroutine (Spawn (SpawnWaveSize));
		}
	}

	private bool CollideWithOderPlanet(GameObject instance)
	{
		// TODO: Check if collides with other planets. If yes, delete instance.
		return false;
	}
}
