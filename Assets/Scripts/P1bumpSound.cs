using UnityEngine;
using System.Collections;
public class P1bumpSound : MonoBehaviour {
	AudioSource source;
	Rigidbody2D playerOne;
	// Use this for initialization
	void Start () {
		source = GetComponent <AudioSource> ();
	}
	public void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.GetComponent <Damageable> () != null || col.gameObject.tag == "spikes") {
			source.Play ();
		}
	}
}
