using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialModeScript : MonoBehaviour {

	public Sprite ToggleOn;
	public Sprite ToggleOff;

	public static bool tutorialOff;
	public GameObject TutorialSwitch;

	public bool musicOff;
	public GameObject MusicSwitch;

	void Start () {
		CorrectToggle ();
	}
	

	void Update () {

	}

	public void ToggleTutorialMode(){

		if (tutorialOff) {
			tutorialOff = false;
			TutorialSwitch.GetComponent<Image> ().sprite = ToggleOn;
		} else {
			tutorialOff = true;
			TutorialSwitch.GetComponent<Image> ().sprite = ToggleOff;
		}
		GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().PlayClickSound ();
		GameObject.FindGameObjectWithTag ("SaveSettings").GetComponent<SaveSettingsScript> ().SaveSettings ();
	}

	public void ToggleMusicMode(){

		if (musicOff) {
			musicOff = false;
			SoundManager.AudioOff = false;
			GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().MenuMusicPlay ();
			MusicSwitch.GetComponent<Image> ().sprite = ToggleOn;
		} else {
			musicOff = true;
			SoundManager.AudioOff = true;
			GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().TurnOffMusic ();
			MusicSwitch.GetComponent<Image> ().sprite = ToggleOff;
		}

		GameObject.FindGameObjectWithTag ("SaveSettings").GetComponent<SaveSettingsScript> ().SaveSettings ();
	}

	public void CorrectToggle(){
		if (!SoundManager.AudioOff) {
			MusicSwitch.GetComponent<Image> ().sprite = ToggleOn;
			musicOff = false;
		} else {
			MusicSwitch.GetComponent<Image> ().sprite = ToggleOff;
			musicOff = true;
		}

		if (!tutorialOff) {
			TutorialSwitch.GetComponent<Image> ().sprite = ToggleOn;
		} else {
			TutorialSwitch.GetComponent<Image> ().sprite = ToggleOff;
		}
	}
}
