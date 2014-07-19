using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour 
{
	private int breakWhile = 1;
	public int countDown = 3;
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
	
	public void SetData(int incomingData , List<Transform> newList)
	{
		//Debug.Log("SetData Method");

		truckLocation = newList;
		truckLocation.Add (transform);
		countDown = incomingData;
		countDown--;

		Debug.Log("WayPoint : " + this.name + " Sent the countdown of : " + countDown);

		SendData();
	}

	public void SendData()
	{
		if(countDown > 0)
		{
			foreach(Collider wayPointCollider in wayPointColliders)
			{
				if(!truckLocation.Contains(wayPointCollider.transform))
				{
					wayPointCollider.gameObject.GetComponent<WayPoint>().SetData(countDown , truckLocation);
				}
			}
		}
	}

	void Update () 
	{
	
	}
}
