using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	private bool gamePaused;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PauseButton(){
		if (!gamePaused) {
			Time.timeScale = 0;
			gamePaused = true;
		} else {
			Time.timeScale = 1;
			gamePaused = false;
		}


	}
}
