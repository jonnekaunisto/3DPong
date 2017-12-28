using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollidersScript : MonoBehaviour {

	public int side;

	GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = GameController.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Ball")) {
			gameController.ScoredPointOn (side);
		}
	}
}
