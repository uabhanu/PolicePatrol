using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour 
{
	public Collider[] wayPointColliders;
	
	void Start () 
	{
		wayPointColliders = Physics.OverlapSphere(transform.position , 20);
	}

	void Update () 
	{
	
	}
}
