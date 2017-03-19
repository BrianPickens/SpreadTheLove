using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CloudIntro : MonoBehaviour {

	public Sprite CloudHappy;
	public Sprite CloudSad;

	private Animator _myanim;

	private bool cloudSlideIn;
	private bool cloudSlideOut;

	// Use this for initialization
	void Start () {
		_myanim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void HappyCloud(){
		GetComponent<SpriteRenderer> ().sprite = CloudHappy;
	}

	public void SadCloud(){
		GetComponent<SpriteRenderer> ().sprite = CloudSad;
	}

	public void SlideInCloud(){
		_myanim.SetBool ("CloudSlideIn", true);
	}

	public void SlideOutCloud(){
		_myanim.SetBool ("CloudSlideOut", true);
	}
}
