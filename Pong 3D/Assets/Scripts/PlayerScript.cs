//Jonne Kaunisto, December 2017
//controls the player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public LayerMask hitlayer;
	public int opponent = 1;
	// Use this for initialization
	void Start () {
		
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

		} else {
		}



	}
}
