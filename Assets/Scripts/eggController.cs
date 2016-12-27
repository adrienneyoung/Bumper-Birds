using UnityEngine;
using System.Collections;

public class eggController : MonoBehaviour {

    public Egg[] eggs;
    int eggCount = 0;

    public void loseEgg()
    {
        eggCount--;
        eggs[eggCount].disappear();
    }
}
