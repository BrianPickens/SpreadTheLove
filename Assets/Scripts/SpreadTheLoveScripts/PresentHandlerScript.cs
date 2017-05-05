using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PresentHandlerScript : MonoBehaviour {

	public bool isActive;
	public Sprite[] SenderNames;
	public GameObject NameDisplay;

	// Use this for initialization
	void Start () {
		int nameChoice = Random.Range (0, 4);
		NameDisplay.GetComponent<Image> ().sprite = SenderNames [nameChoice];
	}


	public void turnActive(){
		isActive = true;
	}

	public void turnInactive(){
		isActive = false;
	}


}
