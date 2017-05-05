using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LolliPopScript : MonoBehaviour {

	public Sprite LolliPop;
	public Sprite Waffle;
	public Sprite Donut;

	public int identity;

	Animator _myanim;

	// Use this for initialization
	void Start () {
		_myanim = GetComponent<Animator> ();
		CollectableType ();
	}

	public void UnicornHit(){
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<BoxCollider2D> ().enabled = false;
		StartCoroutine (ResetSprite ());
	}

	IEnumerator ResetSprite(){
		_myanim.SetBool ("Lollipop", false);
		_myanim.SetBool ("Waffle", false);
		_myanim.SetBool ("Donut", false);
		yield return new WaitForSeconds (3f);
		CollectableType ();
		GetComponent<SpriteRenderer> ().enabled = true;
		GetComponent<BoxCollider2D> ().enabled = true;
	}

	public void CollectableType(){
		identity = Random.Range (0, 3);
		switch (identity) {
		case 0:
			GetComponent<SpriteRenderer> ().sprite = LolliPop;
			_myanim.SetBool ("Lollipop", true);
			break;

		case 1:
			GetComponent<SpriteRenderer> ().sprite = Waffle;
			_myanim.SetBool ("Waffle", true);
			break;

		case 2:
			GetComponent<SpriteRenderer> ().sprite = Donut;
			_myanim.SetBool ("Donut", true);
			break;
		}
	}
}
