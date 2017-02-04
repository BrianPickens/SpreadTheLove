using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpecialCollectablesScript : MonoBehaviour {

	public GameObject[] Characters;
	public int newCharacters;

	// Use this for initialization
	void Start () {
		CreateCharacters ();
	}
	
	// Update is called once per frame
	void Update () {
		while (newCharacters > 0) {
			int characterNumber = Random.Range (0, 12);
			if (!Characters [characterNumber].GetComponent<SittingUnicornScript> ().currentlyActive) {
				Characters [characterNumber].SetActive (true);
				Characters [characterNumber].GetComponent<SittingUnicornScript> ().currentlyActive = true;
				newCharacters--;
			}
		}
	}

	public void CreateCharacters(){
		int i = 0;
		while (i < 5) {
			int characterNumber = Random.Range (0, 12);
			if (!Characters [characterNumber].GetComponent<SittingUnicornScript> ().currentlyActive) {
				Characters [characterNumber].SetActive (true);
				Characters [characterNumber].GetComponent<SittingUnicornScript> ().currentlyActive = true;
				i++;
			}
		}
	}

	public void NewCharacter(){
		newCharacters++;
	}
}
