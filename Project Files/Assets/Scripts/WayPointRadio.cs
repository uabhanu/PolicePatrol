using UnityEngine;
using System.Collections;

public class WayPointRadio : MonoBehaviour 
{
	public WayPoint wayPointScript;
	
	void Start () 
	{
		if(wayPointScript != null)
		{
			wayPointScript.SetData(3);
		}
	}

	void Update () 
	{
	
	}
}
