using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SadUnicornIntro : MonoBehaviour {

	public GameObject SadParticles;
	public GameObject HappyParticles;
	public GameObject LoveParticles;
	public GameObject CanvasTitle;

	public Sprite HappyUnicorn;
	public Sprite SadUnicorn;
	public Sprite LollipopUnicorn;

	public GameObject Cloud;
	public GameObject Lollipop;
	public AudioClip LovePoof;

	private bool hasLollipop;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Lollipop") {
			SadParticles.SetActive (false);
			HappyParticles.SetActive (true);
			GetComponent<SpriteRenderer> ().sprite = HappyUnicorn;
			Cloud.GetComponent<CloudIntro> ().HappyCloud ();
			hasLollipop = true;
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Lollipop") {
			SadParticles.SetActive (true);
			HappyParticles.SetActive (false);
			GetComponent<SpriteRenderer> ().sprite = SadUnicorn;
			Cloud.GetComponent<CloudIntro> ().SadCloud ();
			hasLollipop = false;
		}
	}

	public void LollipopAcquired(){
		if (hasLollipop) {
			LoveParticles.SetActive (true);
			GetComponent<AudioSource> ().PlayOneShot (LovePoof);
			GetComponent<SpriteRenderer> ().sprite = LollipopUnicorn;
			Lollipop.GetComponent<LollipopControl> ().DestroyLollipop ();
			StartCoroutine (WaitOnCamera ());

		}

	}

	IEnumerator WaitOnCamera(){
		yield return new WaitForSeconds (25.45f);
		CanvasTitle.GetComponent<DropIntroCanvasScript> ().DropCanvas ();
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("Menu");
	}
}
