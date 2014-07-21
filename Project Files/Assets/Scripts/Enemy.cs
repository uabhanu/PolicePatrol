using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public bool firstUpdate = true;
	public float speed;
	public GameObject closestWayPoint;
	WayPointController wayPointControlScript;
	
	void Start () 
	{
		if(firstUpdate)
		{
			closestWayPoint = wayPointControlScript.ClosestWayPoint(transform);
		}
	}
	
	void Update () 
	{

	}
}
