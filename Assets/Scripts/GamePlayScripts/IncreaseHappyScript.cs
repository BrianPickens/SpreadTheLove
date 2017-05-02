using UnityEngine;
using System.Collections;

public class IncreaseHappyScript : MonoBehaviour {

		public Sprite GreySprite1;
		public Sprite GreySprite2;
		public Sprite GreySprite3;
		public Sprite GoodSprite1;
		public Sprite GoodSprite2;
		public Sprite GoodSprite3;
		public Sprite Highlighted1;
		public Sprite Highlighted2;
		public GameObject ParticleSpray;
		public bool superModeActive;
		public int itemType;
		public int itemState;
		public int spriteVariations;
		public GameObject HappyParticleEffect;
		public AudioClip Poof;
		public Animator myAnim;


		// Use this for initialization
		void Start () {
		myAnim = GetComponent<Animator> ();
		itemType = Random.Range (0, spriteVariations);
		ItemChange ();
		}

		// Update is called once per frame
		void Update () {

		if (UnicornMove.superMode && !superModeActive && itemState == 1) {
			switch (itemType) {
			case 0:
				//myAnim.speed = 0.35f;
				//myAnim.SetBool ("Glimmer", true);
				GetComponent<SpriteRenderer> ().sprite = Highlighted1;
				break;

			case 1:
				GetComponent<SpriteRenderer> ().sprite = Highlighted2;
				break;
			}

			ParticleSpray.SetActive (true);
			superModeActive = true;
		} else if (!UnicornMove.superMode && superModeActive && itemState == 1) {
			switch (itemType) {
			case 0:
				//myAnim.speed = 1f;
				//myAnim.SetBool ("Glimmer", false);
				GetComponent<SpriteRenderer> ().sprite = GreySprite1;
				break;

			case 1:
				GetComponent<SpriteRenderer> ().sprite = GreySprite2;
				break;

			}

			ParticleSpray.SetActive (false);
			superModeActive = false;
		}

		}

		public void ItemChange(){

		itemState += 1;
			switch (itemState) {
			case 1:
				switch (itemType) {
				case 0:
				GetComponent<SpriteRenderer> ().sprite = GreySprite1;
					break;

			case 1:
				GetComponent<SpriteRenderer> ().sprite = GreySprite2;
					break;

				case 2:
				GetComponent<SpriteRenderer> ().sprite = GreySprite3;
					break;
				default:

					break;
				}
				break;

		case 2:
			Instantiate (HappyParticleEffect, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity, gameObject.transform);
			if (!SoundManager.AudioOff) {
				GetComponent<AudioSource> ().PlayOneShot (Poof);
			}
			myAnim.SetBool ("IsHappy", true);
				switch (itemType) {
				case 0:
				GetComponent<SpriteRenderer> ().sprite = GoodSprite1;
					break;

				case 1:
				GetComponent<SpriteRenderer> ().sprite = GoodSprite2;
					break;

				case 2:
				GetComponent<SpriteRenderer> ().sprite = GoodSprite3;
					break;
				default:

					break;
				}
				break;

			default:

				break;
			}
		ParticleSpray.SetActive (false);

		}
	}
