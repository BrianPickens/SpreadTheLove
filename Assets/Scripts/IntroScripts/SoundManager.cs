using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static bool AudioOff;
	public static bool SoundEffectsOff;
	public AudioClip IntroMenuMusic;
	public AudioClip GameMusic;

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

	public void StartIntroMusic(){
		if (!AudioOff) {
			GetComponent<AudioSource> ().clip = IntroMenuMusic;
			GetComponent<AudioSource> ().Play ();
		}
	}

	public void StartGameMusic(){
		if (!AudioOff) {
			GetComponent<AudioSource> ().clip = GameMusic;
			GetComponent<AudioSource> ().Play ();
		}
	}

	public void TurnOffMusic(){
		GetComponent<AudioSource> ().Stop ();
	}
}
