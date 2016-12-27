using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

public class nextStage : MonoBehaviour {


	Camera mainCamera;
	Damageable playerOne;
	Damageable playerTwo;
	Rigidbody2D P1;
	Rigidbody2D P2;



	PowerUps box;

	Vector3 stage1 = new Vector3(0f,0f,-10f);
	Vector3 stage2 = new Vector3(0f,21.2f,-10.35f);
	Vector3 stage3 = new Vector3(-0.7f,43.7f,-10.35f);	

	Vector3 stage2P1 = new Vector3(-3.8f,22.11f,10f);
	Vector3 stage2P2 = new Vector3(5.13f,21.95f,10f);

	Vector3 stage3P1 = new Vector3(-1.89f, 43.79f,0f);
	Vector3 stage3P2 = new Vector3(0.74f,43.79f,0f);

	Vector3 stage2box = new Vector3(0.5f,20.12f,0f);
	Vector3 stage3box = new Vector3(-0.6f, 43f,0f);


	void Start () {
		//stage3stuff = GameObject.Find("RightWallMove").GetComponent<MovingSpikes>();
		mainCamera = Camera.main;
		playerOne = GameObject.FindWithTag("P1").GetComponent<Damageable>();
		playerTwo = GameObject.FindWithTag("P2").GetComponent<Damageable>();
		box = GameObject.FindWithTag ("box").GetComponent<PowerUps> ();
		P1 = GameObject.FindWithTag ("P1").GetComponent<Rigidbody2D> ();
		P2 = GameObject.FindWithTag ("P2").GetComponent<Rigidbody2D> ();

	}

	public void nextRound(int s){
		if(s == 2){
			mainCamera.transform.position = stage2;
			playerOne.lifeController.restoreLives ();
			playerTwo.lifeController.restoreLives ();
			playerOne.transform.position = stage2P1;
			playerTwo.transform.position = stage2P2;
			P1.velocity = new Vector2 (0f, 0f);
			P2.velocity = new Vector2 (0f, 0f);

			//box.transform.position = stage2box;

			s = 2;
		}
		if(s == 3){ //&& !GameObject.Find("RightWallMove").GetComponent<MovingSpikes>().stageset){
			//if (!GameObject.Find("RightWallMove").GetComponent<MovingSpikes>().stageset){

			//}
			if(!GameObject.Find ("RightWallMove").GetComponent<MovingSpikes> ().stageset){
				GameObject.Find ("RightWallMove").GetComponent<MovingSpikes> ().stageset = true;
			} //= true;
			GameObject.Find ("LeftWallMove").GetComponent<MovingSpikes> ().stageset = true;
			mainCamera.transform.position = stage3;
			playerOne.lifeController.restoreLives ();
			playerTwo.lifeController.restoreLives ();
			playerOne.transform.position = stage3P1;
			playerTwo.transform.position = stage3P2;
			//box.transform.position = stage3box;
			P1.velocity = new Vector2 (0f, 0f);
			P2.velocity = new Vector2 (0f, 0f);
			s = 3;
		}

	}

}