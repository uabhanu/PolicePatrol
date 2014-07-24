using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour 
{
	public GameObject[] waypointObjs;
	public Transform truckLeftTransform , truckRightTransform;
	Waypoint waypointScript;

	void Start () 
	{
		truckLeftTransform = GameObject.FindGameObjectWithTag("Left").transform;
		truckRightTransform = GameObject.FindGameObjectWithTag("Right").transform;

		waypointObjs = GameObject.FindGameObjectsWithTag("Waypoint");

		waypointScript = GetComponent<Waypoint>();

		if(waypointScript != null)
		{
			waypointScript.InitializeData();
		}
	}

	void Update () 
	{
	
	}
}
