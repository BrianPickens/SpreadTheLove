using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnicornMove : MonoBehaviour {

	private Transform _myTransform;
	private Rigidbody2D _myRigidbody;
	public float speed;
	public float turnSpeed;
	public GameObject LoveSplode;
	public GameObject LoveMeter;
	public GameObject Camera;
	public GameObject HappySplode;
	public AudioClip Poof;
	public AudioClip Love;
	public bool travelingUp;
	public GameObject HappyZone;
	public GameObject HappyZoneUnicorn;
	public Vector2 minUnicornPos;
	public Vector2 maxUnicornPos;
	public static bool superMode;

	public bool bounds;
	private bool gameEnding;
	private bool slowingDown;
	private bool stopInteraction;
	private bool overtime;
	private bool facingLeft;

	private int happyObjectCount;
	private int happyObjectMax;
	//private float gameTimer;
	//private float transitionTime;
	//private float time;

	public static int multiplier;
	private int score;
	private int currentIdentity;

	public GameObject ScoreDisplay;
	public GameObject MutiplierImageDisplay;
	public GameObject GameTimerDisplay;
	public GameObject TimeOfDay;
	public GameObject EndScreen;
	public GameObject EndScoreDisplay;
	public GameObject MultiplierPopUpDisplay;
	public GameObject OvertimeDisplay;

	public Sprite LolliMultiplier;
	public Sprite WaffleMultiplier;
	public Sprite DonutMultiplier;


	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().StartGameMusic ();
		facingLeft = true;
		multiplier = 1;
		happyObjectMax = 14;
		happyObjectCount = 0;
		//gameTimer = 60f;
		//transitionTime = gameTimer;
		currentIdentity = 0;
		travelingUp = true;
		_myRigidbody = GetComponent<Rigidbody2D> ();
		_myTransform = GetComponent<Transform> ();
		//StartCoroutine (FadeBackgroundIn ());
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameEnding) {
			if (speed < 13) {
				if (superMode) {
					speed = 6f + multiplier / 10;
					turnSpeed = 24f + multiplier / 10f;
					;
				} else {
					speed = 4f + multiplier / 10f;
					turnSpeed = 20f + multiplier / 10f;
				}
			}
		} else if (!slowingDown){
			StartCoroutine (EndGameSlowdown ());
			slowingDown = true;
		}
		float move = Input.acceleration.x;
		//float moveUp = Input.acceleration.y;
		if (Input.acceleration.x < 0 && !facingLeft && !gameEnding) {
			Flip ();
		} else if (Input.acceleration.x > 0 && facingLeft && !gameEnding) {
			Flip ();
		}

		if (travelingUp) {
			_myRigidbody.velocity = new Vector2 (move * turnSpeed, speed);
		} else {
			_myRigidbody.velocity = new Vector2 (move * turnSpeed, -speed);
		}

		//added for controll
		//_myRigidbody.velocity = new Vector2 (move * turnSpeed, moveUp * turnSpeed);
		//added for control

		if (bounds) {
			_myTransform.position = new Vector2 (Mathf.Clamp (_myTransform.position.x, minUnicornPos.x, maxUnicornPos.x),
				Mathf.Clamp (_myTransform.position.y, minUnicornPos.y, maxUnicornPos.y));
		}

		//if (gameTimer > 0) {
		//	gameTimer -= Time.deltaTime;
		//	if (gameTimer < 3.4f) {
		//		GameTimerDisplay.GetComponent<Text> ().text = "" + Mathf.RoundToInt (gameTimer);
		//	}
