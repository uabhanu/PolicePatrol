using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour 
{
	private int breakWhile = 1 , countDown = 3;
	public Collider[] wayPointColliders;
	public int wayPointDistance = 10;
	public LayerMask layer = 1 << 8;
	
	void Awake () 
	{
		while(wayPointColliders.Length < 3 && breakWhile < 10)
		{
			wayPointColliders = Physics.OverlapSphere(transform.position , wayPointDistance , layer);
			wayPointDistance += 10;
			breakWhile++;
		}
	}
	
	public void SetData(int incomingData)
	{
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
				wayPointCollider.gameObject.GetComponent<WayPoint>().SetData(countDown);
			}
		}
	}

	void Update () 
	{
	
	}
}
