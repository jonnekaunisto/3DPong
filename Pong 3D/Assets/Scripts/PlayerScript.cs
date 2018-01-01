//Jonne Kaunisto, December 2017
//controls the player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public LayerMask hitlayer;
	public int opponent = 1;

	public Vector3 velocity;

	protected Vector3 lastLocation;

	protected Rigidbody rig;
	public AudioSource audio;

	float originalPitch;
	// Use this for initialization
	void Start () {
		lastLocation = transform.position;

		audio = GetComponent<AudioSource> ();
		originalPitch = audio.pitch;
	}
	


	void LateUpdate(){
		float dx = transform.position.x - lastLocation.x;
		float dy = transform.position.y - lastLocation.y;
		float dz = transform.position.z - lastLocation.z;

		velocity = new Vector3 (dx, dy, dz);

		lastLocation = transform.position;

	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.CompareTag ("Ball")) {
			//coll.gameObject.GetComponent<BallScript> ().spin = velocity;
			//coll.gameObject.GetComponent<BallScript> ().CmdSpin (velocity);
			//Debug.LogError (audio == null);
			audio.pitch = audio.pitch + 0.03f;
			audio.Play ();
		}

	}

	public void NewRound(){
		audio.pitch = originalPitch;
	}
}
