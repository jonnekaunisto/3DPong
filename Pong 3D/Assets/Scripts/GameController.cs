//Jonne Kaunisto, December 2017
//controls the game state
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject playFieldPrefab;
	private GameObject currentPlayField;

	public GameObject ballPrefab;
	public GameObject currentBall;

	public BoxCollider playerOneCollider;
	public BoxCollider playerTwoCollider;

	int gameState = 0; //1: player 1 starting, -1: player 2 starting, 0: waiting to restart, 2: game going

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
