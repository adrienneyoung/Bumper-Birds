using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour {

    P1Shoot p1;

    public void disappear()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void reppear()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    /*
    void Update()
    {
        transform.Rotate(0, 0, 300 * Time.deltaTime);
    }
    */
}
