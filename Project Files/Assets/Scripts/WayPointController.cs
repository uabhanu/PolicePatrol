using System.Collections;
using UnityEngine;

public class WayPointController : MonoBehaviour 
{
	public GameObject[] wayPoints;
	public LayerMask layer = 1 << 8;
	public Transform truckLocation;
	public WayPoint wayPointScript;
	
	void Start () 
	{
		truckLocation = GameObject.FindGameObjectWithTag("Truck").transform;
		wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");

		if(wayPointScript != null)
		{
			wayPointScript.InitializeData();
		}
	}

	void Update () 
	{
	
	}

	public GameObject FindClosestWayPoint(Transform inTransform)
	{
		Collider[] closestWayPointColliders;
		GameObject wayPoint = null;
		int breakWhile = 1;
		int sphereDistance = 2;
		Vector2 inPosition = inTransform.position;

		closestWayPointColliders = Physics.OverlapSphere(inPosition , 0 , layer);

		while(closestWayPointColliders.Length < 3 && breakWhile < 10)
		{
			closestWayPointColliders = Physics.OverlapSphere(inPosition , sphereDistance , layer);

			if(closestWayPointColliders.Length > 0)
			{
				return wayPoint = closestWayPointColliders[0].gameObject;
			}

			sphereDistance += 10;
			breakWhile++;
		}

		return null;
	}
}
