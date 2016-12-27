using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goToInstructions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene(4);
        }
    }
}
