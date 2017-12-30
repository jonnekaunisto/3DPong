using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAIScript : PlayerScript {

	public GameObject ball;
	public float lerpSpeed = 0.5f;
	public float reactionDistance = 6f;

	Vector3 startingLocation;
	// Use this for initialization

	void Awake(){
		if (ball == null) {
			ball = GameObject.FindGameObjectWithTag ("Ball");
		}
		startingLocation = transform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		if (ball == null) {
			ball = GameObject.FindGameObjectWithTag ("Ball");
		}
		Vector3 ballPosition = ball.transform.position;
		Vector3 position = transform.position;
		if (Mathf.Abs (ballPosition.z) < 5 && Mathf.Abs(ballPosition.z - position.z) < reactionDistance) {
			transform.position = new Vector3 (Mathf.Lerp (position.x, ballPosition.x, lerpSpeed * Time.deltaTime), Mathf.Lerp (position.y, ballPosition.y, lerpSpeed * Time.deltaTime), transform.position.z);
		} else {
			transform.position = new Vector3 (Mathf.Lerp (position.x, startingLocation.x, 1f * Time.deltaTime), Mathf.Lerp (position.y, startingLocation.y, 1f * Time.deltaTime), transform.position.z);
		}
	}
}
