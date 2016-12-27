using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {
	//This script will be placed on the center platform.
	//powerups will be spawned from it
	//will develop better when I get the chance

	Timer theTimer;
	float powerTime = 0.0f;
	public float powerUpFrequency = 20.0f; // how often do we want powerup to show up

	public GameObject[] Powers; // add the powers from the prefab into this list in the Inspector

	int count = 0;

	void Start () {
		theTimer = GameObject.FindWithTag("timer").GetComponent<Timer>();

	}
	bool check(float time){
		if (powerTime > powerUpFrequency) {
			powerTime = 0.0f;
			return true;
		}
		return false;
	}

	void Update () {
		powerTime += Time.deltaTime;

		if(check(powerTime) && !theTimer.roundEnded){
			if (count == 3) 
				count = 0;
			else
				count++;
			//transform.position = Random.insideUnitCircle *5; 
				
			Instantiate (Powers[count], //what we want to clone
				new Vector2(transform.position.x, transform.position.y) + (Random.insideUnitCircle) *5, //where the clone should be
				Quaternion.Euler (0f, 0f, 0f)); //rotations of clone
		}
	}
}
// + transform.up *1.5f