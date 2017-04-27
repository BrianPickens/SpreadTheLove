using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreControllerScript : MonoBehaviour {

	public Text UnicornCurrencyDisplay;
	public GameObject[] ComplimentPages;
	public GameObject ComplimentConfirmation;
	public Image LeftArrow;
	public Image RightArrow;
	public Sprite YellowArrow;
	public Sprite BlueArrow;

	public int complimentPageMax;
	private int complimentPageMin;
	private int currentComplimentPage;

	public int smilesCost;

	void Start () {
		complimentPageMin = 0;
		currentComplimentPage = 0;
		ComplimentPages [currentComplimentPage].SetActive (true);
		UpdateCurrency ();
		UpdateArrows ();
	}

	void Update () {




	}

	public void UpdateCurrency(){
		UnicornCurrencyDisplay.text = "" + CurrencyManager.unicornSmiles;
	}

	public void ComplimentStoreRight(){
		if (currentComplimentPage < complimentPageMax-1) {
			GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().PlayClickSound ();
			ComplimentPages [currentComplimentPage].SetActive (false);
			currentComplimentPage++;
			ComplimentPages [currentComplimentPage].SetActive (true);
			UpdateArrows ();
		}

	}

	public void ComplimentStoreLeft(){
		if (currentComplimentPage > complimentPageMin) {
			GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().PlayClickSound ();
			ComplimentPages [currentComplimentPage].SetActive (false);
			currentComplimentPage--;
			ComplimentPages [currentComplimentPage].SetActive (true);
			UpdateArrows ();
		}
	}

	public void UpdateArrows(){
		if (currentComplimentPage == complimentPageMax-1) {
			//Debug.Log ("MAX");
			RightArrow.GetComponent<Image> ().sprite = BlueArrow;
		} else {
			RightArrow.GetComponent<Image> ().sprite = YellowArrow;
		//	Debug.Log ("beign Called");
		}
		if (currentComplimentPage == 0) {
			LeftArrow.GetComponent<Image> ().sprite = BlueArrow;
		//	Debug.Log ("MIN");
		} else {
			LeftArrow.GetComponent<Image> ().sprite = YellowArrow;
		//	Debug.Log ("beign Called");
		}


	}

	public void YoureGreat(){

		smilesCost = 0;
	}

	public void YoureBeautiful(){

		smilesCost = 0;
	}

	public void YouMakeMeHappy(){

		smilesCost = 0;
	}

	public void WhoseCool(){
		smilesCost = 10000;
	}

	public void ChargeUnicornSmiles(){
		CurrencyManager.unicornSmiles = CurrencyManager.unicornSmiles - smilesCost;
		GameObject.FindGameObjectWithTag ("SaveSettings").GetComponent<SaveSettingsScript> ().SaveSettings ();
		UpdateCurrency ();
		ComplimentConfirmation.SetActive (true);
		//do a completion animation
	}

	public void CloseComplimentConfirmation(){
		GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().PlayClickSound ();
		ComplimentConfirmation.SetActive (false);
	}


}
