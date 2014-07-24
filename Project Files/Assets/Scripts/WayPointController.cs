using System.Collections;
using UnityEngine;

public class WayPointController : MonoBehaviour 
{
	public Collider[] closestWayPointColliders;
	public GameObject closestToLeftTruck , closestToRightTruck;
	public GameObject[] wayPoints;
	public LayerMask layer = 1 << 8;
	public Transform leftTruckLocation , rightTruckLocation;
	public WayPoint wayPointScript;
	
	void Start () 
	{
		wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");

		if(wayPoints != null)
		{
			wayPointScript = wayPoints[0].GetComponent<WayPoint>();
		}

		WaitAndUpdate();
	}

	void Update () 
	{

	}
	
	public void WaitAndUpdate()
	{
		closestToLeftTruck = FindClosestWayPoint(leftTruckLocation);
		closestToRightTruck = FindClosestWayPoint(rightTruckLocation);

		if(closestToLeftTruck != null)
		{
			closestToLeftTruck.GetComponent<WayPoint>().InitializeData();
		}

		if(closestToRightTruck != null)
		{
			closestToRightTruck.GetComponent<WayPoint>().InitializeData();
		}

		StartCoroutine("WaitAndUpdateTimer");
	}

	public GameObject FindClosestWayPoint(Transform inTransform)
	{
		GameObject wayPoint = null;
		int breakWhile = 1;
		int sphereDistance = 5;
		Vector2 inPosition = inTransform.position;

		closestWayPointColliders = Physics.OverlapSphere(inPosition , 0 , layer);

		while(closestWayPointColliders.Length < 3 && breakWhile < 10)
		{
			closestWayPointColliders = Physics.OverlapSphere(inPosition , sphereDistance , layer);

			if(closestWayPointColliders.Length > 1)
			{
				return wayPoint = closestWayPointColliders[1].gameObject;
			}

			sphereDistance += 1;
			breakWhile++;
		}

		return null;
	}

	IEnumerator WaitAndUpdateTimer()
	{
		yield return new WaitForSeconds(2);
		WaitAndUpdate();
	}
}
