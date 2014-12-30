using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour 
{
	public PoliceController policeControlScript;
	
	void Start () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D col2D)
	{
		if(col2D.gameObject.tag.Equals("Player"))
		{
			Debug.Log("Police Touched Ladder");
		}
	}

	void Update () 
	{
	
	}
}
