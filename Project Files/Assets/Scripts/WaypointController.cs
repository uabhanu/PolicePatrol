using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : Waypoint 
{
	void Start () 
	{
		truckLocations.Add(transform);
		SetData(3 , truckLocations);
	}

	void Update () 
	{
	
	}
}
