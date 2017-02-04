using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CloudIntro : MonoBehaviour {

	public Sprite CloudHappy;
	public Sprite CloudSad;

	// Use this for initialization
	void Start () {

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
}
