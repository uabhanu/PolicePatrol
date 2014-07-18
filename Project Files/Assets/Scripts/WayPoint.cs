using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour 
{
	private int breakWhile = 1;
	public Collider[] wayPointColliders;
	public int wayPointDistance = 10;
	public LayerMask layer = 1 << 8;
	
	void Start () 
	{
		while(wayPointColliders.Length < 3 && breakWhile < 10)
		{
			wayPointColliders = Physics.OverlapSphere(transform.position , wayPointDistance , layer);
			wayPointDistance += 10;
			breakWhile++;
		}
	}

	void Update () 
	{
	
	}
}
