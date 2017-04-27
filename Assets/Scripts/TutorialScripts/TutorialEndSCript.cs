using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEndSCript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (DetectTouch()) {
			this.gameObject.SetActive (false);
		}

	}

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
}
