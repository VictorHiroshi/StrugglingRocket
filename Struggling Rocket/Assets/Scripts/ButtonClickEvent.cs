using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public enum Direction {Left, Right};

public class ButtonClickEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

	public Direction directionButton;
	private IEnumerator mCoroutine;

	public void OnPointerDown(PointerEventData eventData)
	{
		mCoroutine = Clicking ();
		StartCoroutine (mCoroutine);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		StopCoroutine (mCoroutine);
	}

	private IEnumerator Clicking()
	{
		while (true) 
		{
			MovingEvents.TryMoving (directionButton);
			yield return null;
		}
	}
}
