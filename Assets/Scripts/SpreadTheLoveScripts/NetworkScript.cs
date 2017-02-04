using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class NetworkScript : MonoBehaviour {

	//used for presents
	//public static bool activePresent;


	public static int activeCompliment;
	public bool checkForCompliments;
	public GameObject[] CommentIcons;
	public static bool[] complimentStates = new bool[4];



	// Use this for initialization
	void Start () {
		checkForCompliments = true;
//		use for presents
//		if (!activePresent) {
//			getPresent ();
//		}
		//Debug.Log(activeCompliment + " active at start");
		if (activeCompliment < 4) {
			//Debug.Log ("getting compliment");
			getCompliment ();
		} else {
			//Debug.Log ("Max compliments");
			UpdateCompliments ();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//give presents network calls using old currency
//	public void getPresent() {
//		string url = "http://brianpickens.pythonanywhere.com/getPresent";
//		WWW www = new WWW(url);
//		StartCoroutine(WaitForRequest(www));
//	}
//
//	public void givePresent() {
//		if (CurrencyManager.hearts > 5) {
//			CurrencyManager.hearts -= 5;
//			GetComponent<CurrencyManager> ().Save ();
//			string url = "http://brianpickens.pythonanywhere.com/givePresent";
//			WWW www = new WWW (url);
//			StartCoroutine (WaitForRequest (www));
//		}
//	}
	//end give presents network calls using old currency

	public void getCompliment(){
		string url = "http://brianpickens.pythonanywhere.com/getCompliment";
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

	public void giveCompliment(){
		string url = "http://brianpickens.pythonanywhere.com/giveCompliment";
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

	//General post to server
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			string dataFromCall = www.text;

			//Debug.Log(dataFromCall);

			var dict = JSON.Parse(dataFromCall);

			//for calling for presents from server
//			if(dict["present"].Value == "Present Given"){
//				//sent present now do something
//				Debug.Log("Present Given!");
//			}
//
//			if(dict["present"].Value == "Present Recieved"){
//				//recieved present now do something
//				activePresent = true;
//				Debug.Log("Present Recieved!");
//			}
//
//			if(dict["present"].Value == "Present Fail"){
//				//presents no happen
//				Debug.Log("No Presents!");
//			}
			//end present calling

			if (dict ["compliment"].Value == "Compliment Given") {
				//sent compliment now do something
				//Debug.Log ("Compliment Given!");
			}

			if (dict ["compliment"].Value == "Compliment Recieved") {
				//recieved compliment now do someting
				activeCompliment++;
				if (activeCompliment < 4) {
					getCompliment ();
				}
				GameObject.FindGameObjectWithTag ("SaveSettings").GetComponent<SaveSettingsScript> ().SaveSettings ();
				UpdateCompliments ();
				//Debug.Log ("Compliment Recieved " + dict ["message"].Value);
			} //else {
				//UpdateCompliments ();
				//Debug.Log ("No compliments from else");
			//}

			if (dict ["compliment"].Value == "Compliment Fail") {
				//compliments no happening
				UpdateCompliments();
				//Debug.Log ("No Compliments!");
			}

			//Debug.Log("WWW Ok!: " + dataFromCall);

		} else {
			Debug.Log("WWW Error: "+ www.error);
			foreach(string s in www.responseHeaders.Keys){
				Debug.Log(s);
			}
		}
	}

	//need to check so that it cycles through to see which ones are already active
	public void UpdateCompliments(){
		//turn on already active presents - cycles through them and if they are turned on, then turn them on.
		int activeComplimentTemp = activeCompliment;
		int i = 0;
		while (i < 4) {
			if (complimentStates [i]) {
				CommentIcons [i].SetActive (true);
				//CommentIcons [i].GetComponent<PresentHandlerScript> ().isActive = true;
				activeComplimentTemp--;
			}
			i++;
		}

		//turn on any new presents - checks for the next unoped present slot and turns it on if there are presents left to give
		int j = 0;
		//Debug.Log (activeCompliment + " compliments when updating");
		while (j < 4) {
		//	Debug.Log (activeCompliment);
			if (!complimentStates [j] && activeComplimentTemp != 0) {
				CommentIcons [j].SetActive (true);
				complimentStates [j] = true;
				activeComplimentTemp--;
			}
			j++;

		}
	}

	//turning off presents
	public void Comment1Viewed(){
		complimentStates [0] = false;
		CommentIcons [0].SetActive (false);
		activeCompliment--;
		GameObject.FindGameObjectWithTag ("SaveSettings").GetComponent<SaveSettingsScript> ().SaveSettings ();
	}

	public void Comment2Viewed(){
		complimentStates [1] = false;
		CommentIcons [1].SetActive (false);
		activeCompliment--;
		GameObject.FindGameObjectWithTag ("SaveSettings").GetComponent<SaveSettingsScript> ().SaveSettings ();
	}

	public void Comment3Viewed(){
		complimentStates [2] = false;
		CommentIcons [2].SetActive (false);
		activeCompliment--;
		GameObject.FindGameObjectWithTag ("SaveSettings").GetComponent<SaveSettingsScript> ().SaveSettings ();
	}

	public void Comment4Viewed(){
		complimentStates [3] = false;
		CommentIcons [3].SetActive (false);
		activeCompliment--;
		GameObject.FindGameObjectWithTag ("SaveSettings").GetComponent<SaveSettingsScript> ().SaveSettings ();
	}
	//end turning off presents
}
