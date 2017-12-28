//Jonne Kaunisto, December 2017
//controls the game state
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int transitionTime = 4;

	public GameObject ball;

	public GameObject ballPlayerOneStart;
	public GameObject ballPlayerTwoStart;

	public GameObject goalPlayerOne;
	public GameObject goalPlayerTwo;

	public static GameController _instance;
	public static GameController Instance{
		get{return _instance;}
	}

	int gameState = 0; //1: player 1 starting, 2: player 2 starting, 0: waiting to restart, 3: game going

	int playerOneScore = 0;
	int playerTwoScore = 0;

	void Awake(){
		_instance = this;
	}

	// Use this for initialization
	void Start () {
		ball.transform.position = ballPlayerOneStart.transform.position;
		gameState = 1;
		ball.GetComponent<Rigidbody>().velocity = new Vector3 (02f, 02f, -8f);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//takes the side which the point was scored on
	public void ScoredPointOn(int side){
		if (side == 1) {
			playerTwoScore++;
			StartCoroutine (SetUpForPlayerTwo ());
		} else {
			playerOneScore++;
			StartCoroutine (SetUpForPlayerOne ());
		}



	}

	IEnumerator SetUpForPlayerOne(){
		yield return new WaitForSeconds (transitionTime);
		ball.transform.position = ballPlayerOneStart.transform.position;
		gameState = 1;
		ball.GetComponent<Rigidbody>().velocity = new Vector3 (02f, 02f, -8f);
		SetUpGoals ();
	}

	IEnumerator SetUpForPlayerTwo(){
		yield return new WaitForSeconds (transitionTime);
		ball.transform.position = ballPlayerTwoStart.transform.position;
		gameState = 2;
		ball.GetComponent<Rigidbody>().velocity = new Vector3 (02f, 02f, 8f);
		SetUpGoals ();
	}

	void SetUpGoals(){
		goalPlayerOne.transform.localPosition = Vector3.zero;
		goalPlayerTwo.transform.localPosition = Vector3.zero;

		goalPlayerOne.transform.localRotation = Quaternion.identity;
		goalPlayerTwo.transform.localRotation = Quaternion.identity;



		Rigidbody playerOne = goalPlayerOne.GetComponent<Rigidbody> ();
		playerOne.velocity = Vector3.zero;
		Rigidbody playerTwo = goalPlayerTwo.GetComponent<Rigidbody> ();
		playerTwo.velocity = Vector3.zero;

		playerOne.ResetInertiaTensor();
		playerTwo.ResetInertiaTensor ();

		playerOne.angularVelocity = Vector3.zero;
		playerTwo.angularVelocity = Vector3.zero;
	}


}
