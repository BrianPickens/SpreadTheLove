using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SadUnicornIntro : MonoBehaviour {

	public GameObject SadParticles;
	public GameObject HappyParticles;
	public GameObject LoveParticles;
	public GameObject CanvasTitle;
	public GameObject SoundHolder;
	public GameObject StarParticles;
	public GameObject OptionsPanel;

	public Sprite HappyUnicorn;
	public Sprite SadUnicorn;
	public Sprite LollipopUnicorn;

	public GameObject Cloud;
	public GameObject Lollipop;
	public AudioClip LovePoof;

	private bool hasLollipop;

	Animator _myanim;

	// Use this for initialization
	void Start () {
		_myanim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Return)) {
			hasLollipop = true;
			LollipopAcquired ();
		}

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Lollipop") {
			SadParticles.SetActive (false);
			HappyParticles.SetActive (true);
			GetComponent<SpriteRenderer> ().sprite = HappyUnicorn;
			Cloud.GetComponent<CloudIntro> ().HappyCloud ();
			StarParticles.SetActive (true);
			hasLollipop = true;
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Lollipop") {
			SadParticles.SetActive (true);
			HappyParticles.SetActive (false);
			GetComponent<SpriteRenderer> ().sprite = SadUnicorn;
			Cloud.GetComponent<CloudIntro> ().SadCloud ();
			StarParticles.SetActive (false);
			hasLollipop = false;
		}
	}

	public void LollipopAcquired(){
		if (hasLollipop) {
			SadParticles.SetActive (false);
			LoveParticles.SetActive (true);
			HappyParticles.SetActive (true);
			StarParticles.SetActive (true);
			GetComponent<AudioSource> ().PlayOneShot (LovePoof);
			GetComponent<SpriteRenderer> ().sprite = LollipopUnicorn;
			Lollipop.GetComponent<LollipopControl> ().DestroyLollipop ();
			StartCoroutine (WaitOnCamera ());

		}

	}

	public void SlideInUnicorn(){
		Cloud.GetComponent<CloudIntro> ().SlideInCloud ();
		_myanim.SetBool ("SlideIn", true);
	}

	IEnumerator WaitOnCamera(){
		yield return new WaitForSeconds (3.4f);
		SoundHolder.GetComponent<SoundManager> ().RampToMenu();
		CanvasTitle.GetComponent<DropIntroCanvasScript> ().DropCanvas ();
		OptionsPanel.GetComponent<SlideOptionsScript> ().SlideOptionsIn ();
		Cloud.GetComponent<CloudIntro> ().SlideOutCloud ();
		StarParticles.GetComponent<ParticleSystem> ().Stop ();
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("Menu");
	}
}
