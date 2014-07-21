using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour 
{
	private int breakWhile = 1;
	public Collider[] wayPointColliders;
	public int wayPointDistance = 10;
	public LayerMask layer = 1 << 8;
	public List<Transform> truckLocation;
	
	void Awake () 
	{
		truckLocation = new List<Transform>();

		while(wayPointColliders.Length < 3 && breakWhile < 10)
		{
			wayPointColliders = Physics.OverlapSphere(transform.position , wayPointDistance , layer);
			wayPointDistance += 10;
			breakWhile++;
		}
	}

	public void InitializeData()
	{
		truckLocation.Clear();
		SetData(truckLocation);
	}
	
	public void SetData(List<Transform> newList)
	{
		//Debug.Log("SetData Method");

		if(truckLocation.Count == 0 || newList[0] != truckLocation[0] || newList.Count < truckLocation.Count)
		{
			truckLocation = newList;
			truckLocation.Add (transform);
			SendData();
		}
	}

	public void SendData()
	{
		foreach(Collider wayPointCollider in wayPointColliders)
		{
			if(!truckLocation.Contains(wayPointCollider.transform))
			{
				wayPointCollider.gameObject.GetComponent<WayPoint>().SetData(new List<Transform>(truckLocation));
			}
		}
	}

	public List<Transform> GetTruckLocation()
	{
		return new List<Transform>(truckLocation);
	}

	void Update () 
	{
	
	}
}
