using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialBase : MonoBehaviour {

	public Canvas tutorialCanvas;
	public Text instructionsTxt;
	public GameObject leftArrow;
	public GameObject rightArrow;
	public GameObject centerImg;

	// keeps track of what screen to turn off tutorial canvas.
	// Because arrays start at 0, make sure you add +1 to the screen you want to stop at so the arrays line up.
	// Eg. if you want to stop at screen 3, place a 4 into this array.
	public int[] turnOffTutCanvasAtScreen;

	public Image fillMeter;

	// keeps track of screens
	private int t;

	// Each screen will have instructions
	[System.Serializable]
	public struct TutorialScreens{
		public string screenName;
		public string instructions;
		public AnimationClip animation;
		public Sprite sprite;
		public bool isLeftArrowOn;
		public bool isRightArrowOn;
		public bool isTutorialDone;
	}

	public TutorialScreens[] tutScreenArray;
	private int currentTutorialScreen=0;

	// Use this for initialization
	void Start () {
		// stops the game at the beginning
		Time.timeScale = 0;

		// call change screen to start
		ChangeScreen ();
	}
	
	// Update is called once per frame
	void Update () {
		// Automatically see tutorial canvas at the beginning
		turnOnTutScreens (turnOffTutCanvasAtScreen[0]);

		// Put conditions to when you want to start/ stop tutorial canvas here!

		// Turn on the tutorial canvas when the fillmeter is between 60% and 90%. Turn it off at turnOffTutCanvasAtScreen index 1;
		if (fillMeter.GetComponent<Image> ().fillAmount > .60f && fillMeter.GetComponent<Image> ().fillAmount < .90 && currentTutorialScreen < turnOffTutCanvasAtScreen[1]) {
			turnOnTutScreens (turnOffTutCanvasAtScreen [1]);
		}
			
		if (fillMeter.GetComponent<Image> ().fillAmount <.50f && currentTutorialScreen >= turnOffTutCanvasAtScreen[1] && currentTutorialScreen < turnOffTutCanvasAtScreen[2]) {
			turnOnTutScreens (turnOffTutCanvasAtScreen [2]);
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

			// keep track of current screen
			t = currentTutorialScreen;

			instructionsTxt.text = tutScreenArray [t].instructions;

//			if (tutScreenArray[t].animation != null) {
//				centerImg.GetComponent<Animation> ().clip = tutScreenArray [t].animation;
//			}else {
			centerImg.GetComponent<Image>().sprite = tutScreenArray[t].sprite;
//			}

			if (tutScreenArray [t].isLeftArrowOn) {
				leftArrow.SetActive (true);
			} else {
				leftArrow.SetActive (false);
			}

			if (tutScreenArray [t].isRightArrowOn) {
				rightArrow.SetActive (true);
			} else {
				rightArrow.SetActive (false);
			}

			if (tutScreenArray[t].isTutorialDone) {
				SceneManager.LoadScene("Menu");
			}
				// loop through icons and assign them to images on the canvas
				// as long as both arrays are not null
//				if (tutScreenArray [t].icons.Length != 0) {
//
//					for (int i = 0; i < tutImages.Length; i++) {
//						if (i >= tutScreenArray [t].icons.Length) {
//							break;
//						}
//						tutImages [i].enabled = true;
//						Debug.Log ("i: " + i + " tutImages.Length: " + tutImages.Length);
//						Debug.Log ("i: " + i + " tutScreenArray [t].icons: " + tutScreenArray [t].icons.Length);
//						tutImages [i].sprite = tutScreenArray [t].icons [i];
//					}
//				} else {
//					foreach (Image img in tutImages) {
//						img.enabled = false;
//						Debug.Log ("Img: " + img + " bool: " + img.enabled);
//					}
//				}
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
