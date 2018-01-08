using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour {

	public AudioMixer mixer;
	[Space]
	public float volumeOn = -10f;
	public float volumeOff = -80f;


	void Start () {

		GameController.UpdatedValues.AddListener (UpdateMusicStatus);

	}

	private void UpdateMusicStatus () {
		if(GameController.soundOn)
		{
			mixer.SetFloat ("MasterVolume", volumeOn);
		}

		else if(!GameController.soundOn)
		{
			mixer.SetFloat ("MasterVolume", volumeOff);
		}
	}
}
