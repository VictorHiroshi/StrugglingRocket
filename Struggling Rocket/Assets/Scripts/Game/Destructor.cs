using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
	{
		GameObject other = coll.gameObject;
		if(other.tag == "Planet")
		{
			Destroy (other);
		}
	}
}
