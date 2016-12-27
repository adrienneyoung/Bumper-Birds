using UnityEngine;
using System.Collections;

public class RedMove : MonoBehaviour {
	public float speed = 5f;

	//will multiply this by the speed to give the illusion 
	//that the bird isnt always moving in straight lines
	public float sideSpeed = 0.1f;

	public Rigidbody2D birds;

	void Start () {
		//asssign reference automatically IF this script is on the same object as Rigidbody2D
		birds = GetComponent<Rigidbody2D> ();
	}


	// Update is called once per frame
	void Update () {


		if(Input.GetKey(KeyCode.W)){
			//Going up and very slightly to the right
			birds.AddForce (new Vector2 (speed*sideSpeed, speed));
		}

		if(Input.GetKey(KeyCode.S)){
			//Going down and slightly to the right
			birds.AddForce (new Vector2 (speed*sideSpeed, -speed));
		}

		if(Input.GetKey(KeyCode.A)){
			//Going left and slightly up
			birds.AddForce (new Vector2 (-speed, speed*sideSpeed));

		}

		if(Input.GetKey(KeyCode.D)){
			//Going right and slighty up
			birds.AddForce (new Vector2 (speed, speed*sideSpeed));

		}
	}
}
