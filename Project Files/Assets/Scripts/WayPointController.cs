using System.Collections;
using UnityEngine;

public class WayPointController : MonoBehaviour 
{
	Collider[] closestWayPointColliders;
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

	public GameObject ClosestWayPoint(Transform inTransform)
	{
		GameObject closestCollider;
		int breakWhile = 1;
		int sphereDistance = 10;
		Vector3 inPosition = inTransform.position;

		closestWayPointColliders = Physics.OverlapSphere(inPosition , 1 , layer);

		while(closestWayPointColliders.Length < 3 && breakWhile < 10)
		{
			closestWayPointColliders = Physics.OverlapSphere(inPosition , sphereDistance , layer);

			if(closestWayPointColliders.Length > 0)
			{
				return closestWayPointColliders[0].gameObject;
			}

			sphereDistance += 10;
			breakWhile++;
		}
	}
}
