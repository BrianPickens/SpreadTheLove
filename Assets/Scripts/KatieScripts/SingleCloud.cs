using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// child of PassingClouds class
// handles individual clouds
public class SingleCloud:PassingClouds{

	private float randSpeed = 0f;
	// Use this for initialization
	void Start () {
//		Debug.Log ("in singlecloud speen");
		randSpeed = Random.Range (minSpeed,maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log ("randSpeed: "+randSpeed);
		// move this object across the screen
//		Debug.Log("moving across the screen");
		transform.Translate(Vector3.right*Time.deltaTime*randSpeed);


		// when this object reaches a certain X pos, respawn at beginning with a new y location
		if (gameObject.transform.localPosition.x >= maxXPos) {

			float ranYPos = Random.Range (minSpawnRange,maxSpawnRange);
			Vector2 pos = new Vector2 (startPosX,ranYPos);
			transform.position = pos;
		}
	}
		
}
