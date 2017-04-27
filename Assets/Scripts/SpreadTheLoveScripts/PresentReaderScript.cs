using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentReaderScript : MonoBehaviour {

	public AudioClip[] Phrases;
	public Sprite[] Sprites;
	public float[] ReadTime;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GeneratePresentVoice(){
		int complimentChoice = Random.Range (0, 19);
		if (!SoundManager.AudioOff) {
			GetComponent<AudioSource> ().PlayOneShot (Phrases [complimentChoice]);
		}
		GetComponent<SpriteRenderer> ().sprite = Sprites [complimentChoice];
		StartCoroutine (TurnOffPopUp (complimentChoice));
	}

	IEnumerator TurnOffPopUp(int choice){
		yield return new WaitForSeconds(ReadTime [choice]);
		this.transform.parent.gameObject.SetActive (false);
		this.gameObject.SetActive (false);
	}
		
}
