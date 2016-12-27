using UnityEngine;
using System.Collections;

public class lifeController : MonoBehaviour {

	public Life[] Lives;
	public int lifeCounter = 3;

	public void LoseLife (){
		lifeCounter--;
		if(lifeCounter >=0){
			Lives [lifeCounter].disappear ();
        }
	}

    public void gainLife()
    {
        
        if (lifeCounter < Lives.Length)
        {
            Lives[lifeCounter].reappear();
            lifeCounter++;
        }

    }

    public void restoreLives(){
		int i = 0;
		while(i<3){
			Lives [i].reappear ();
			i++;
		}
		lifeCounter = 3;

	}
}
