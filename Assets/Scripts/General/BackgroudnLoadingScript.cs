using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroudnLoadingScript : MonoBehaviour {

	IEnumerator Start(){
		AsyncOperation async = SceneManager.LoadSceneAsync ("prototype5");
		async.allowSceneActivation = false;
		Debug.Log ("Loading...");
		yield return async;

		Debug.Log ("Loading complete");
	}

}
