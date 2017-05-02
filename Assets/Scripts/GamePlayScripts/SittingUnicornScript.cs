using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SittingUnicornScript : MonoBehaviour {

	public bool currentlyActive;
	public bool triggered;

	public Sprite HappyUnicorn;
	public Sprite SadUnicorn;


	public GameObject [] Phrases;
	public AudioClip[] PhraseClips;


	public int typeOfUnicorn;

	// Use this for initialization
	void Start () {
		typeOfUnicorn = Random.Range (0, 3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UnicornChange(){

		if (!triggered) {
			GetComponent<SpriteRenderer> ().sprite = HappyUnicorn;
			Phrases [typeOfUnicorn].SetActive (true);
			if (!SoundManager.AudioOff) {
				GetComponent<AudioSource> ().PlayOneShot (PhraseClips [typeOfUnicorn]);
			}
//			switch (typeOfUnicorn) {
//			case 0:
//				Happy.SetActive (true);
//				if (!SoundManager.AudioOff) {
//					GetComponent<AudioSource> ().PlayOneShot (HappyClip);
//				}
//				break;
//
//			case 1:
//				Beautiful.SetActive (true);
//				if (!SoundManager.AudioOff) {
//					GetComponent<AudioSource> ().PlayOneShot (BeautifulClip);
//				}
//				break;
//
//			case 2:
//				Great.SetActive (true);
//				if (!SoundManager.AudioOff) {
//					GetComponent<AudioSource> ().PlayOneShot (GreatClip);
//				}
//				break;
//
//			default:
//
//				break;
//			}
		}
		triggered = true;
		StartCoroutine (ResetUnicorn ());
	}

	IEnumerator ResetUnicorn(){
		gameObject.tag = "Untagged";
		yield return new WaitForSeconds (3f);
		GetComponentInParent<SpecialCollectablesScript> ().NewCharacter ();
		Phrases [typeOfUnicorn].SetActive (false);
		typeOfUnicorn = Random.Range (0, 3);
//		Happy.SetActive (false);
//		Beautiful.SetActive (false);
//		Great.SetActive (false);
		triggered = false;
		currentlyActive = false;
		gameObject.tag = "Unicorn";
		gameObject.SetActive (false);
	}
}
