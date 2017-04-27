using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class GiveComplimentsNetworkScript : MonoBehaviour {


	void Start () {


	}
		
	void Update () {

	}


	//used to give presents with old currency
//	public void givePresent() {
//		if (CurrencyManager.hearts > 5) {
//			CurrencyManager.hearts -= 5;
//			GetComponent<CurrencyManager> ().Save ();
//			string url = "http://brianpickens.pythonanywhere.com/givePresent";
//			WWW www = new WWW (url);
//			StartCoroutine (WaitForRequest (www));
//		}
//	}
	//end give presents with old currency
		
	public void giveCompliment(){
		GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().PlayClickSound ();
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
			//end present calling

			if (dict ["compliment"].Value == "Compliment Given") {
				//sent compliment now do something
			//	Debug.Log ("Compliment Given!");
			}

			//Debug.Log("WWW Ok!: " + dataFromCall);

		} else {
			Debug.Log("WWW Error: "+ www.error);
			foreach(string s in www.responseHeaders.Keys){
				Debug.Log(s);
			}
		}
	}
}

