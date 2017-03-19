using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


	private Vector2 velocity;
	private bool cameraUp;

	public float cameraYoffset;
	public float cameraXoffset;

	public float cameraOffsetSpeed;
	public float cameraOffsetMax;

	public float smoothTimeX = 0.03f;
	public float smoothTimeY = 0.03f;
	private Transform _myTransform;
	public GameObject PlayerCharacter;

	public bool bounds;

	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	// Use this for initialization
	void Start () {

		_myTransform = GetComponent<Transform> ();
		cameraYoffset = 2f;
		cameraUp = false;
	}

	void FixedUpdate(){

		//float move = Input.GetAxis ("LeftJoystickX");

		//if the player goes right
		//if (move > 0 && cameraXoffset < cameraOffsetMax) {
		//	cameraXoffset += cameraOffsetSpeed;
		//}

		//if (move < 0 && cameraXoffset > -cameraOffsetMax) {
		//	cameraXoffset -= cameraOffsetSpeed;
		//}

		float posX = Mathf.SmoothDamp (_myTransform.position.x, PlayerCharacter.GetComponent<Transform> ().position.x + cameraXoffset, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (_myTransform.position.y, PlayerCharacter.GetComponent<Transform> ().position.y + cameraYoffset, ref velocity.y, smoothTimeY);

		_myTransform.position = new Vector3 (posX, posY, transform.position.z);

		if (bounds) {
			_myTransform.position = new Vector3 (Mathf.Clamp (_myTransform.position.x, minCameraPos.x, maxCameraPos.x),
				Mathf.Clamp (_myTransform.position.y, minCameraPos.y, maxCameraPos.y),
				Mathf.Clamp (_myTransform.position.z, minCameraPos.z, maxCameraPos.z));
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void TopCamera(){
		cameraUp = true;
		StartCoroutine (SetTopOffset ());
		//cameraYoffset = -2f;
	}

	public void BottomCamera(){
		cameraUp = false;
		StartCoroutine (SetBottomOffset ());
		//cameraYoffset = 2f;
	}

	IEnumerator SetTopOffset(){
		while (cameraUp) {
			cameraYoffset = Mathf.Lerp (cameraYoffset, -2f, Time.deltaTime);
			//Debug.Log (cameraYoffset);
			yield return new WaitForSeconds (0.01f);
		}
	}

	IEnumerator SetBottomOffset(){
		while (!cameraUp) {
			cameraYoffset = Mathf.Lerp (cameraYoffset, 2f, Time.deltaTime);
			//Debug.Log (cameraYoffset);
			yield return new WaitForSeconds (0.01f);
		}
	}
}
