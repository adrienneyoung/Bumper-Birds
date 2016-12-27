using UnityEngine;
using System.Collections;

public class MovingSpikes : MonoBehaviour {

	public GameObject spikes;
	public float speed;
	Transform to_point;
	public Transform[] anchors;
	public int point_choose;
	public bool stageset = false;

	// Use this for initialization
	void Start () {
		//goes from StartPoint to EndPoint
		to_point = anchors [point_choose];
	}
	
	// Update is called once per frame
	void Update () {
		//if (!GameObject.Find("Move_Angry_Spikes").GetComponent<MovingSpikes>().stageset || !GameObject.Find("Moving_Right_Spike").GetComponent<MovingSpikes>().stageset || !GameObject.Find("Moving_Left_Spike").GetComponent<MovingSpikes>().stageset){
			//stageset = true;
		//}
		if(stageset == true){
			speed = 2;
		}
		if(stageset == false){
			speed = 0;
		}

		//to_point is already a transform object so it doesn't need .transform
		//this moves spikes to the point it wants to move towards
		spikes.transform.position = Vector3.MoveTowards(spikes.transform.position, to_point.position, Time.deltaTime * speed);
		if(spikes.transform.position == to_point.position){
			//makes it so that the point selection loops through the array, thus making it move backwards too
			point_choose++;
			if(point_choose == anchors.Length){
				point_choose = 0;
			}//end check statement
			to_point = anchors[point_choose];
		}//change direction once one point is reached


	}


}
