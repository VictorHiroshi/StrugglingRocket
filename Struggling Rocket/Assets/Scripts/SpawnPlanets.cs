using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlanets : MonoBehaviour {

	public GameObject planetModel;
	public float spawnRangeXAxis = 10f;
	public float spawnDistanceFromCamera = 15f;
	public float delayBetweenPlanetSpawning = 2f;

	private Vector2 position;
	private WaitForSeconds delayTime;

	void Start()
	{
		delayTime = new WaitForSeconds (delayBetweenPlanetSpawning);

		StartCoroutine (Spawn (60));
	}

	private IEnumerator Spawn(int numPlanets)
	{
		for(int i=0; i<numPlanets; i++)
		{
			position.x = transform.position.x + Random.Range (-spawnRangeXAxis, spawnRangeXAxis);
			position.y = transform.position.y + spawnDistanceFromCamera;

			Instantiate (planetModel, position, Quaternion.identity);

			yield return delayTime;
		}
	}
}
