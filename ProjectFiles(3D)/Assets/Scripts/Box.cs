using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour 
{	
	void Start () 
	{

	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag.Equals("Floor"))
		{
			Destroy(this.gameObject);
		}
	}

	void Update () 
	{
	
	}
}
