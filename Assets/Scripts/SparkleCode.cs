using UnityEngine;
using System.Collections;

public class SparkleCode : MonoBehaviour {

	public SpriteRenderer glitter;
	public Damageable damagescript;

	void Start () {
		SpriteRenderer glitter = gameObject.GetComponent<SpriteRenderer> ();
	}

	void Update () {
		glitter.enabled = false;
		if (damagescript.invincible == true)
		{
			glitter.enabled = true;
		}
		else
		{
			glitter.enabled = false;
		}
	}
}
