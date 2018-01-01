using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public AudioSource audioSource;

	private bool isPlaying;
	// Use this for initialization


	void Start () {
		isPlaying = true;

		Values.UpdatedValues.AddListener (UpdateMusicStatus);

	}
	

	private void UpdateMusicStatus () {
		if(Values.soundOn && !isPlaying)
		{
			isPlaying = true;
			audioSource.Play ();
		}

		else if(!Values.soundOn && isPlaying)
		{
			isPlaying = false;
			audioSource.Stop ();
		}
	}
}
