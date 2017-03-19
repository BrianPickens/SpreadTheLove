using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enables camera shake and star particles when hitting edges of screen
/// </summary>
public class EnableParticleEffect : MonoBehaviour {

	public ParticleSystem particles;
	public int emitNumParticles = 50;
	public float cameraShakeDuration = 0.25f;
	public float cameraShakeAmount = 0.2f;
	public UnicornMove unicornMove;
	private Rigidbody2D _myRigidbody;

	// Use this for initialization
	void Start () {
		_myRigidbody = GetComponent<Rigidbody2D> ();
		unicornMove = gameObject.GetComponent<UnicornMove> ();

	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.tag == "Cloud") {
			float move = Input.acceleration.x;
//			_myRigidbody.velocity = new Vector2 (move * unicornMove.turnSpeed, unicornMove.speed);
//			particles.Emit(emitNumParticles);
			// Also Shake Camera
//			CameraShake.Shake( cameraShakeDuration, cameraShakeAmount);
		}
		//if you hit the top of the screen, enable screen shake
		if (other.gameObject.tag == "TopEdge") {
			particles.Emit(emitNumParticles);
			// Also Shake Camera
			//CameraShake.Shake( cameraShakeDuration, cameraShakeAmount);
		}

		//if you hit the bottom of the screen, enable screen shake
		if (other.gameObject.tag == "BottomEdge") {
			particles.Emit(emitNumParticles);
			// Also Shake Camera
			//CameraShake.Shake( cameraShakeDuration, cameraShakeAmount);
		}
		if (other.gameObject.tag == "Edge") {
			particles.Emit(emitNumParticles);
			// Also Shake Camera
			//CameraShake.Shake( cameraShakeDuration, cameraShakeAmount);
		}

	}
}
