using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OvertimeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (DestroyOvertime ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator DestroyOvertime(){
		yield return new WaitForSeconds (2f);
		Destroy (this.gameObject);
	}
}
