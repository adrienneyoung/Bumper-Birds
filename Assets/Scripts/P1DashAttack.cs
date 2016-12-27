

using UnityEngine;
using System.Collections;
public class P1DashAttack : MonoBehaviour {
	public P1Move blue;
	public float newSpeed = 30f;
	float originalSpeed = 8f;
	float lastTimeIDash = 0;
	int pressSpaceBar = 3;
	// Use this for initialization
	void Start () {
		blue.GetComponents <P1Move> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && pressSpaceBar > 0 ) {
			blue.changeSpeed (newSpeed);
			lastTimeIDash = Time.time;
			pressSpaceBar--;
		}
		if (lastTimeIDash +5f < Time.time) {
			blue.changeSpeed (originalSpeed);
		}
		if (pressSpaceBar == 0){
			blue.GetComponent<P1DashAttack> ().enabled = false;
		}
	}
}