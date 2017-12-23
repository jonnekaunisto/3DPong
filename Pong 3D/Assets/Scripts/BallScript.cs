//Jonne Kaunisto, December 2017
//controls the ball
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	Rigidbody rigidBody;
	public float speedMultiplier = 1.1f;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();

		//rigidBody.AddForce(new Vector3(0f,0f,0.1f));
		rigidBody.velocity = new Vector3 (02f, 02f, -8f);
		//rigidBody.AddTorque(new Vector3 (100f, 0, 0), ForceMode.Force);

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vel = rigidBody.velocity;
		float tempMultiplier = (speedMultiplier - 1f) * Time.deltaTime + 1;
		rigidBody.velocity = new Vector3 (vel.x, vel.y, vel.z  * tempMultiplier); 
	}
}
