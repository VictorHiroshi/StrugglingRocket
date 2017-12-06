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
	[Space]
	public float minPlanetDist = 10f;

	private Vector2 position;
	private Vector2 lastPlanetPosition;
	private WaitForSeconds delayTime;
	private WaitForSeconds waveDelay;
	private GameObject instace;

	void Start()
	{
		delayTime = new WaitForSeconds (delayBetweenPlanetSpawning);
		waveDelay = new WaitForSeconds (delayBetwennSpawningWaves);

		StartCoroutine (Spawn (SpawnWaveSize));

		lastPlanetPosition = Vector2.zero;
	}

	private IEnumerator Spawn(int numPlanets)
	{
		for(int i=0; i<numPlanets; i++)
		{
			position.x = transform.position.x + Random.Range (-spawnRangeXAxis, spawnRangeXAxis);
			position.y = transform.position.y + spawnDistanceFromCamera;

			if((position-lastPlanetPosition).magnitude < minPlanetDist)
			{
				i--;
			}
			else
			{
				instace = planetModel [Random.Range (0, planetModel.Length)];

				instace = Instantiate (instace, position, Quaternion.identity);

				float scale = Random.Range (0.8f, 3f);

				instace.transform.localScale = new Vector3 (scale, scale, -1f);

				lastPlanetPosition = position;
			}

			yield return delayTime;
		}

		SpawnWaveSize++;
		Attractor.IncreaseAttractionSpeed (extraPlanetForcePerWave);

		yield return waveDelay;

		StartCoroutine (Spawn (SpawnWaveSize));
	}
}
