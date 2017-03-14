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
	// Use this for initialization
	void Start () {
//		particles = this.GetComponent<ParticleSystem>();
	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.tag == "Lollipop") {
//			CameraShake.Shake( cameraShakeDuration, cameraShakeAmount);
		}
		//if you hit the top of the screen, enable screen shake
		if (other.gameObject.tag == "TopEdge") {
			particles.Emit(emitNumParticles);
			// Also Shake Camera
			CameraShake.Shake( cameraShakeDuration, cameraShakeAmount);
		}

		//if you hit the bottom of the screen, enable screen shake
		if (other.gameObject.tag == "BottomEdge") {
			particles.Emit(emitNumParticles);
			// Also Shake Camera
			CameraShake.Shake( cameraShakeDuration, cameraShakeAmount);
		}
		if (other.gameObject.tag == "Edge") {
			particles.Emit(emitNumParticles);
			// Also Shake Camera
			CameraShake.Shake( cameraShakeDuration, cameraShakeAmount);
		}

	}
}
