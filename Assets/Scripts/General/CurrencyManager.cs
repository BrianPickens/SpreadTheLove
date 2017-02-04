using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour {

	public static int unicornSmiles;

	private static CurrencyManager instance = null;
	public static CurrencyManager Instance {
		get{ return Instance; }
	}

	void Awake(){
		if (instance != null && Instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);

	}


	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
}
