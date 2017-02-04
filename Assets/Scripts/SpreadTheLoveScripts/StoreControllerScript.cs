using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreControllerScript : MonoBehaviour {

	public Text UnicornCurrencyDisplay;
	public GameObject[] ComplimentPages;
	public GameObject ComplimentConfirmation;

	public int complimentPageMax;
	private int complimentPageMin;
	private int currentComplimentPage;

	public int smilesCost;

	void Start () {
		complimentPageMin = 0;
		currentComplimentPage = 0;
		ComplimentPages [currentComplimentPage].SetActive (true);
		UpdateCurrency ();
	}

	void Update () {

	}

	public void UpdateCurrency(){
		UnicornCurrencyDisplay.text = "" + CurrencyManager.unicornSmiles;
	}

	public void ComplimentStoreRight(){
		if (currentComplimentPage < complimentPageMax-1) {
			ComplimentPages [currentComplimentPage].SetActive (false);
			currentComplimentPage++;
			ComplimentPages [currentComplimentPage].SetActive (true);
		}

	}

	public void ComplimentStoreLeft(){
		if (currentComplimentPage > complimentPageMin) {
			ComplimentPages [currentComplimentPage].SetActive (false);
			currentComplimentPage--;
			ComplimentPages [currentComplimentPage].SetActive (true);
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
		ComplimentConfirmation.SetActive (false);
	}


}
