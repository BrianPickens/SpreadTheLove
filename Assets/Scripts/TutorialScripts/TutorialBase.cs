using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBase : MonoBehaviour {

	public Canvas tutorialCanvas;
	public Text instructionsTxt;
	// array of UI image objects in the tutorial canvas.
	public Image[] tutImages;
	public int[] turnOffTutCanvasAtScreen;
//	public int turnOffTutScreenAtOne=2;
//	public int turnOffTutScreenAtTwo=4;
	public Image fillMeter;
	// Each screen will have instructions
	// Icons are optional
	[System.Serializable]
	public struct TutorialScreens{
		public string screenName;
		public string instructions;
		public Sprite[] icons;

	}

	public TutorialScreens[] tutScreenArray;
	private int currentTutorialScreen=0;
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
//		switchOnCanvas (true);

		ChangeScreen ();
	}
	
	// Update is called once per frame
	void Update () {
		// Automatically see tutorial canvas at the beginning
		turnOnTutScreens (turnOffTutCanvasAtScreen[0]);

		//Debug.Log ("fillMeter.GetComponent<Image> ().fillAmount: "+ fillMeter.GetComponent<Image> ().fillAmount);
		if (fillMeter.GetComponent<Image> ().fillAmount > .70f && fillMeter.GetComponent<Image> ().fillAmount < .90 && currentTutorialScreen < turnOffTutCanvasAtScreen[1]) {
			turnOnTutScreens (turnOffTutCanvasAtScreen [1]);
		}
			
	}

	// detect if the screen has been touched
	private bool DetectTouch(){
		//http://answers.unity3d.com/questions/359754/how-can-i-detect-touch-on-anroid-or-iphone.html

		if (Input.touchCount == 1) {    
			// touch on screen
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				return true;
			}
		}
		return false;
	}

	// change the screen
	private void ChangeScreen(){
		// make sure you don't get an array index out of range error
		if(currentTutorialScreen != tutScreenArray.Length){
			int t = currentTutorialScreen;
//			Debug.Log ("currentTutorialScreen: "+ currentTutorialScreen);
//			Debug.Log ("tutScreenArray.Length: "+ tutScreenArray.Length);
//	//		if (currentTutorialScreen <= tutScreenArray.Length - 1) {
				instructionsTxt.text = tutScreenArray [t].instructions;


				// loop through icons and assign them to images on the canvas
				// as long as both arrays are not null
				if (tutScreenArray [t].icons.Length != 0) {

					for (int i = 0; i < tutImages.Length; i++) {
						if (i >= tutScreenArray [t].icons.Length) {
							break;
						}
						tutImages [i].enabled = true;
						Debug.Log ("i: " + i + " tutImages.Length: " + tutImages.Length);
						Debug.Log ("i: " + i + " tutScreenArray [t].icons: " + tutScreenArray [t].icons.Length);
						tutImages [i].sprite = tutScreenArray [t].icons [i];
					}
				} else {
					foreach (Image img in tutImages) {
						img.enabled = false;
						Debug.Log ("Img: " + img + " bool: " + img.enabled);
					}
				}
		}

	}
	
	// turns canvas on and off
	private void switchOnCanvas(bool switchOn){
		if (switchOn) {
			Time.timeScale = 0;
			tutorialCanvas.enabled = true;
		} else {
			Time.timeScale = 1;
			tutorialCanvas.enabled = false;
		}
	}

	// turns on/off tutorial canvas
	private void turnOnTutScreens(int turnOffTutScreenNum){
		switchOnCanvas (true);
		// if the current screen does not equal the screen you want to turn the tutorial canvas off at
		// also if the canvas is already enabled
		// switch the tutorial canvas off
		if (currentTutorialScreen >= turnOffTutScreenNum && tutorialCanvas.enabled==true) {
			switchOnCanvas (false);

		}
		else {
			if (DetectTouch ()) {
				currentTutorialScreen++;
				ChangeScreen ();
			}
		}
	}
		
}
