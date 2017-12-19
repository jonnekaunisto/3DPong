using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();

		//rigidBody.AddForce(new Vector3(0f,0f,0.1f));
		rigidBody.velocity = new Vector3 (0f, 0f, -4f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
