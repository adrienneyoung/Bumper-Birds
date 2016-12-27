using UnityEngine;
using System.Collections;
public class P2bumpSound : MonoBehaviour {
	AudioSource source ; 
	void Start () {
		source = GetComponent <AudioSource> ();
	}

	public void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.GetComponent <Damageable> () != null || col.gameObject.tag == "spikes") {
			source.Play ();
		}
	}
}