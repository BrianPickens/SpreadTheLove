using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LollipopControl : MonoBehaviour {
	private Vector2 startPos;
	private Vector2 direction;
	private Vector2 fingerPos;
	private bool followFinger;

	public float fingerVerticalOffset;
	public float fingerHorizontalOffset;

	private Transform myTransform;

	public Sprite BackgroundGood;

	public GameObject StarParticles;
	public GameObject Unicorn;
	public GameObject Background;
	public GameObject BackgroundMusic;

	private float holdTime;
	private bool unicornSlide;

	Animator _myanim;

	void Start (){
		holdTime = 1f;
		_myanim = GetComponent<Animator> ();
		myTransform = GetComponent<Transform> ();
		fingerPos = GetComponent<Transform> ().position;

	}

	void Update() {
		for (var i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				//Debug.Log (i + " Touch Start");

				RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);

				if(hitInfo)
				{
					switch (hitInfo.collider.tag) {
					case "Lollipop":
						//Debug.Log ("Lollipop");
						followFinger = true;
						fingerPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position);
						StarParticles.SetActive (true);
						break;

					default:
						//Debug.Log ("MISSED");
						break;

					}
				}
			}

			if (Input.GetTouch (i).phase == TouchPhase.Moved) {
				if (followFinger) {
					fingerPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position);
				}

				//Debug.Log (i + " Touch Moved");
			}

			if (Input.GetTouch (i).phase == TouchPhase.Ended) {
				followFinger = false;
				StarParticles.SetActive (false);
				Unicorn.GetComponent<SadUnicornIntro> ().LollipopAcquired ();
				//Debug.Log (i + " Touch Ended");

			}
		}

		if (followFinger) {
			_myanim.SetBool ("LollipopGrabbed", true);
			myTransform.position = fingerPos + new Vector2 (fingerHorizontalOffset, fingerVerticalOffset);
			holdTime -= Time.deltaTime;
			if (holdTime < 0 && !unicornSlide) {
				Unicorn.GetComponent<SadUnicornIntro> ().SlideInUnicorn ();
				unicornSlide = true;
			}
		} else {
			_myanim.SetBool ("LollipopGrabbed", false);
		}

	}

	public void DestroyLollipop(){
		Background.GetComponent<Image> ().color = Color.white;
		Background.GetComponent<Image> ().sprite = BackgroundGood;
		BackgroundMusic.GetComponent<SoundManager> ().IntroToRamp ();
		Destroy (this.gameObject);
	}
}