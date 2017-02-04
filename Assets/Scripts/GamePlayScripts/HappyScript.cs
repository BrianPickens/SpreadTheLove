using UnityEngine;
using System.Collections;

public class HappyScript : MonoBehaviour {

	public Component[] ItemScripts;

	// Use this for initialization
	void Start () {

		ItemScripts = GetComponentsInChildren<IncreaseHappyScript> ();

	}

	// Update is called once per frame
	void Update () {

	}

	public void UpdateItems(){

		foreach (IncreaseHappyScript script in ItemScripts){
			script.ItemChange ();
		}
	}
}
