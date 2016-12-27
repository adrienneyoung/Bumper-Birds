using UnityEngine;
using System.Collections;

public class P1Move : MonoBehaviour
{
    Rigidbody2D myRigidBody; 
    public float moveSpeed = 10.0f; 
	public SpriteRenderer flipper;
    
    //will multiply this by the speed to give the illusion 
	//that the bird isnt always moving in straight lines
	public float sideSpeed = 0.1f;

    void Start () {
		//asssign reference automatically IF this script is on the same object as Rigidbody2D
		myRigidBody = GetComponent<Rigidbody2D> ();
	}
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
			//Going up and very slightly to the right
			myRigidBody.AddForce (new Vector2 (moveSpeed*sideSpeed, moveSpeed));
		}

		if(Input.GetKey(KeyCode.S)){
			//Going down and slightly to the right
			myRigidBody.AddForce (new Vector2 (moveSpeed*sideSpeed, -moveSpeed));
		}

		if(Input.GetKey(KeyCode.A)){
			//Going left and slightly up
			myRigidBody.AddForce (new Vector2 (-moveSpeed, moveSpeed*sideSpeed));
			flipper.flipX = false;
		}

		if(Input.GetKey(KeyCode.D)){
			//Going right and slighty up
			myRigidBody.AddForce (new Vector2 (moveSpeed, moveSpeed*sideSpeed));
			flipper.flipX = true;
		}
    }

	public void changeSpeed (float newSpeed){
		moveSpeed = newSpeed;
	}
}
