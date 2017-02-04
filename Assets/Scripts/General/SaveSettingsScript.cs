using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSettingsScript : MonoBehaviour {

	private static SaveSettingsScript instance = null;
	public static SaveSettingsScript Instance {
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
		SetSettings ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("I'm Working");
		if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log ("Save Deleted");
			PlayerPrefs.DeleteAll ();
			Debug.Log ("Save Deleted");
		}

	}

	public void SetSettings(){
		SoundManager.AudioOff = (PlayerPrefs.GetInt ("MusicOff") != 0);
		NetworkScript.activeCompliment = PlayerPrefs.GetInt ("ActiveCompliments");
		CurrencyManager.unicornSmiles = PlayerPrefs.GetInt ("UnicornSmiles");
	//	Debug.Log (CurrencyManager.unicornSmiles);
	}

	public void SaveSettings(){
		PlayerPrefs.SetInt ("MusicOff", (SoundManager.AudioOff ? 1 : 0));
		PlayerPrefs.SetInt ("ActiveCompliments", (NetworkScript.activeCompliment));
		PlayerPrefs.SetInt ("UnicornSmiles", (CurrencyManager.unicornSmiles));
	}
		

}
