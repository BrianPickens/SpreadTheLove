using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PresentHandlerScript : MonoBehaviour {

	public bool isActive;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	


	}

	public void turnActive(){
		isActive = true;
	}

	public void turnInactive(){
		isActive = false;
	}


}
