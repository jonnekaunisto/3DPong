//Jonne Kaunisto, December 2017
//controls the ball
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	Rigidbody rigidBody;

	public float speedMultiplier = 1.1f; //how much the speed increases every second

	public Vector3 physicsSpinMultiplier; //how much spin the ball experiences physically
	public Vector3 visualSpinMultiplier; //how much spin appears on the ball
	public Vector3 spinDecay;

	public Vector3 spin; //the spin of the ball

	public float minVelocity;
	public float maxVelocity;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		spin = Vector3.zero;

		//rigidBody.AddForce(new Vector3(0f,0f,0.1f));
		//rigidBody.velocity = new Vector3 (02f, 02f, -8f);
		//rigidBody.AddTorque(new Vector3 (100f, 0, 0), ForceMode.Force);

	}
	

	void Update () {
		spin = new Vector3 (spin.x * (1 - (1 - spinDecay.x) * Time.deltaTime), spin.y * (1 - (1 - spinDecay.y) * Time.deltaTime), spin.z * (1 - (1 - spinDecay.z) * Time.deltaTime));
		rigidBody.angularVelocity = new Vector3 (spin.x * visualSpinMultiplier.x, spin.y * visualSpinMultiplier.y, spin.z * visualSpinMultiplier.z);

		Vector3 vel = rigidBody.velocity;
		float tempMultiplier = (speedMultiplier - 1f) * Time.deltaTime + 1;
		rigidBody.velocity = new Vector3 (vel.x + spin.x * physicsSpinMultiplier.x, vel.y + spin.y * physicsSpinMultiplier.y, vel.z  * tempMultiplier); 

		if (Mathf.Abs(rigidBody.velocity.z) > maxVelocity) {
			vel = rigidBody.velocity;
			rigidBody.velocity = new Vector3 (vel.x, vel.y, Mathf.Lerp (vel.z, maxVelocity * Mathf.Sign(vel.z), 0.6f));
		}
		if (Mathf.Abs(rigidBody.velocity.z) < minVelocity) {
			vel = rigidBody.velocity;
			rigidBody.velocity = new Vector3 (vel.x, vel.y, Mathf.Lerp (vel.z, minVelocity * Mathf.Sign(vel.z), 0.6f));
		}

	}


	public void Reset(){
		rigidBody.velocity = Vector3.zero;
		spin = Vector3.zero;

	}
}
