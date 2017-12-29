//Jonne Kaunisto, December 2017
//controls the player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public LayerMask hitlayer;
	public int opponent = 1;

	public Vector3 velocity;

	Vector3 lastLocation;

	Rigidbody rig;
	AudioSource audio;

	float originalPitch;
	// Use this for initialization
	void Start () {
		lastLocation = transform.position;

		audio = GetComponent<AudioSource> ();
		originalPitch = audio.pitch;
	}
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;
		float length = 30f;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, length, hitlayer)) {
			//Debug.Log (transform.position.x);
			//Debug.Log (transform.position.y);
			//Debug.Log (transform.position.z);
			transform.position = hit.point;
			transform.position = new Vector3 (hit.point.x, hit.point.y, hit.point.z * opponent);

		}
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
			coll.gameObject.GetComponent<BallScript> ().spin = velocity;
			audio.pitch = audio.pitch + 0.1f;
			audio.Play ();
		}

	}

	public void NewRound(){
		audio.pitch = originalPitch;
	}
}
