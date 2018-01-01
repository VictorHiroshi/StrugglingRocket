using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour {

	public AudioMixer mixer;
	public float volumeOn = -10f;
	public float volumeOff = -80f;

	public void Start()
	{
		UpdateSounds ();
	}

	public void UpdateSounds()
	{
		if(Values.soundOn)
		{
			mixer.SetFloat ("MasterVolume", volumeOn);
		}
		else
		{
			mixer.SetFloat ("MasterVolume", volumeOff);
		}
	}
}
