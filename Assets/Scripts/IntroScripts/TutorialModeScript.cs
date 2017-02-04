using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialModeScript : MonoBehaviour {

	public static bool tutorialMode;
	public Toggle TutorialToggle;

	public static bool musicMode;
	public Toggle MusicToggle;

	// Use this for initialization
	void Start () {
		CorrectToggle ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToggleTutorialMode(){

		if (TutorialToggle.isOn) {
			tutorialMode = true;
		}

		if (!TutorialToggle.isOn) {
			tutorialMode = false;
		}
		//Debug.Log (tutorialMode);
	}

	public void ToggleMusicMode(){
		if (MusicToggle.isOn) {
			//musicMode = true;
			SoundManager.AudioOff = false;
			GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().StartIntroMusic ();
			GameObject.FindGameObjectWithTag ("SaveSettings").GetComponent<SaveSettingsScript> ().SaveSettings ();
		}

		if (!MusicToggle.isOn) {
			//musicMode = false;
			SoundManager.AudioOff = true;
			GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().TurnOffMusic ();
			GameObject.FindGameObjectWithTag ("SaveSettings").GetComponent<SaveSettingsScript> ().SaveSettings ();
		}
		//Debug.Log (tutorialMode);
	}

	public void CorrectToggle(){
		if (!SoundManager.AudioOff) {
			MusicToggle.isOn = true;
		} else {
			MusicToggle.isOn = false;
		}
	}
}
