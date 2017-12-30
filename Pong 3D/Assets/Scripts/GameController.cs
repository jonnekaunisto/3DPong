//Jonne Kaunisto, December 2017
//controls the game state
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour {

	public enum playMode{SinglePlayer, SinglePlayerAI, AIGame, Multiplayer};

	public NetworkManager man;
	public playMode mode;

	public float transitionTime = 4;

	public GameObject ballPrefab;
	public GameObject ball;
	public BallScript ballScript;

	public GameObject playerOne;
	public GameObject playerTwo;

	public PlayerScript playerOneScript;
	public PlayerScript playerTwoScript;

	public GameObject ballPlayerOneStart;
	public GameObject ballPlayerTwoStart;

	public GameObject goalPlayerOne;
	public GameObject goalPlayerTwo;

	public Text playerOneScoreText;
	public Text playerTwoScoreText;

	public AudioClip winSound;
	public AudioClip loseSound;

	public static GameController _instance;
	public static GameController Instance{
		get{return _instance;}
	}

	int gameState = 0; //1: player 1 starting, 2: player 2 starting, 0: waiting to restart, 3: game going

	int playerOneScore = 0;
	int playerTwoScore = 0;

	AudioSource source;

	void Awake(){
		_instance = this;

		source = GetComponent<AudioSource> ();

		if (mode == playMode.SinglePlayer) {
			playerOne.GetComponent<PlayerAIScript> ().enabled = false;
			playerTwo.GetComponent<PlayerAIScript> ().enabled = false;

			playerOneScript = playerOne.GetComponent<PlayerHumanScript> ();
			playerOneScript.enabled = true;
			playerTwoScript = playerTwo.GetComponent<PlayerHumanScript> ();
			playerTwoScript.enabled = true;

		} else if (mode == playMode.SinglePlayerAI) {
			playerOne.GetComponent<PlayerAIScript> ().enabled = false;
			playerTwo.GetComponent<PlayerHumanScript> ().enabled = false;

			playerOneScript = playerOne.GetComponent<PlayerHumanScript> ();
			playerOneScript.enabled = true;
			playerTwoScript = playerTwo.GetComponent<PlayerAIScript> ();
			playerTwoScript.enabled = true;
		} else if (mode == playMode.AIGame) {
			playerOne.GetComponent<PlayerHumanScript> ().enabled = false;
			playerTwo.GetComponent<PlayerHumanScript> ().enabled = false;

			playerOneScript = playerOne.GetComponent<PlayerAIScript> ();
			playerOneScript.enabled = true;
			playerTwoScript = playerTwo.GetComponent<PlayerAIScript> ();
			playerTwoScript.enabled = true;
		}


	}

	// Use this for initialization
	void Start () {
		if (mode == playMode.Multiplayer) {
			return;
		}
		ball = Instantiate (ballPrefab);
		ball.transform.position = ballPlayerOneStart.transform.position;

		FirstSetUp ();
	}

	//runs when the server starts
	public override void OnStartServer(){
		StartCoroutine (SpawnBall ());
	}

	//only for multiplayer, spawns the ball for all players
	IEnumerator SpawnBall(){
		yield return new WaitUntil (() => man.numPlayers == 2);
		ball = Instantiate (ballPrefab);
		ball.transform.position = ballPlayerOneStart.transform.position;
		NetworkServer.Spawn (ball);
		FirstSetUp ();


	}

	//sets up the play are for the first time
	void FirstSetUp(){
		ballScript = ball.GetComponent<BallScript> ();
		gameState = 1;
		playerOneScript.NewRound ();
		playerTwoScript.NewRound ();
		ball.GetComponent<Rigidbody>().velocity = new Vector3 (02f, 02f, -8f);
	}

	//takes the side which the point was scored on
	public void ScoredPointOn(int side){
		if (side == 1) {
			playerTwoScore++;
			StartCoroutine (SetUpForPlayerTwo ());
			source.clip = winSound;
			source.Play();
			playerTwoScoreText.text = "Player Two: " + playerTwoScore;

		} else {
			playerOneScore++;
			StartCoroutine (SetUpForPlayerOne ());
			source.clip = loseSound;
			source.Play ();
			playerOneScoreText.text = "Player One: " + playerOneScore;
		}

		playerOneScript.NewRound ();
		playerTwoScript.NewRound ();
	}

	//sets up the play are after player 1 won
	IEnumerator SetUpForPlayerOne(){
		yield return new WaitForSeconds (transitionTime);
		ball.transform.position = ballPlayerOneStart.transform.position;
		SetUpGoals ();
		ballScript.Reset();
		ball.GetComponent<Rigidbody>().velocity = new Vector3 (02f, 02f, -8f);
		playerOneScript.NewRound ();
		playerTwoScript.NewRound ();
	}

	//sets up the play are after player 2 won
	IEnumerator SetUpForPlayerTwo(){
		yield return new WaitForSeconds (transitionTime);
		ball.transform.position = ballPlayerTwoStart.transform.position;
		SetUpGoals ();
		ballScript.Reset();
		ball.GetComponent<Rigidbody>().velocity = new Vector3 (02f, 02f, 8f);
		playerOneScript.NewRound ();
		playerTwoScript.NewRound ();

	}

	//resets the goals to original positions
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
