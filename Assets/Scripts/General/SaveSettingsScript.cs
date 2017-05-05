using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSettingsScript : MonoBehaviour {

	public GameObject SoundManagerHolder;

	public static SaveSettingsScript settings = null;


	void Awake(){
		if (settings == null) {
			DontDestroyOnLoad (gameObject);
			settings = this;
		} else if (settings != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (this.gameObject);

	}




	// Use this for initialization
	void Start () {
		SetSettings ();
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log ("I'm Working");
//		if (Input.GetKeyDown(KeyCode.Space)) {
//			Debug.Log ("Save Deleted");
//			PlayerPrefs.DeleteAll ();
//			PlayerPrefs.SetInt ("MusicOff", (0));
//			PlayerPrefs.SetInt ("ActiveCompliments", (0));
//			PlayerPrefs.SetInt ("UnicornSmiles", (0));
//			PlayerPrefs.SetInt ("TutorialOff", (0));
//			Debug.Log ("Save Deleted");
//		}

	}

	public void SetSettings(){
		SoundManager.AudioOff = (PlayerPrefs.GetInt ("MusicOff") != 0);
		NetworkScript.activeCompliment = PlayerPrefs.GetInt ("ActiveCompliments");
		CurrencyManager.unicornSmiles = PlayerPrefs.GetInt ("UnicornSmiles");
		TutorialModeScript.tutorialOff = (PlayerPrefs.GetInt ("TutorialOff") != 0);

	//	Debug.Log (CurrencyManager.unicornSmiles);
	}

	public void SaveSettings(){
		PlayerPrefs.SetInt ("MusicOff", (SoundManager.AudioOff ? 1 : 0));
		PlayerPrefs.SetInt ("ActiveCompliments", (NetworkScript.activeCompliment));
		PlayerPrefs.SetInt ("UnicornSmiles", (CurrencyManager.unicornSmiles));
		PlayerPrefs.SetInt ("TutorialOff", (TutorialModeScript.tutorialOff ? 1 : 0));
	}
		

}
