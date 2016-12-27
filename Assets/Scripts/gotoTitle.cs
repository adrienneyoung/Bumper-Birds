using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gotoTitle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene(0);
        }
    }
}
