using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHumanScript : PlayerScript {

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
}
