using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LoveMeterFill : MonoBehaviour {

	public GameObject Unicorn;
	public GameObject HeartIndicator;
	public GameObject ItemHolder;
	public Button LoveButtonButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (GetComponent<Image> ().fillAmount > .99f && !UnicornMove.superMode) {
			LoveButtonButton.interactable = true;
			HeartIndicator.SetActive (true);
		}
			
	}
		
	public void AddLove(){
		if (UnicornMove.superMode) {
			GetComponent<Image> ().fillAmount += 0.05f;
		} else {
			GetComponent<Image> ().fillAmount += 0.1f;
		}

	}

	public void AddUnicornLove(){
		if (UnicornMove.superMode) {
			GetComponent<Image> ().fillAmount += 0.1f;
		} else {
			GetComponent<Image> ().fillAmount += 0.2f;
		}
	}

	public void LoveButton(){
		LoveButtonButton.interactable = false;
		HeartIndicator.SetActive (false);
		Unicorn.GetComponent<UnicornMove> ().LoveMeterFull ();
		//ChangeEverything ();
		//GetComponent<Image> ().fillAmount = 0f;
		InvokeRepeating("DrainHappyMeter", 0f, 0.1f);
	}

	void ChangeEverything(){
		ItemHolder.GetComponent<HappyScript> ().UpdateItems ();
	}

	void DrainHappyMeter(){
		GetComponent<Image> ().fillAmount -= 0.007f;
		if (GetComponent<Image> ().fillAmount <= 0f) {
			CancelInvoke ();
			GetComponent<Image> ().fillAmount = 0f;
			Unicorn.GetComponent<UnicornMove> ().EndSuperMode ();
		}
	}
}
