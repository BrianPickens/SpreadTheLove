using UnityEngine;
using System.Collections;

public class HappySplodeScript : MonoBehaviour {

	// Use this for initialization

	void Start () {
	//start destroy self countdown when instantiated
		StartCoroutine (DestroySelf ());

	}

	IEnumerator DestroySelf(){
		//wait until end of particle effect length and then destroy self
		yield return new WaitForSeconds (2f);
		Destroy (this.gameObject);

	}
}
