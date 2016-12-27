using UnityEngine;
using System.Collections;

public class P1Shoot : MonoBehaviour
{
    public P1Move P1;
    public GameObject projectilePrefab;
    public Egg[] eggs;
    int eggCount = 0;


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
        P1 = GetComponent<P1Move>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("egg count: " + getCount());

        if (Input.GetKeyDown(KeyCode.Space) && eggCount > 0)
        {
            //facing right
            if (P1.flipper.flipX)
				Instantiate(projectilePrefab, transform.position + (transform.right * 2), Quaternion.Euler(0f, 0f, 0f));

            //facing left
            if (!P1.flipper.flipX)
				Instantiate(projectilePrefab, transform.position - (transform.right * 2), Quaternion.Euler(0f, 0f, 0f));

            eggCount--;
            eggs[eggCount].disappear();
        }


        if (eggCount == 0)
        {
            P1.GetComponent<P1Shoot>().enabled = false;
        }
    }

}
