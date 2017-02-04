using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MenuToGame(){
		SceneManager.LoadScene ("prototype5");
	}

	public void MenuToUSHOP(){
		SceneManager.LoadScene ("UnicornShop");
	}

	public void MenuToSpread(){
		SceneManager.LoadScene ("SpreadTheLove");
	}
}
