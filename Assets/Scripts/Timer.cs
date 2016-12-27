using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float gameTimer = 120f;
    public Text timerText;
    public bool roundEnded = false;
	public float textTimeLength = 0f;
	public bool stopTime = false;
	//public Text Instruction;

	public void reset(){
		gameTimer = 120f;
	}

	public bool Wait(float time){
		bool returnValue = false;
		while(time > 0.0001f){
			time -= Time.deltaTime;
			Debug.Log ("Waiting");
			if (time <= 0.0001f)
				returnValue = true;
		}
		return returnValue;
	}

    public void countdown()
    {
		if(!stopTime)
        	gameTimer -= Time.deltaTime;
    }

    void Update () {
		if (roundEnded) {
			timerText.color = Color.green;
			return;
		} 

		if (gameTimer > 0.001f && !stopTime) {
			countdown ();

			string minutes = ((int)gameTimer / 60).ToString ();
			string seconds = (gameTimer % 60).ToString ("f2");	
			timerText.text = minutes + ":" + seconds;
		} 
    }
}
