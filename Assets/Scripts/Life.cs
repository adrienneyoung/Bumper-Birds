using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	lifeController Lives;


	public void disappear ( ){
		//Destroy(gameObject);
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;

	}

	public void reappear(){
		gameObject.GetComponent<SpriteRenderer> ().enabled = true;


	}
}
