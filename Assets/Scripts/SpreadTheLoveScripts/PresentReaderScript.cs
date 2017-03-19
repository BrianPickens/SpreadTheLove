using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentReaderScript : MonoBehaviour {

	public AudioClip[] Phrases;
	public Sprite[] Sprites;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GeneratePresentVoice(){
		int complimentChoice = Random.Range (0, 3);
		GetComponent<AudioSource> ().PlayOneShot (Phrases[complimentChoice]);
		GetComponent<SpriteRenderer> ().sprite = Sprites [complimentChoice];
	}

	IEnumerator TurnOffPopUp(){
		yield return new WaitForSeconds(2f);
		this.gameObject.SetActive (false);
	}
		
}
