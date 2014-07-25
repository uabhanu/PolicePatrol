using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour 
{
	private int breakWhile = 1;
	public Collider[] closeWaypoints;
	public GameObject closestWaypoint;
	public GameObject[] waypointObjs;
	public LayerMask layerMask = 1 << 8;
	public Transform truckLeftTransform , truckRightTransform;
	public Waypoint startWaypoint;

	void Start () 
	{
		truckLeftTransform = GameObject.FindGameObjectWithTag("Left").transform;
		truckRightTransform = GameObject.FindGameObjectWithTag("Right").transform;
		startWaypoint.InitializeData();
		waypointObjs = GameObject.FindGameObjectsWithTag("Waypoint");

	}

	public GameObject FindClosestWayPoint(Transform inTransform)
	{
		int sphereDistance = 10;
		Vector3 inPosition;

		inPosition = inTransform.position;
		closeWaypoints = Physics.OverlapSphere(inPosition , 1 , layerMask);

		while(closeWaypoints.Length < 3 && breakWhile < 10)
		{
			closeWaypoints = Physics.OverlapSphere(inPosition , sphereDistance , layerMask);

			if(closeWaypoints.Length > 0)
			{
				closestWaypoint = closeWaypoints[0].gameObject;
				//Debug.Log(closestWaypoint);
				return closestWaypoint;
			}

			sphereDistance += 10;
			breakWhile++;
		}

		return null;
	}

	void Update () 
	{
	
	}
}
