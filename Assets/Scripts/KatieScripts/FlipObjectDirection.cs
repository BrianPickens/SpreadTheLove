using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// http://answers.unity3d.com/questions/668859/flip-2d-player-in-x-axis-to-face-movement-directio.html
/// Flips gameobject and scprtie depending of direction of movement
/// </summary>
public class FlipObjectDirection : MonoBehaviour {

	private float someScale;
	private float direction;
	private float _posX;

	void Start(){
		someScale = transform.localScale.x; // assuming this is facing right
		direction = 1;
		_posX = transform.position.x;
	}
	void Update(){

		if (transform.position.x <= _posX)
		{
//			Debug.Log("Moving left - " + transform.position.x);
			if (direction == 1)
			{
//				transform.localScale = new Vector2(-1, transform.localScale.y);
				transform.localScale = new Vector2 (someScale, transform.localScale.y);
				direction = -1;
				gameObject.GetComponent<SpriteRenderer> ().flipX = false;
			}
		}
		else
		{
//			Debug.Log("Moving right - " + transform.position.x);
			if (direction == -1)
			{
//				transform.localScale = new Vector2(1, transform.localScale.y);
				transform.localScale = new Vector2 (someScale, transform.localScale.y);
				direction = 1;
				gameObject.GetComponent<SpriteRenderer> ().flipX = true;
			}
		}

		_posX = transform.position.x;
	}
}
