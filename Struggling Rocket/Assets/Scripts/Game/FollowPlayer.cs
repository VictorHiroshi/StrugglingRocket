using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform player;
	public float cameraDistanceToPlayer = 3f;

	private Vector3 newPos;

	// Update is called once per frame
	void Update () {
		newPos = player.position;
		newPos.z = transform.position.z;
		newPos.y += cameraDistanceToPlayer;
		transform.position = newPos;
	}
}
