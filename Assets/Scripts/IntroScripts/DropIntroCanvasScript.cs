using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropIntroCanvasScript : MonoBehaviour {

	private Animator _myAnim;

	// Use this for initialization
	void Start () {
		_myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DropCanvas(){
		_myAnim.SetBool ("DropTitle", true);
	}
}
