using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Damageable : MonoBehaviour {

	Timer theTimer;
	public lifeController lifeController;
	public bool invincible = false;
	nextStage next;
	public Text EndingGame;
	public Text timerText;
	Damageable playerOne;
	Damageable playerTwo;
	static int stage = 1;
	int p1L = 3;
	int p2L = 3;
	int p1Wins = 0;
	int p2Wins = 0;
	bool startOfStage = false;

	static bool doOnlyOnce = false;
	public List<string> myPowers = new List<string>();

	void OnTriggerEnter2D(Collider2D activator)
	{
		if (activator.gameObject.tag == "egg")
		{
			if (invincible)
			{
				Invoke("turnOffInvincible", 0.5f);
				//PUT INVINCIBILITY SPARKLE CODE HERE
				return;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		//Don't turn off Invincibilty if We're still switching stages
		if (col.gameObject.tag == "spikes" && startOfStage == false) 
		{
			if(invincible){
				Invoke ("turnOffInvincible", 0.5f);
				return;
			}
			lifeController.LoseLife();
		}
	}

	void turnOffInvincible(){
		invincible = false;
	}

	void Start() {
		next = GameObject.Find("Main Camera").GetComponent<nextStage>();
		theTimer = GameObject.FindWithTag("timer").GetComponent<Timer>();
		playerOne = GameObject.FindWithTag("P1").GetComponent<Damageable>();
		playerTwo = GameObject.FindWithTag("P2").GetComponent<Damageable>();
		theTimer.roundEnded = false;
	}

	void finishedRound(int player){
		playerOne.GetComponent<P1Move> ().enabled = false;
		playerTwo.GetComponent<P2Move> ().enabled = false;

		playerOne.GetComponent<P1Shoot>().enabled = false;
		playerTwo.GetComponent<P2Shoot>().enabled = false;
		playerOne.GetComponent<P1Shoot>().setCount(0);
		playerTwo.GetComponent<P2Shoot>().setCount(0);
		playerOne.GetComponent<P1Shoot>().disableEggs();
		playerTwo.GetComponent<P2Shoot>().disableEggs();

		if (player == 1){
			p1Wins++;
		}
		else if(player == 2){
			p2Wins++;
		}
		else if(player == 3){
			if (p1L < p2L) {
				p2Wins++;
			}
			if (p1L > p2L) {
				p1Wins++;
			}
		}
		Debug.Log ("Incremented P1Wins variable");

		if (stage == 3) {
			playerOne.GetComponent<P1Move> ().enabled = false;
			playerTwo.GetComponent<P2Move> ().enabled = false;
			playerOne.GetComponent<Damageable>().invincible = true;
			playerTwo.GetComponent<Damageable>().invincible = true;

			if(p1Wins > p2Wins){
				SceneManager.LoadScene(2);
			}
			else if(p1Wins < p2Wins){
				SceneManager.LoadScene(3);
			}
			else{ //There was no winner
				SceneManager.LoadScene (5);
			}


			p1L = 3;
			p2L = 3;
			Debug.Log ("STAGE 3");
			stage = 0;
			//GameObject.Find ("RightWallMove").GetComponent<MovingSpikes> ().stageset = true;
			return;
		}
		else if (stage < 3) {  //if stage = 3 then we're done with game
			stage++;
			Debug.Log("Incremented stage  " + stage);
			theTimer.reset ();

			next.nextRound (stage);  //moves the camera, increments the stage value, and sets player positions

			theTimer.roundEnded = false;
			theTimer.stopTime = false;

		}

	}

	void extraLife()
	{
		if (playerOne.myPowers.Count > 0)
		{
			if (playerOne.myPowers[0] == "extraLife")
			{
				playerOne.lifeController.gainLife();
				playerOne.myPowers.RemoveAt(0);
			}
		}

		if (playerTwo.myPowers.Count > 0)
		{
			if (playerTwo.myPowers[0] == "extraLife")
			{
				playerTwo.lifeController.gainLife();
				playerTwo.myPowers.RemoveAt(0);
			}
		}
	}

	IEnumerator displayStageWinner(int player){
		startOfStage = true;
		theTimer.enabled = false;
		playerOne.GetComponent<Damageable>().invincible = true;
		playerTwo.GetComponent<Damageable>().invincible = true;
		if(player == 1){
			EndingGame.text = "CHICKEN WON STAGE " + stage + "\n"; 
		}
		if(player ==2){
			EndingGame.text = "PENGUIN WON STAGE " + stage + "\n"; 
		}
		if(player == 3){
			if (p1L < p2L) {
				EndingGame.text += "Time's out! PENGUIN wins stage " + stage + "\n";
			}
			if (p1L > p2L) {
				EndingGame.text += "Time's out! CHICKEN wins stage " + stage + "\n";
			}
			if (p1L == p2L)
				EndingGame.text += "Time's out! It's a draw!\n";

		}
		yield return new WaitForSeconds (3f);
		EndingGame.text = "";
		playerOne.GetComponent<P1Move> ().enabled = true;
		playerTwo.GetComponent<P2Move> ().enabled = true;
		playerOne.GetComponent<Damageable>().invincible = false;
		playerTwo.GetComponent<Damageable>().invincible = false;
		theTimer.enabled = true;
		startOfStage = false;
	}


	void Update() {
		p1L = playerOne.lifeController.lifeCounter;
		p2L = playerTwo.lifeController.lifeCounter;
		extraLife();
		int winner = -1;
		if ((p1L <= 0 || p2L <= 0) )
		{
			theTimer.roundEnded = true;
			if (p1L <= 0 && theTimer.roundEnded) {
				winner = 2;
				StartCoroutine(displayStageWinner(winner));
				finishedRound (2);
			} else if (p2L <= 0 && theTimer.roundEnded) {
				winner = 1;
				StartCoroutine(displayStageWinner(winner));
				finishedRound (1);

			}
			playerOne.GetComponent<P1Move> ().enabled = false;
			playerTwo.GetComponent<P2Move> ().enabled = false;
		}

		if (theTimer.gameTimer < 0.001f )
		{
			theTimer.roundEnded = true;
			if (p1L < p2L) {
				StartCoroutine (displayStageWinner (3));
				finishedRound(2);
			}
			if (p1L > p2L) {
				StartCoroutine (displayStageWinner (3));
				finishedRound(1);
			}
			if (p1L == p2L) {
				StartCoroutine (displayStageWinner (3));
				finishedRound (0);
			}
			playerOne.GetComponent<P1Move> ().enabled = false;
			playerTwo.GetComponent<P2Move> ().enabled = false;
		}





	}
}