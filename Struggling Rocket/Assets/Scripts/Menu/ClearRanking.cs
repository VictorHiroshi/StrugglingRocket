using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearRanking : MonoBehaviour {

	public void InvokeClearRanking()
	{
		//TODO: add confirming pop up
		GameController.instance.ClearRanking ();
	}
}
