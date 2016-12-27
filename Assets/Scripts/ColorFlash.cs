using UnityEngine;
using System.Collections;

public class ColorFlash : MonoBehaviour {

	private bool flash;
	public float flash_duration; //0.5
	private float counter;
	public bool dontBlink = false;
	private SpriteRenderer player;

	void Start() {
		player = GetComponent<SpriteRenderer> ();
	}

    public void playerFlash()
    {
        if (gameObject.GetComponent<Damageable>().invincible == true)
        {
            flash = false;
        }
        else
        {
            flash = true;
            counter = flash_duration;
        }
    }

    void OnCollisionEnter2D (Collision2D col)
	{
		
		if (col.gameObject.tag == "spikes") {
            playerFlash();
		}
	}

	void Update () {
		if (gameObject.GetComponent<Damageable> ().invincible == true) {
			dontBlink = true;
		} else { 	
			dontBlink = false;
		}
			
		if(flash == true && dontBlink == false){
			//if above 2/3 a second, go red. if above 1/3 a second, stay same, if above 0 seconds, go red
			if(counter > flash_duration * .66f){
				player.color = new Color (player.color.r, player.color.g, player.color.b, 0f);
			} else if (counter > flash_duration * .33f){
				player.color = new Color (player.color.r, player.color.g, player.color.b, 1f);
			} else if (counter > 0){
				player.color = new Color (233, 24, 24, 0f);
			} else {
				player.color = new Color (player.color.r, player.color.g, player.color.b, 1f);
				flash = false;
			}

			counter -= Time.deltaTime;
		}


	}// end of Update
}
