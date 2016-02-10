using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	static AudioSource audio;

	void Awake () {
		audio = GetComponent<AudioSource> ();
	}

	public static void Play(AudioClip clip){
		audio.Stop ();
		audio.clip = clip;
		audio.Play ();
	}
}
