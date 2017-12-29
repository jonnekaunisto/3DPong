//Jonne Kaunisto, December 2017
//controls the depth plane
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthPlaneScript : MonoBehaviour {

	public GameObject lines;


	public GameObject ball;

	void Awake(){
		if (ball == null) {
			ball = GameObject.FindGameObjectWithTag ("Ball");
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void LateUpdate(){
		transform.position = new Vector3 (0, 0, ball.transform.position.z);
		//transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 0);
		if (Mathf.Abs (transform.position.z) > 5.5) {
			lines.SetActive (false);
		} else {
			lines.SetActive (true);
		}
		//transform.rotation = initialRotation;

	}
}
