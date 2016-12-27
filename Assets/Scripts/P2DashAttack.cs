using UnityEngine;
using System.Collections;
public class P2DashAttack : MonoBehaviour {
	public P2Move red;
	public float newSpeed = 30f;
	float originalSpeed = 8f;
	float lastTimeIDash = 0;
	int pressSpaceBar = 3;
	// Use this for initialization
	void Start () {
		red.GetComponents <P2Move> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.KeypadEnter) && pressSpaceBar > 0 ) {
			red.changeSpeed (newSpeed);
			lastTimeIDash = Time.time;
			pressSpaceBar--;
		}
		if (lastTimeIDash +5f < Time.time) {
			red.changeSpeed (originalSpeed);
		}
		if (pressSpaceBar == 0){
			red.GetComponent<P2DashAttack> ().enabled = false;
		}
	}
}