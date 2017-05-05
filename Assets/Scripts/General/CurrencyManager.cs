using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour {

	public static int unicornSmiles;

	public static CurrencyManager currency;


	void Awake(){
		if (currency == null) {
			DontDestroyOnLoad (gameObject);
			currency = this;
		} else if (currency != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (this.gameObject);

	}
		
		
}
