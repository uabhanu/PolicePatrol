using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public bool firstUpdate;
	public float speed;
	public GameObject closestWayPoint , wayPointObj;
	WayPointController wayPointControlScript;
	
	void Start () 
	{
		wayPointObj = GameObject.FindGameObjectWithTag("WayPointControl");

		if(wayPointObj != null)
		{
			wayPointControlScript = wayPointObj.GetComponent<WayPointController>();
		}
	}
	
	void Update () 
	{
		if(firstUpdate)
		{
			closestWayPoint = wayPointControlScript.ClosestWayPoint(transform);
		}
	}
}
