using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingEvents : MonoBehaviour {

	public static UnityEvent moveLeft;
	public static UnityEvent moveRight;
	public static UnityEvent stopMoving;

	void Awake()
	{
		if(moveLeft == null)
		{
			moveLeft = new UnityEvent ();
		}

		if(moveRight == null)
		{
			moveRight = new UnityEvent ();
		}

		if(stopMoving == null)
		{
			stopMoving = new UnityEvent ();
		}
	}

	public static void TryMoving(Direction dir)
	{
		if(dir == Direction.Left)
		{
			if(moveLeft != null)
			{
				moveLeft.Invoke ();
			}
		}
		else
		{
			if(moveRight != null)
			{
				moveRight.Invoke ();
			}
		}
	}

	public static void StopMoving()
	{
		if(stopMoving != null)
		{
			stopMoving.Invoke ();
		}
	}
}
