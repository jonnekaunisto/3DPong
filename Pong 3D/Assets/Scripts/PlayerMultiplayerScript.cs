using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMultiplayerScript : NetworkBehaviour {

	public LayerMask hitlayer;
	public int opponent = 1;
	public Camera cam;

	public Vector3 velocity;

	protected Vector3 lastLocation;

	protected Rigidbody rig;
	public AudioSource audio;

	float originalPitch;
	Vector3 camPosition;
	void Awake(){
		if (isLocalPlayer) {
			Debug.LogError (isLocalPlayer);
		}
	}

	// Use this for initialization
	void Start () {
		lastLocation = transform.position;

		audio = GetComponent<AudioSource> ();
		originalPitch = audio.pitch;

		camPosition = cam.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) {
			cam.enabled = false;
			return;
		}
		cam.transform.position = camPosition;
		RaycastHit hit;
		float length = 10f;
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, length, hitlayer)) {
			//Debug.Log (transform.position.x);
			//Debug.Log (transform.position.y);
			//Debug.Log (transform.position.z);
			transform.position = hit.point;
			transform.position = new Vector3 (hit.point.x, hit.point.y, transform.position.z);

		}
	}

	void LateUpdate(){
		cam.transform.position = camPosition;
		float dx = transform.position.x - lastLocation.x;
		float dy = transform.position.y - lastLocation.y;
		float dz = transform.position.z - lastLocation.z;

		velocity = new Vector3 (dx, dy, dz);

		lastLocation = transform.position;

	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.CompareTag ("Ball")) {
			coll.gameObject.GetComponent<BallScript> ().spin = velocity;
			//Debug.LogError (audio == null);
			audio.pitch = audio.pitch + 0.1f;
			audio.Play ();
		}

	}

	public void NewRound(){
		audio.pitch = originalPitch;
	}
}
