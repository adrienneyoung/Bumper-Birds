using UnityEngine;
using System.Collections;

public class eggProjectile2 : MonoBehaviour
{
    public int direction;

    void Start()
    {
        //facing right
        if (GameObject.FindWithTag("P2").GetComponent<P2Move>().flipper.flipX)
        {
            direction = 1;
        }

        //facing left
        if (!GameObject.FindWithTag("P2").GetComponent<P2Move>().flipper.flipX)
        {
            direction = -1;
        }

        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(direction);
        transform.Translate(5f * direction * Time.deltaTime, 0f, 0f);
    }

    void OnTriggerEnter2D(Collider2D activator)
    {
        //if this activator is tagged BulletPass then ignore it
        if (activator.tag == "egg" || activator.tag == "shootEgg" || activator.tag == "dashAttack" || activator.tag == "Invincible" || activator.tag == "extraLife")
            return; //end this function early and ignore it

        if (activator.GetComponent<Damageable>() != null && activator.GetComponent<Damageable>().invincible == false)
        {
            activator.GetComponent<Damageable>().lifeController.LoseLife();
            activator.GetComponent<ColorFlash>().playerFlash();
        }

        Destroy(this.gameObject);
    }
}
