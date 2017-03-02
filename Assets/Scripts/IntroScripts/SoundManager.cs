using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

	public static bool AudioOff;
	public static bool SoundEffectsOff;
	public AudioClip IntroMenuMusic;
	public AudioClip IntroStart;
	public AudioClip LollipopMusic;

	public AudioMixer masterMixer;

	private static SoundManager instance = null;
	public static SoundManager Instance {
		get{ return Instance; }
	}

	void Awake(){
		if (instance != null && Instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);


	}



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartLollipopMusic(){
		if (!AudioOff) {
			masterMixer.SetFloat ("MusicVolume", 0f);
			masterMixer.SetFloat ("MusicLollipop", 0f);
		} else {
			masterMixer.SetFloat ("MusicVolume", -80f);
		}

		GetComponent<AudioSource> ().clip = LollipopMusic;
		GetComponent<AudioSource> ().Play ();
	}

	public void StartIntroMusic(){
		if (!AudioOff) {
			masterMixer.SetFloat ("MusicVolume", 0f);
			masterMixer.SetFloat ("MusicIntro", 0f);
		} else {
			masterMixer.SetFloat ("MusicVolume", -80f);
		}

		GetComponent<AudioSource> ().clip = IntroMenuMusic;
		GetComponent<AudioSource> ().Play ();
	}

	public void StartIntroStarting(){
		if (!AudioOff) {
			masterMixer.SetFloat ("MusicLollipop", -80f);
			masterMixer.SetFloat ("MusicVolume", 0f);
			masterMixer.SetFloat ("MusicIntro", 0f);
		} else {
			masterMixer.SetFloat ("MusicVolume", -80f);
		}

		GetComponent<AudioSource> ().clip = IntroStart;
		GetComponent<AudioSource> ().Play ();
	}

	public void StartGameMusic(){
		if (!AudioOff) {
			masterMixer.SetFloat ("MusicVolume", 0f);
			masterMixer.SetFloat ("MusicIntro", -80f);
			masterMixer.SetFloat ("MusicLow", 0f);
			masterMixer.SetFloat ("MusicMedium", -80f);
			masterMixer.SetFloat ("MusicHigh", -80f);
		} else {
			masterMixer.SetFloat ("MusicVolume", -80f);
		}
	}

	public void StartMediumMusic(){
		masterMixer.SetFloat ("MusicMedium", 0f);
	}

	public void StartSuperModeMusic(){
		masterMixer.SetFloat ("MusicHigh", 0f);
	}

	public void EndSuperModeMusic(){
		masterMixer.SetFloat ("MusicHigh", -80f);
	}

	public void TurnOffMusic(){
		masterMixer.SetFloat ("MusicVolume", -80f);
		//GetComponent<AudioSource> ().Stop ();
	}
}
