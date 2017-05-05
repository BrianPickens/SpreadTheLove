using UnityEngine;
using System.Collections;

public class ForeGroundObjectPlacer : MonoBehaviour {

	public GameObject[] Trees;
	public GameObject[] Flowers;
	public GameObject[] Planets;

	// Use this for initialization
	void Start () {
		SetUpObjects ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetUpObjects(){
		int i = 0;
		while (i < 4) {
			int objectNumber = Random.Range (0, 8);
			if (!Planets [objectNumber].GetComponent<ForeGroundStateScript> ().isActive) {
				Planets [objectNumber].SetActive (true);
				Planets [objectNumber].GetComponent<ForeGroundStateScript> ().isActive = true;
				i++;
			}
		}

		i = 0;
		while (i < 5) {
			int objectNumber = Random.Range (0, 8);
			if (!Trees [objectNumber].GetComponent<ForeGroundStateScript> ().isActive) {
				Trees [objectNumber].SetActive (true);
				Trees [objectNumber].GetComponent<ForeGroundStateScript> ().isActive = true;
				i++;
			}
		}

		i = 0;
		while (i < 5) {
			int objectNumber = Random.Range (0, 7);
			if (!Flowers [objectNumber].GetComponent<ForeGroundStateScript> ().isActive) {
				Flowers [objectNumber].SetActive (true);
				Flowers [objectNumber].GetComponent<ForeGroundStateScript> ().isActive = true;
				i++;
			}
		}


	}
}

//int i = 0;
//while (i < 5) {
//	int characterNumber = Random.Range (0, 12);
//	if (!Characters [characterNumber].GetComponent<SittingUnicornScript> ().currentlyActive) {
//		Characters [characterNumber].SetActive (true);
//		Characters [characterNumber].GetComponent<SittingUnicornScript> ().currentlyActive = true;
//		i++;
//	}
//}