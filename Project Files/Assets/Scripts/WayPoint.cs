using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour 
{
	private int breakWhile = 1;
	public Collider[] waypointColliders;
	public int sphereDistance = 10;
	public LayerMask layerMask = 1 << 8;
	public List<Transform> truckLocations;

	void Awake()
	{
		while(waypointColliders.Length < 3 && breakWhile < 10)
		{
			waypointColliders = Physics.OverlapSphere(transform.position , sphereDistance , layerMask);
			sphereDistance += 10;
			breakWhile++;
		}
	}

	public void SetData(List<Transform> newList)
	{
		if(truckLocations.Count == 0 || newList[0] != truckLocations[0] || newList.Count < truckLocations.Count)
		{
			truckLocations = newList;
			truckLocations.Add(transform);
			SendData();
		}
	}

	void SendData()
	{
		foreach(Collider wayPointCollider in waypointColliders)
		{
			if(!truckLocations.Contains(wayPointCollider.transform))
			{
				wayPointCollider.gameObject.GetComponent<Waypoint>().SetData(new List<Transform>(truckLocations));
				//wayPointCollider.gameObject.GetComponent<Waypoint>().SetData(truckLocations);
			}
		}
	}

	public void InitializeData()
	{
		truckLocations.Clear();
		SetData(truckLocations);
	}

	void Update () 
	{
	
	}
}
