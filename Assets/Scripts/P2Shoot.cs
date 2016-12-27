using UnityEngine;
using System.Collections;

public class P2Shoot : MonoBehaviour
{
    public P2Move P2;
    public GameObject projectilePrefab;
    public Egg[] eggs;
    public int eggCount = 0;

    public int getCount()
    {
        return eggCount;
    }

    public void loseEgg()
    {
        eggCount--;
        eggs[eggCount].disappear();
    }

    public void enableEggs()
    {
        for (int i = 0; i < eggCount; i++)
        {
            eggs[i].reppear();
        }
    }

    public void disableEggs()
    {
        for (int i = 0; i < 3; i++)
        {
            eggs[i].disappear();
        }
    }

    public void setCount(int num)
    {
        eggCount = num;
    }

    void Start()
    {
        P2 = GetComponent<P2Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && eggCount > 0)
        {
            //facing right
            if (P2.flipper.flipX)
				Instantiate(projectilePrefab, transform.position + (transform.right * 2), Quaternion.Euler(0f, 0f, 0f));

            //facing left
            if (!P2.flipper.flipX)
				Instantiate(projectilePrefab, transform.position - (transform.right * 2), Quaternion.Euler(0f, 0f, 0f));

            eggCount--;
            eggs[eggCount].disappear();
        }


        if (eggCount == 0)
        {
            P2.GetComponent<P2Shoot>().enabled = false;
        }
    }
}
