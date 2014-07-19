using System.Collections;
using UnityEngine;

public class WayPointRadio : MonoBehaviour 
{
	public WayPoint wayPointScript;
	
	void Start () 
	{
		if(wayPointScript != null)
		{
			wayPointScript.InitializeData();
		}
	}

	void Update () 
	{
	
	}
}
