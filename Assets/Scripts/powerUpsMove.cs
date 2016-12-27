using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class powerUpsMove : MonoBehaviour {
    // This script will be placed on each powerup
    //Powerup can be found in PreFabs folder

    Damageable playerOne;
    Damageable playerTwo;
    P1Shoot P1;
    P2Shoot P2;
    public Rigidbody2D power;

	void Start(){
        playerOne = GameObject.FindWithTag("P1").GetComponent<Damageable>();
        P1 = GameObject.FindWithTag("P1").GetComponent<P1Shoot>();
        playerTwo = GameObject.FindWithTag("P2").GetComponent<Damageable>();
        P2 = GameObject.FindWithTag("P2").GetComponent<P2Shoot>();
        power = GetComponent<Rigidbody2D>();
        //Destroy powerup if no player gets it 
        Destroy (this.gameObject, 19f);
	}
	void Update () {
		//Move powerup randomly
		power.AddForce( (Random.insideUnitCircle) * 2f );
	}



	void OnTriggerEnter2D(Collider2D activator){

		//when a player touches a powerup
		if(activator.GetComponent<Damageable>() != null){
            //check what type of powerup the player touched
            if (gameObject.tag == "Invincible")
            {
				
				if (activator.tag == "P1") 
					playerOne.GetComponent<Damageable> ().invincible = true;
				
				if (activator.tag == "P2")
					playerTwo.GetComponent<Damageable> ().invincible = true;
                //call invincibility function
            }

			if (gameObject.tag == "extraLife")
            {
                if(activator.tag == "P1")
                    playerOne.myPowers.Add("extraLife");

                if (activator.tag == "P2")
                    playerTwo.myPowers.Add("extraLife");
            }


            if (gameObject.tag == "dashAttack")
            {
                if (activator.tag == "P1")
                    playerOne.GetComponent<P1DashAttack>().enabled = true;

                if (activator.tag == "P2")
                    playerTwo.GetComponent<P2DashAttack>().enabled = true;                //call dash Attack function
            }

            if (gameObject.tag == "shootEgg")
            {
                if (activator.tag == "P1")
                {
                    P1.GetComponent<P1Shoot>().enabled = true;
                    P1.GetComponent<P1Shoot>().setCount(3);
                    P1.GetComponent<P1Shoot>().enableEggs();
                }

                if (activator.tag == "P2")
                {
                    P2.GetComponent<P2Shoot>().enabled = true;
                    P2.GetComponent<P2Shoot>().setCount(3);
                    P2.GetComponent<P2Shoot>().enableEggs();
                }
            }


            Destroy(gameObject);

		}
	}
}
