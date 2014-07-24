using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour 
{
	private int breakWhile = 1;
	public Collider[] waypointColliders;
	public int countDown = 3 , sphereDistance = 10;
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

	void Start () 
	{

	}

	public void SetData(int inData , List<Transform> newList)
	{
		truckLocations = newList;
		truckLocations.Add(transform);
		countDown = inData;
		countDown--;
		Debug.Log("The Waypoint " + this.name + " sent the countdown of " + countDown);
		SendData();
	}

	void SendData()
	{
		if(countDown > 0)
		{
			foreach(Collider wayPointCollider in waypointColliders)
			{
				if(!truckLocations.Contains(wayPointCollider.transform))
				{
					//wayPointCollider.gameObject.GetComponent<Waypoint>().SetData(countDown);
					SetData(countDown , truckLocations);
				}
			}
		}
	}

	void Update () 
	{
	
	}
}
