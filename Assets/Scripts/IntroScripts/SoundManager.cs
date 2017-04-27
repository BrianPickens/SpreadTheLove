using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {


	AudioSource TitleMusicSource;
	AudioSource ShopMusicSource;
	AudioSource RampMusicSource;
	AudioSource LollipopLowSource;
	AudioSource GameMusicLow;
	AudioSource GameMusicMedium;
	AudioSource GameMusicHigh;
	AudioSource ButtonEffects;

	public static bool AudioOff;
	public static bool SoundEffectsOff;
	public AudioClip IntroMenuMusic;
	public AudioClip IntroStart;
	public AudioClip LollipopMusic;
	public AudioClip ShopMusic;
	public AudioClip ClickSound;
	public AudioClip PoofSound;

	public AudioMixer masterMixer;

	private bool volumeDown;
	private float volume;
	private float volume2;
	private float volume3;
	private bool mediumOn;

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
		AudioSource[] audios = GetComponents<AudioSource> ();
		TitleMusicSource = audios [0];
		RampMusicSource = audios [1];
		LollipopLowSource = audios [2];
		ShopMusicSource = audios [3];
		GameMusicLow = audios [4];
		GameMusicMedium = audios [5];
		GameMusicHigh = audios [6];
		ButtonEffects = audios [7];

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayClickSound(){
		if (!AudioOff) {
			ButtonEffects.PlayOneShot (ClickSound);
		}
	}

	public void PlayPoofSound(){
		if (!AudioOff) {
			ButtonEffects.PlayOneShot (PoofSound);
		}
	}


	//huge list of transitions below

	public void IntroMusicPlay(){
		if (!AudioOff) {
			masterMixer.SetFloat ("MasterVolume", 0f);
		} else {
			masterMixer.SetFloat ("MasterVolume", -80f);
		}
		LollipopLowSource.Play ();
	}

	public void MenuMusicPlay(){
		if (!AudioOff) {
			masterMixer.SetFloat ("MasterVolume", 0f);
		} else {
			masterMixer.SetFloat ("MasterVolume", 80f);
		}
		TitleMusicSource.Play ();
	}

	public void MenuToShop (){
		if (!AudioOff) {
			StartCoroutine (FadeMenuToShop ());
		} else {
			masterMixer.SetFloat ("MasterVolume", -80f);
		}
		ShopMusicSource.Play ();
	}

	public void ShopToMenu(){
		if (!AudioOff) {
			StartCoroutine (FadeShopToMenu ());
		} else {
			masterMixer.SetFloat ("MasterVolume", -80f);
		}
		TitleMusicSource.Play ();
	}

	public void IntroToRamp(){
		if (!AudioOff) {
			StartCoroutine (FadeIntroToRamp());
		} else {
			masterMixer.SetFloat ("MasterVolume", -80f);
		}
		RampMusicSource.Play ();
	}

	public void RampToMenu(){
		if (!AudioOff) {
			
		} else {
			masterMixer.SetFloat ("MasterVolume", -80f);
		}
		TitleMusicSource.Play ();
	}

	public void MenuToGame(){
		if (!AudioOff) {
			masterMixer.SetFloat ("MusicMedium", -80f);
			masterMixer.SetFloat ("MusicHigh", -80f);
			StartCoroutine (FadeMenuToGame ());
		} else {
			masterMixer.SetFloat ("MasterVolume", -80f);
		}

		GameMusicLow.Play ();
		GameMusicMedium.Play ();
		GameMusicHigh.Play ();
	}

	public void GameToMenu(){
		if (!AudioOff) {
			StartCoroutine (FadeGameToMenu ());
		} else {
			masterMixer.SetFloat ("MasterVolume", -80f);
		}
		TitleMusicSource.Play ();
	}

	public void GameToShop(){
		if (!AudioOff) {
			StartCoroutine (FadeGameToShop ());
		} else {
			masterMixer.SetFloat ("MasterVolume", -80f);
		}
		ShopMusicSource.Play ();
	}

	public void RestartGameMusic(){
		if (!AudioOff) {
			StartCoroutine (FadeRestartGame ());
		} else {
			masterMixer.SetFloat ("MasterVolume", -80f);
		}
		GameMusicLow.Play ();
		GameMusicMedium.Play ();
		GameMusicHigh.Play ();
	}

	public void StartMediumMusic(){
		mediumOn = true;
		StartCoroutine (FadeLowToMedium ());
	}

	public void StartSuperModeMusic(){
		if (!mediumOn) {
			//StartCoroutine (FadeToSuperModeFromLow ());
			masterMixer.SetFloat ("MusicLow", -80);
			masterMixer.SetFloat ("MusicHigh", 0f);
		} else {
			//StartCoroutine (FadeToSuperModeFromMedium ());
			masterMixer.SetFloat ("MusicHigh", 0f);
		}
	}

	public void EndSuperModeMusic(){
		if (!mediumOn) {
			StartCoroutine (FadeOutSuperModeToLow ());
		} else {
			StartCoroutine (FadeOutSuperModeToMedium ());
		}
	}

	public void TurnOffMusic(){
		masterMixer.SetFloat ("MasterVolume", -80f);
		//GetComponent<AudioSource> ().Stop ();
	}
		
	IEnumerator FadeMenuToShop(){
		volume = 0;
		volume2 = -80f; 
		while (volume > -78) {
			volume -= 1;
			if (volume2 < 0) {
				volume2 += 10;
			}

			if (volume < -20) {
				volume = -80f;
			}
			masterMixer.SetFloat ("MusicMenu", volume);
			masterMixer.SetFloat ("MusicShop", volume2);
			yield return new WaitForSeconds (0.05f);
		}
	}

	IEnumerator FadeShopToMenu(){
		volume = 0;
		volume2 = -80f; 
		while (volume > -78) {
			volume -= 1;
			if (volume2 < 0) {
				volume2 += 10;
			}

			if (volume < -20) {
				volume = -80f;
			}
			masterMixer.SetFloat ("MusicShop", volume);
			masterMixer.SetFloat ("MusicMenu", volume2);
			yield return new WaitForSeconds (0.05f);
		}
	}

	IEnumerator FadeIntroToRamp(){
		volume = 0;
		volume2 = -80f; 
		while (volume > -78) {
			volume -= 1;
			if (volume2 < 0) {
				volume2 += 5;
			}

			if (volume < -20) {
				volume = -80f;
			}
			masterMixer.SetFloat ("MusicLollipop", volume);
			masterMixer.SetFloat ("MusicBuild", volume2);
			yield return new WaitForSeconds (0.05f);
		}
	}

	IEnumerator FadeMenuToGame(){
		volume = 0;
		volume2 = -80f; 
		while (volume > -78) {
			volume -= 1;
			if (volume2 < 0) {
				volume2 += 10;
			}

			if (volume < -20) {
				volume = -80f;
			}
			masterMixer.SetFloat ("MusicMenu", volume);
			masterMixer.SetFloat ("MusicLow", volume2);
			yield return new WaitForSeconds (0.05f);
		}
	}

//	IEnumerator FadeToSuperModeFromLow(){
//		volume = 0;
//		volume2 = -80f; 
//		while (volume > -78) {
//			volume -= 1;
//			if (volume2 < 0) {
//				volume2 += 10;
//			}
//
//			if (volume < -20) {
//				volume = -80f;
//			}
//			masterMixer.SetFloat ("MusicLow", volume);
//			masterMixer.SetFloat ("MusicHigh", volume2);
//
//
//
//			yield return new WaitForSeconds (0.05f);
//		}
//		masterMixer.SetFloat ("MusicLow", -80);
//		masterMixer.SetFloat ("MusicHigh", 0f);

//	}

//	IEnumerator FadeToSuperModeFromMedium(){
//		volume = 0;
//		volume2 = -80f; 
//		while (volume > -78) {
//			volume -= 1;
//			if (volume2 < 0) {
//				volume2 += 10;
//			}
//
//			if (volume < -20) {
//				volume = -80f;
//			}
//			masterMixer.SetFloat ("MusicHigh", volume2);
//			yield return new WaitForSeconds (0.05f);
//		}
//		masterMixer.SetFloat ("MusicHigh", 0f);
//	}

	IEnumerator FadeOutSuperModeToLow(){
		volume = 0;
		volume2 = -80f; 
		while (volume > -78) {
			volume -= 1;
			if (volume2 < 0) {
				volume2 += 10;
			}

			if (volume < -20) {
				volume = -80f;
			}
			masterMixer.SetFloat ("MusicHigh", volume);
			masterMixer.SetFloat ("MusicLow", volume2);
			yield return new WaitForSeconds (0.05f);
		}
	}

	IEnumerator FadeOutSuperModeToMedium(){
		volume = 0;
		volume2 = -80f; 
		while (volume > -78) {
			volume -= 1;
			if (volume2 < 0) {
				volume2 += 10;
			}

			if (volume < -20) {
				volume = -80f;
			}
			masterMixer.SetFloat ("MusicHigh", volume);
			yield return new WaitForSeconds (0.05f);
		}
	}

	IEnumerator FadeLowToMedium(){
		volume = 0;
		volume2 = -80f; 
		while (volume > -78) {
			volume -= 1;
			if (volume2 < 0) {
				volume2 += 5;
			}

			if (volume < -20) {
				volume = -80f;
			}
			masterMixer.SetFloat ("MusicLow", volume);
			masterMixer.SetFloat ("MusicMedium", volume2);
			yield return new WaitForSeconds (0.05f);
		}
	}

	IEnumerator FadeGameToMenu(){
		volume = 0;
		volume2 = -80f;
		float tempFloat;
		bool musicFloat = masterMixer.GetFloat ("MusicHigh", out tempFloat);
		if (!musicFloat) {

		} else {
			volume3 = tempFloat;
		}
		//volume3 = masterMixer.GetFloat ("MusicHigh");
		while (volume > -78) {
			volume -= 1;
			if (volume3 > -78) {
				volume3 -= 1;
			}

			if (volume2 < 0) {
				volume2 += 5;
			}

			if (volume < -20) {
				volume = -80f;
				volume3 = -80f;
			}
				
			masterMixer.SetFloat ("MusicMedium", volume);
			masterMixer.SetFloat ("MusicHigh", volume3);
			masterMixer.SetFloat ("MusicMenu", volume2);
			yield return new WaitForSeconds (0.05f);
		}
	}

	IEnumerator FadeGameToShop(){
		volume = 0;
		volume2 = -80f; 
		float tempFloat;
		bool musicFloat = masterMixer.GetFloat ("MusicHigh", out tempFloat);
		if (!musicFloat) {

		} else {
			volume3 = tempFloat;
		}
		//volume3 = masterMixer.GetFloat ("MusicHigh");
		while (volume > -78) {
			volume -= 1;
			if (volume3 > -78) {
				volume3 -= 1;
			}

			if (volume2 < 0) {
				volume2 += 5;
			}

			if (volume < -20) {
				volume = -80f;
				volume3 = -80f;
			}
			masterMixer.SetFloat ("MusicMedium", volume);
			masterMixer.SetFloat ("MusicHigh", volume3);
			masterMixer.SetFloat ("MusicShop", volume2);
			yield return new WaitForSeconds (0.05f);
		}
	}

	IEnumerator FadeRestartGame(){
		volume = 0;
		volume2 = -80f; 
		float tempFloat;
		bool musicFloat = masterMixer.GetFloat ("MusicHigh", out tempFloat);
		if (!musicFloat) {

		} else {
			volume3 = tempFloat;
		}
		//volume3 = masterMixer.GetFloat ("MusicHigh");
		while (volume > -78) {
			volume -= 1;
			if (volume3 > -78) {
				volume3 -= 1;
			}

			if (volume2 < 0) {
				volume2 += 5;
			}

			if (volume < -20) {
				volume = -80f;
				volume3 = -80f;
			}
			masterMixer.SetFloat ("MusicMedium", volume);
			masterMixer.SetFloat ("MusicHigh", volume3);
			masterMixer.SetFloat ("MusicLow", volume2);
			yield return new WaitForSeconds (0.05f);
		}
	}
}
