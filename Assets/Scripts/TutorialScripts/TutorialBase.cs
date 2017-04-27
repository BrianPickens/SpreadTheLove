using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialBase : MonoBehaviour {

	public GameObject CandyHolder0;
	public GameObject CandyHolder1;
	public GameObject SpecialCollectables;
	public GameObject Unicorn;

	public Canvas tutorialCanvas;
	public Text instructionsTxt;
	public GameObject leftArrow;
	public GameObject rightArrow;
	public GameObject centerImg;
	public GameObject UnicornSprite;
	public GameObject TiltIcon;
	public GameObject Candy;
	public GameObject CandyTarget;
	public GameObject HappyMeter;
	public GameObject LittleUnicorn;
	public GameObject Heart;
	public GameObject HighlightedTree;
	public GameObject Flower;
	public GameObject CornerCandyTarget;
	public GameObject SideHappyMeter;

	// keeps track of what screen to turn off tutorial canvas.
	// Because arrays start at 0, make sure you add +1 to the screen you want to stop at so the arrays line up.
	// Eg. if you want to stop at screen 3, place a 4 into this array.
	public int[] turnOffTutCanvasAtScreen;

	public Image fillMeter;

	private bool movementTimerComplete;
	private bool candyOn;
	private bool specialCollectablesOn;

	// keeps track of screens
	private int t;

	// Each screen will have instructions
	[System.Serializable]
	public struct TutorialScreens{
		public string screenName;
		public string instructions;
//		public AnimationClip animation;
//		public Sprite sprite;
		public bool isUnicornSpriteOn;
		public bool isTiltIconOn;
		public bool isCandyOn;
		public bool isCandyTargetOn;
		public bool isCornerCandyTargetOn;
		public bool isHappyMeterOn;
		public bool isSideHappyMeterOn;
		public bool isLittleUnicornOn;
		public bool isHeartOn;
		public bool isHighlighedTreeOn;
		public bool isFlowerOn;
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
		Unicorn.GetComponent<UnicornMove> ().paused = true;

		// call change screen to start
		ChangeScreen ();
	}
	
	// Update is called once per frame
	void Update () {
		
		// Automatically see tutorial canvas at the beginning
		turnOnTutScreens (turnOffTutCanvasAtScreen[0]);

		// Put conditions to when you want to start/ stop tutorial canvas here!

		if (movementTimerComplete) {
			if (!candyOn) {
				CandyHolder0.SetActive (true);
				CandyHolder1.SetActive (true);
				candyOn = true;
			}
			turnOnTutScreens (turnOffTutCanvasAtScreen [1]);
		}

		// Turn on the tutorial canvas when the fillmeter is between 60% and 90%. Turn it off at turnOffTutCanvasAtScreen index 1;
		if (fillMeter.GetComponent<Image> ().fillAmount > .60f && fillMeter.GetComponent<Image> ().fillAmount < .90 && currentTutorialScreen < turnOffTutCanvasAtScreen[2]) {
			if (!specialCollectablesOn) {
				SpecialCollectables.SetActive (true);
				specialCollectablesOn = true;
			}
			turnOnTutScreens (turnOffTutCanvasAtScreen [2]);
		}

		if (fillMeter.GetComponent<Image> ().fillAmount > .99f && currentTutorialScreen >= turnOffTutCanvasAtScreen[1] && currentTutorialScreen < turnOffTutCanvasAtScreen[3]) {
			turnOnTutScreens (turnOffTutCanvasAtScreen [3]);
		}
			
		if (fillMeter.GetComponent<Image> ().fillAmount <.50f && currentTutorialScreen >= turnOffTutCanvasAtScreen[2] && currentTutorialScreen < turnOffTutCanvasAtScreen[4]) {
			turnOnTutScreens (turnOffTutCanvasAtScreen [4]);
		}
			
	}

	// detect if the screen has been touched
	private bool DetectTouch(){
		//http://answers.unity3d.com/questions/359754/how-can-i-detect-touch-on-anroid-or-iphone.html

		if (Input.touchCount == 1) {    
			// touch on screen
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().PlayClickSound ();
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
//			centerImg.GetComponent<Image>().sprite = tutScreenArray[t].sprite;
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

			if (tutScreenArray [t].isUnicornSpriteOn) {
				UnicornSprite.SetActive (true);
			} else {
				UnicornSprite.SetActive (false);
			}

			if (tutScreenArray [t].isTiltIconOn) {
				TiltIcon.SetActive (true);
			} else {
				TiltIcon.SetActive (false);
			}

			if (tutScreenArray [t].isCandyOn) {
				Candy.SetActive (true);
			} else {
				Candy.SetActive (false);
			}

			if (tutScreenArray [t].isCandyTargetOn) {
				CandyTarget.SetActive (true);
			} else {
				CandyTarget.SetActive (false);
			}

			if (tutScreenArray [t].isHappyMeterOn) {
				HappyMeter.SetActive (true);
			} else {
				HappyMeter.SetActive (false);
			}

			if (tutScreenArray [t].isLittleUnicornOn) {
				LittleUnicorn.SetActive (true);
			} else {
				LittleUnicorn.SetActive (false);
			}

			if (tutScreenArray [t].isHeartOn) {
				Heart.SetActive (true);
			} else {
				Heart.SetActive (false);
			}

			if (tutScreenArray [t].isHighlighedTreeOn) {
				HighlightedTree.SetActive (true);
			} else {
				HighlightedTree.SetActive (false);
			}

			if (tutScreenArray [t].isFlowerOn) {
				Flower.SetActive (true);
			} else {
				Flower.SetActive (false);
			}

			if (tutScreenArray [t].isCornerCandyTargetOn) {
				CornerCandyTarget.SetActive (true);
			} else {
				CornerCandyTarget.SetActive (false);
			}

			if (tutScreenArray [t].isSideHappyMeterOn) {
				SideHappyMeter.SetActive (true);
			} else {
				SideHappyMeter.SetActive (false);
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
			Unicorn.GetComponent<UnicornMove> ().paused = true;
			tutorialCanvas.enabled = true;
		} else {
			Time.timeScale = 1;
			Unicorn.GetComponent<UnicornMove> ().paused = false;
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
				if (currentTutorialScreen == 2) {
					StartCoroutine (StartMovementTimer ());
				}
				ChangeScreen ();
			}
		}
	}
		
	IEnumerator StartMovementTimer(){
		yield return new WaitForSeconds (10f);
		movementTimerComplete = true;
	}

}
