using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// Code for lerping camera saturation
/// </summary>
public class ChangeCameraSaturation : MonoBehaviour {

	public Camera mainCamera;
	public float camSatEnd = 1f;
	float sat;

	public float saturation
	{
		get
		{
			return sat;
		}
	}
		
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		LerpCameraSaturation (camSatEnd);
	}

	void LerpCameraSaturation(float camSat){

		sat = mainCamera.GetComponent<ColorCorrectionCurves>().saturation;
		if (sat < camSatEnd) {
			sat = Mathf.Lerp (sat, camSat, Time.deltaTime);
			mainCamera.GetComponent<ColorCorrectionCurves> ().saturation = sat;
		}
	}
}
