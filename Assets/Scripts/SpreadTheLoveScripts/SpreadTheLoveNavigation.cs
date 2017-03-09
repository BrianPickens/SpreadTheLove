using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpreadTheLoveNavigation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpreadToMenu(){
		GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager> ().ShopToMenu ();
		SceneManager.LoadScene ("Menu");
	}
}
