using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonText : MonoBehaviour {

	public Text buttonText;
	public string soundOnText;
	public string soundOffText;

	public void Awake()
	{
		Values.UpdatedValues.AddListener (UpdateButtonText);
	}

	public void UpdateButtonText()
	{
		if(Values.soundOn)
		{
			buttonText.text = soundOnText;
		}

		else
		{
			buttonText.text = soundOffText;
		}
	}
}
