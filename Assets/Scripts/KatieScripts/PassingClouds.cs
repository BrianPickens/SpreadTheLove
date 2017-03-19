using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingClouds : MonoBehaviour {

	// An object pool helps recycle instantiated objects if need be
	[SerializeField]
	private SimpleObjectPool cloudObjPool;

	// num of clouds to spawn
	[SerializeField]
	private float numOfClouds = 2;
	//min and max range
	public float minSpawnRange = 15.4f;
	public float maxSpawnRange = 27.3f;
	public float startPosX = -35.4f;
	public float maxXPos = 31.6f;
	public float minSpeed=2f;
	public float maxSpeed = 4f;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnClouds ());
		//for (int i = 0; i < numOfClouds; i++) {
			//SpawnClouds ();
		//}
	}

//	void SpawnClouds(){
//
//		float ranYPos = Random.Range (minSpawnRange,maxSpawnRange);
//		Vector2 pos = new Vector2 (startPosX,ranYPos);
//		GameObject newCloud = cloudObjPool.GetComponent<SimpleObjectPool>().GetObject(pos);
//
//	}

	IEnumerator SpawnClouds(){
		for (int i = 0; i < numOfClouds; i++) {
			float ranYPos = Random.Range (minSpawnRange, maxSpawnRange);
			Vector2 pos = new Vector2 (startPosX, ranYPos);
			GameObject newCloud = cloudObjPool.GetComponent<SimpleObjectPool> ().GetObject (pos);
			yield return new WaitForSeconds (5f);
		}
	}

}
