using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointRadio : MonoBehaviour 
{
	public List<Transform> truckLocation;
	public WayPoint wayPointScript;
	
	void Start () 
	{
		if(wayPointScript != null)
		{
			truckLocation.Add(wayPointScript.transform);
			wayPointScript.SetData(3 , truckLocation);
		}
	}

	void Update () 
	{
	
	}
}
