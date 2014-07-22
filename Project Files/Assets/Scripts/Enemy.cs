using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public bool firstUpdate;
	public float speed;
	public GameObject closestWayPoint , randomWayPoint , wayPointControlObj;
	WayPointController wayPointControlScript;
	
	void Start () 
	{
		wayPointControlObj = GameObject.FindGameObjectWithTag("WayPointControl");

		if(wayPointControlObj != null)
		{
			wayPointControlScript = wayPointControlObj.GetComponent<WayPointController>();
		}
	}
	
	void Update () 
	{
		if(firstUpdate)
		{
			closestWayPoint = wayPointControlScript.FindClosestWayPoint(transform);
		}
	}
}
