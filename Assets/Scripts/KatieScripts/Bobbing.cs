using UnityEngine;
using System.Collections;

// CODE BY BRIAN HANDY

// Makes gameobject bob up and down
public class Bobbing : MonoBehaviour {

	public float speed2 = 4f;
	public float size = .18f;
	Renderer r;
	Vector3 s;
	float randomOffset;

	// Use this for initialization
	void Start () {
		s = this.transform.localScale;
		randomOffset = Random.Range(0f, 1000f);
	}

	// Update is called once per frame
	void Update () {
		float baseVal = Time.realtimeSinceStartup + randomOffset;
		Vector3 newS = s;
		newS.x *= Mathf.Sin(baseVal * speed2) / 2f * size + 1f;
		newS.y *=-Mathf.Sin(baseVal * speed2) / 2f * size + 1f;
		this.transform.localScale = newS;
	}
}