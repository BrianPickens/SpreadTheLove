using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideOptionsScript : MonoBehaviour {

	private Animator _myAnim;

	// Use this for initialization
	void Start () {
		_myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SlideOptionsIn(){
		_myAnim.SetBool ("OptionsSlideIn", true);
	}
}
