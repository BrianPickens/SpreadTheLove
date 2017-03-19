using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnicornMove : MonoBehaviour {

	public static bool superMode;
	public static int multiplier;

	private Transform _myTransform;
	private Rigidbody2D _myRigidbody;
	private Animator _myanim;
	private SpriteRenderer _mySprite;

	public GameObject LoveSplode;
	public GameObject LoveMeter;
	public GameObject Camera;
	public GameObject HappySplode;
	public GameObject HappyZone;
	public GameObject HappyZoneUnicorn;

	public GameObject ScoreDisplay;
	public GameObject MutiplierImageDisplay;
	public GameObject TimeOfDay;
	public GameObject EndScreen;
	public GameObject EndScoreDisplay;
	public GameObject MultiplierPopUpDisplay;

	public Sprite LolliMultiplier;
	public Sprite WaffleMultiplier;
	public Sprite DonutMultiplier;
	public Sprite UnicornLeft;
	public Sprite UnicornRight;

	private bool travelingUp;
	private bool gameEnding;
	private bool slowingDown;
	private bool stopInteraction;
	private bool facingLeft;
	private bool mediumMusicOn;
	private int direction;

	public float speed;
	public float baseSpeed;
	public float superModeBaseSpeed;
	public float topSpeed;
	public float turnSpeed;
	public float baseTurnSpeed;
	public float superModeBaseTurnSpeed;
	public float rotationAngle;

	private int happyObjectCount;
	private int happyObjectMax;
	private int score;
	private int currentIdentity;

	public AudioClip Poof;
	public AudioClip Love;

	public bool bounds;
	public Vector2 minUnicornPos;
	public Vector2 maxUnicornPos;

	//debug slider for movement if usb screws up
	public bool mouseMovement;
	public float debugMovementSlider;

	//cam shake
	public float cameraShakeDuration = 0.25f;
	public float cameraShakeAmount = 0.2f;

	void Start () {

		//allow you to start the scene without the SoundManager gameobject
	//	if (GameObject.FindGameObjectWithTag ("SoundManager") != null) {
	//		GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().StartGameMusic ();
	//	}

		direction = -1;

		//initialize direction that player is facing for animator
		facingLeft = true;

		//start multiplier at 1 if player resets
		multiplier = 1;

		//how many object need to be made happy to end game
		happyObjectMax = 14;

		//reset number of happy objects to zero if player resets
		happyObjectCount = 0;

		//the type of candy that the unicorn wants to eat.  always starts on lollipop
		currentIdentity = 0;

		//reset direction be traveled if player resets
		travelingUp = true;

		//grabbing transforma dn ridgidbody for movement
		_myRigidbody = GetComponent<Rigidbody2D> ();
		_myTransform = GetComponent<Transform> ();
		_myanim = GetComponent<Animator> ();
		_mySprite = GetComponent<SpriteRenderer> ();

	}

	void Update () {

		//if the game is still going, adjust the players speed based on whether or not they are in supermode, and how high their multiplier is.
		//if the player has madeeverything happy stop adjusting speed and end the game.
		if (!gameEnding) {
			if (speed < topSpeed) {
				if (superMode) {
					speed = superModeBaseSpeed + multiplier / 10;
					turnSpeed = superModeBaseTurnSpeed + multiplier / 10f;
					;
				} else {
					speed = baseSpeed + multiplier / 10f;
					turnSpeed = baseTurnSpeed + multiplier / 10f;
				}
			}
		} else {
			//end the game
			EndGame ();
		}

		//grab the input from the connected iphone
		float move = Input.acceleration.x;

		//used for moveing with mouse
		if (mouseMovement) {
			move = debugMovementSlider;
		}


		//flip the character sprite back and forth depending on which way the phone is tilted
		if (Input.acceleration.x < 0 && !facingLeft && !gameEnding) {
			_mySprite.sprite = UnicornLeft;
			Flip ();
		} else if (Input.acceleration.x > 0 && facingLeft && !gameEnding) {
			_mySprite.sprite = UnicornRight;
			Flip ();
		}

		//change verticle velocity
		if (travelingUp) {
			_myRigidbody.velocity = new Vector2 (move * turnSpeed, speed);
			_myTransform.localEulerAngles = new Vector3 (0, 0, rotationAngle * direction);
		} else {
			_myRigidbody.velocity = new Vector2 (move * turnSpeed, -speed);
			_myTransform.localEulerAngles = new Vector3 (0, 0, -rotationAngle * direction);
		}
			
		//if bounds is checked, constrain the unicorn to bounds specified in the inspector
		if (bounds) {
			_myTransform.position = new Vector2 (Mathf.Clamp (_myTransform.position.x, minUnicornPos.x, maxUnicornPos.x),
				Mathf.Clamp (_myTransform.position.y, minUnicornPos.y, maxUnicornPos.y));
		}

		//if the player makes half of the objects happy, move the music to medium
		if (happyObjectCount > happyObjectMax / 2 && !mediumMusicOn) {
			if (GameObject.FindGameObjectWithTag ("SoundManager") != null) {
				GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().StartMediumMusic ();
			}
			mediumMusicOn = true;
		}

		//if the player makes all things happy, end the game.
		if (happyObjectCount >= happyObjectMax && !gameEnding) {
			gameEnding = true;
		}

	}
		
	//deals with colliding with candies, other unicorns, and the top and bottom edge of the screen
	void OnTriggerEnter2D (Collider2D other){

		//if the player hits a candy, make sounds, make paricles, tell the other object what to do in its script, and calculate score
		if (other.gameObject.tag == "Lollipop" && !stopInteraction) {
			other.gameObject.GetComponent<LolliPopScript> ().UnicornHit ();
			GetComponent<AudioSource> ().PlayOneShot (Poof);
			//LoveMeter.GetComponent<LoveMeterFill> ().AddLove ();
			Instantiate (LoveSplode, transform.position, Quaternion.Euler(new Vector3(180,0,0)));
			CalculateScore (other.gameObject.GetComponent<LolliPopScript> ().identity);
		}

		//if you hit the top of the screen, flip velocity direction down, also make the camera adjust its trailing
		if (other.gameObject.tag == "TopEdge") {
			travelingUp = false;
			Camera.GetComponent<CameraFollow> ().TopCamera ();
		}

		//if you hit the bottom of the screen, flip velocity direction up, also make the camera adjust its trailing
		if (other.gameObject.tag == "BottomEdge") {
			travelingUp = true;
			Camera.GetComponent<CameraFollow> ().BottomCamera ();
		}

		//if you hit a unicorn, give score, tell the unicorn what to do in its script, and add love to the love meter.
		if (other.gameObject.tag == "Unicorn") {
			CurrencyManager.unicornSmiles += 500;
			other.gameObject.GetComponent<SittingUnicornScript> ().UnicornChange ();
			LoveMeter.GetComponent<LoveMeterFill> ().AddUnicornLove ();
		}

	}

	//flips the unicorn sprite based on phone tilt direction
	void Flip(){
		facingLeft = !facingLeft;
		//Vector2 theScale = transform.localScale;
		//theScale.x *= -1;
		//transform.localScale = theScale;
		direction *= -1;
	}

	//when the love meter is full and player touches the screeen.  starts super mode, creates particles, sounds, turns on the big and small colliders to make things happy
	public void LoveMeterFull(){
		Instantiate (HappySplode, new Vector2(gameObject.transform.position.x,gameObject.transform.position.y), Quaternion.identity, gameObject.transform);
		HappySplode.SetActive (true);
		GetComponent<AudioSource> ().PlayOneShot (Love);
		HappyZone.SetActive (true);
		//Camera Shake!
		//CameraShake.Shake( cameraShakeDuration, cameraShakeAmount);
		StartCoroutine (HappyZoneReset ());
		if (!superMode) {
			StartSuperMode ();
			superMode = true;
		}
	}

	//turns on the small collider for crashing into things
	public void StartSuperMode(){
		HappyZoneUnicorn.SetActive (true);
		if (GameObject.FindGameObjectWithTag ("SoundManager") != null) {
			GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().StartSuperModeMusic ();
		}
	}

	//turns off the small collider for crashing into thigns, and turns off supermode
	public void EndSuperMode(){
		if (GameObject.FindGameObjectWithTag ("SoundManager") != null) {
			GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().EndSuperModeMusic ();
		}
		HappyZoneUnicorn.SetActive (false);
		superMode = false;
	}

	//turns off the big collider that hits everything on the screen
	IEnumerator HappyZoneReset(){
		yield return new WaitForSeconds (0.2f);
		HappyZone.SetActive (false);
	}

	//calculate multiplier and score
	public void CalculateScore(int collectableIdentity){
		//if the player is no in sper mode, check to see if the player collected the right candy.
		//if player collects the right candy, add mulitplier, add lovemeter, and change target image
		//if player is in super mode they can grab anything
		if (!superMode) {
			if (collectableIdentity == currentIdentity) {
				multiplier += 1;
				LoveMeter.GetComponent<LoveMeterFill> ().AddLove ();
				currentIdentity = Random.Range (0, 3);
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
		//update score, create mulitplier popup, display score
		score = score + (10 * multiplier);
		Instantiate (MultiplierPopUpDisplay, transform.position, Quaternion.identity);
		ScoreDisplay.GetComponent<Text> ().text = "" + score;
	}

	//switch the target candy image
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

	//fade in the light background as the player makes objects happy
	public void FadeInDayTime(){
		happyObjectCount++;
		float Count = happyObjectCount;
		float Max = happyObjectMax;
		float happyObjectDifference = Count/Max;
		TimeOfDay.GetComponent<Image> ().color = new Color (TimeOfDay.GetComponent<Image> ().color.r, TimeOfDay.GetComponent<Image> ().color.g, TimeOfDay.GetComponent<Image> ().color.b, happyObjectDifference);
		GetComponent<ChangeCameraSaturation> ().camSatEnd = happyObjectDifference;
	}

	//end the game, stop interaction, stop movement, save the game, turn on end screen
	public void EndGame(){
		speed = 0f;
		turnSpeed = 0f;
		stopInteraction = true;
		EndScoreDisplay.GetComponent<Text> ().text = "Score: " + score;
		CurrencyManager.unicornSmiles += score;
		GameObject.FindGameObjectWithTag ("SaveSettings").GetComponent<SaveSettingsScript> ().SaveSettings ();
		EndScreen.SetActive (true);
	}

	//reset the game
	public void RestartGame(){
		EndSuperMode ();
		GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager> ().RestartGameMusic ();
		SceneManager.LoadScene ("prototype5");
	}

	//go to menu
	public void GameToMenu(){
		EndSuperMode ();
		GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager> ().GameToMenu ();
		SceneManager.LoadScene ("Menu");
	}

	//go to Spread the Love menu
	public void GameToSpreadLove(){
		EndSuperMode ();
		GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager> ().GameToShop ();
		SceneManager.LoadScene ("SpreadTheLove");
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

}
