using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBase : MonoBehaviour {

	public Canvas tutorialCanvas;
	public Text instructionsTxt;
	// array of UI image objects in the tutorial canvas.
	public Image[] tutImages;
	public int turnOffTutScreenAtOne=2;
	public int turnOffTutScreenAtTwo=4;
	public Image fillMeter;
	// Each screen will have instructions
	// Icons are optional
	[System.Serializable]
	public struct TutorialScreens{
		public string instructions;
		public Sprite[] icons;

	}

	public TutorialScreens[] tutScreenArray;
	private int currentTutorialScreen=0;
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// NEEDS TO BE MADE INTO SEpERATE FUNCTION
		if (currentTutorialScreen <= turnOffTutScreenAtOne && tutorialCanvas.enabled==true) {
			if (DetectTouch ()) {
				ChangeScreen ();
			}
		} 
		else {
			isCanvasOn (false);
			turnOffTutScreenAtOne = 4;

		}

		//Debug.Log ("fillMeter.GetComponent<Image> ().fillAmount: "+ fillMeter.GetComponent<Image> ().fillAmount);
		if (fillMeter.GetComponent<Image> ().fillAmount > .70f && fillMeter.GetComponent<Image> ().fillAmount < .90 && currentTutorialScreen <= turnOffTutScreenAtOne) {
			isCanvasOn (true);
		}

//		} else if (currentTutorialScreen <= turnOffTutScreenAt) {
//			isCanvasOn (false);
//		}
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

	private void ChangeScreen(){

//		if (currentTutorialScreen != turnOffTutScreenAt) {
			currentTutorialScreen++;
			int t = currentTutorialScreen;
		Debug.Log ("currentTutorialScreen: "+ currentTutorialScreen);
			instructionsTxt.text = tutScreenArray [t].instructions;

			// loop through icons and assign them to images on the canvas
			// as long as both arrays are not null
			if (tutScreenArray[t].icons.Length !=0) {
//				int p = 0;
//				foreach (Image img in tutImages) {
//					img.enabled = true;
//				}
				for (int i = 0; i < tutImages.Length; i++) {
					if (i >= tutScreenArray[t].icons.Length) {
						break;
					}
					tutImages [i].enabled = true;
					Debug.Log ("i: " + i + " tutImages.Length: " + tutImages.Length);
					Debug.Log ("i: " + i + " tutScreenArray [t].icons: " + tutScreenArray [t].icons.Length);
					tutImages [i].sprite = tutScreenArray [t].icons [i];
//					for (int j = p; j < tutScreenArray [t].icons.Length; j++) {
//						tutImages [i].sprite = tutScreenArray [t].icons;

//					}
				}
//					foreach (Sprite s in tutScreenArray[t].icons) {
//						img.sprite = s;
//						break;
//					}
			} else {
				foreach (Image img in tutImages) {
					img.enabled = false;
					Debug.Log ("Img: "+img+ " bool: "+ img.enabled);
				}
			}
//			// if there are no icons assigned to a screen, diable each image on the canvas
//			if (tutScreenArray [t].icons.Length ==0) {
//				foreach (Image img in tutImages) {
//					img.enabled = false;
//				}
//			}
		// Turn off tutorial screen for gameplay
//		} else {
//			Time.timeScale = 1;
//			tutorialCanvas.enabled = false;
//		}

	}

	private void isCanvasOn(bool switchOn){
		if (switchOn) {
			Time.timeScale = 0;
			tutorialCanvas.enabled = true;
		} else {
			Time.timeScale = 1;
			tutorialCanvas.enabled = false;
		}
	}
		
}
