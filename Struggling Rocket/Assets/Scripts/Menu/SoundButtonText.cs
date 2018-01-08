using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonText : MonoBehaviour {

	public Text buttonText;
	public string soundOnText;
	public string soundOffText;

	public void Start()
	{
		GameController.UpdatedValues.AddListener (UpdateButtonText);
		UpdateButtonText ();
	}

	public void Click()
	{
		GameController.instance.ChangeSoundStatus ();
	}

	public void UpdateButtonText()
	{
		if(GameController.soundOn)
		{
			buttonText.text = soundOnText;
		}

		else
		{
			buttonText.text = soundOffText;
		}
	}
}
