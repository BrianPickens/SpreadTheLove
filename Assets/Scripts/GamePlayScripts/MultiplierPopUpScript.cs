using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MultiplierPopUpScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "X" + UnicornMove.multiplier;
		StartCoroutine (RemovePopUp ());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator RemovePopUp(){
		yield return new WaitForSeconds (1.5f);
		Destroy (transform.parent.gameObject);
	}
}