//		} else if (!gameEnding && !superMode) {
//			GameTimerDisplay.SetActive (false);
//			gameEnding = true;
//		} else if (!gameEnding && !overtime) {
//			GameTimerDisplay.SetActive (false);
//			OvertimeDisplay.SetActive (true);
//			overtime = true;
//		}


		if (happyObjectCount >= happyObjectMax && !gameEnding) {
			gameEnding = true;
		}
		//need to add if(all objects are happy) start end game

	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.tag == "Lollipop" && !stopInteraction) {
			other.gameObject.GetComponent<LolliPopScript> ().UnicornHit ();
			GetComponent<AudioSource> ().PlayOneShot (Poof);
			//LoveMeter.GetComponent<LoveMeterFill> ().AddLove ();
			Instantiate (LoveSplode, transform.position, Quaternion.Euler(new Vector3(180,0,0)));
			CalculateScore (other.gameObject.GetComponent<LolliPopScript> ().identity);
		}

		if (other.gameObject.tag == "TopEdge") {
			travelingUp = false;
			//speed = speed * -1f;
			Camera.GetComponent<CameraFollow> ().TopCamera ();
		}

		if (other.gameObject.tag == "BottomEdge") {
			travelingUp = true;
			//speed = speed * -1f;
			Camera.GetComponent<CameraFollow> ().BottomCamera ();
		}

		if (other.gameObject.tag == "Unicorn") {
			CurrencyManager.unicornSmiles += 500;
			other.gameObject.GetComponent<SittingUnicornScript> ().UnicornChange ();
			LoveMeter.GetComponent<LoveMeterFill> ().AddUnicornLove ();
		}

	}

	void Flip(){
		facingLeft = !facingLeft;
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void LoveMeterFull(){
		Instantiate (HappySplode, new Vector2(gameObject.transform.position.x,gameObject.transform.position.y), Quaternion.identity, gameObject.transform);
		HappySplode.SetActive (true);
		GetComponent<AudioSource> ().PlayOneShot (Love);
		HappyZone.SetActive (true);
		StartCoroutine (HappyZoneReset ());
		if (!superMode) {
			StartSuperMode ();
			superMode = true;
		}
	}


	public void StartSuperMode(){
		HappyZoneUnicorn.SetActive (true);
	}

	public void EndSuperMode(){
		HappyZoneUnicorn.SetActive (false);
		superMode = false;
	}

	IEnumerator HappyZoneReset(){
		yield return new WaitForSeconds (0.2f);
		HappyZone.SetActive (false);
	}

	public void CalculateScore(int collectableIdentity){
		if (!superMode) {
			//Debug.Log ("collected something");
			if (collectableIdentity == currentIdentity) {
				multiplier += 1;
				LoveMeter.GetComponent<LoveMeterFill> ().AddLove ();
				currentIdentity = Random.Range (0, 3);
				//Debug.Log (currentIdentity);
				UpdateMultiplierImage ();
			} else {
				if (multiplier < 3) {
					multiplier = 1;
				} else {
					multiplier -=2;
				}
			}
		} else {
			multiplier += 1;
		}
		score = score + (10 * multiplier);
		Instantiate (MultiplierPopUpDisplay, transform.position, Quaternion.identity);
		ScoreDisplay.GetComponent<Text> ().text = "" + score;
	}

	public void UpdateMultiplierImage(){
		switch (currentIdentity) {
		case 0:
			MutiplierImageDisplay.GetComponent<Image> ().sprite = LolliMultiplier;
			break;

		case 1:
			MutiplierImageDisplay.GetComponent<Image> ().sprite = WaffleMultiplier;
			break;

		case 2:
			MutiplierImageDisplay.GetComponent<Image> ().sprite = DonutMultiplier;
			break;
		}
	}

//	IEnumerator FadeBackgroundIn(){
//		time = 0f;
//		yield return null;
//		while (time <= 1f) {
//			TimeOfDay.GetComponent<Image> ().color = new Color (TimeOfDay.GetComponent<Image> ().color.r, TimeOfDay.GetComponent<Image> ().color.g, TimeOfDay.GetComponent<Image> ().color.b, time);
//			time += Time.deltaTime * (1.0f / transitionTime);
//			yield return null;
//		}
//
//	}

	public void FadeInDayTime(){
		happyObjectCount++;
		float Count = happyObjectCount;
		float Max = happyObjectMax;
		float happyObjectDifference = Count/Max;
		//Debug.Log (happyObjectCount / happyObjectMax);
		TimeOfDay.GetComponent<Image> ().color = new Color (TimeOfDay.GetComponent<Image> ().color.r, TimeOfDay.GetComponent<Image> ().color.g, TimeOfDay.GetComponent<Image> ().color.b, happyObjectDifference);
	}

	IEnumerator EndGameSlowdown(){
		yield return null;
//		while (speed > 0) {
//			speed -= Time.deltaTime;
//			turnSpeed -= Time.deltaTime;
//			yield return null;
//		}
		EndGame ();
	}

	public void EndGame(){
		speed = 0f;
		turnSpeed = 0f;
		stopInteraction = true;
		EndScoreDisplay.GetComponent<Text> ().text = "Score: " + score;
		CurrencyManager.unicornSmiles += score;
		GameObject.FindGameObjectWithTag ("SaveSettings").GetComponent<SaveSettingsScript> ().SaveSettings ();
		Debug.Log (CurrencyManager.unicornSmiles);
		EndScreen.SetActive (true);
	}

	public void RestartGame(){
		EndSuperMode ();
		SceneManager.LoadScene ("prototype5");
	}

	public void GameToMenu(){
		EndSuperMode ();
		GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager> ().StartIntroMusic ();
		SceneManager.LoadScene ("Menu");
	}

	public void GameToSpreadLove(){
		EndSuperMode ();
		GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager> ().StartIntroMusic ();
		SceneManager.LoadScene ("SpreadTheLove");
	}
}
