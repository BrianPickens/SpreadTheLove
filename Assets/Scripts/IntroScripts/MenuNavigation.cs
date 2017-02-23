using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MenuToGame(){
		if (TutorialModeScript.tutorialOff) {
			SceneManager.LoadScene ("prototype5");
		} else {
			TutorialModeScript.tutorialOff = true;
			GameObject.FindGameObjectWithTag ("SaveSettings").GetComponent<SaveSettingsScript> ().SaveSettings ();
			SceneManager.LoadScene ("Tutorial");
		}
			
	}

	public void MenuToUSHOP(){
		SceneManager.LoadScene ("UnicornShop");
	}

	public void MenuToSpread(){
		SceneManager.LoadScene ("SpreadTheLove");
	}
}
