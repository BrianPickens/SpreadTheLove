using UnityEngine;
using System.Collections;

public class HappyCircle : MonoBehaviour {

	public GameObject UnicornPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){


		if (other.gameObject.tag == "Flower") {
			other.GetComponent<IncreaseHappyScript> ().ItemChange ();
			if (other.GetComponent<IncreaseHappyScript> ().itemState < 3) {
				UnicornPlayer.GetComponent<UnicornMove> ().UpdateScore (300);
				UnicornPlayer.GetComponent<UnicornMove> ().FadeInDayTime ();
			}
		}

		if (other.gameObject.tag == "Tree") {
			other.GetComponent<IncreaseHappyScript> ().ItemChange ();
			if (other.GetComponent<IncreaseHappyScript> ().itemState < 3) {
				UnicornPlayer.GetComponent<UnicornMove> ().FadeInDayTime ();
			}
		}

//		if (other.gameObject.tag == "Cloud") {
//			other.GetComponent<IncreaseHappyScript> ().ItemChange ();
//			if (other.GetComponent<IncreaseHappyScript> ().itemState < 3) {
//				UnicornPlayer.GetComponent<UnicornMove> ().FadeInDayTime ();
//			}
//		}

		if (other.gameObject.tag == "Planet") {
			other.GetComponent<IncreaseHappyScript> ().ItemChange ();
			if (other.GetComponent<IncreaseHappyScript> ().itemState < 3) {
				UnicornPlayer.GetComponent<UnicornMove> ().UpdateScore (300);
				UnicornPlayer.GetComponent<UnicornMove> ().FadeInDayTime ();
			}
		}

		if (other.gameObject.tag == "Star") {
			other.GetComponent<IncreaseHappyScript> ().ItemChange ();
			if (other.GetComponent<IncreaseHappyScript> ().itemState < 3) {
				UnicornPlayer.GetComponent<UnicornMove> ().UpdateScore (300);
				UnicornPlayer.GetComponent<UnicornMove> ().FadeInDayTime ();
			}
		}
	}
}
