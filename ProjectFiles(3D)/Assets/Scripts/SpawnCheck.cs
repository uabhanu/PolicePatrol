using System.Collections;
using UnityEngine;

public class SpawnCheck : MonoBehaviour 
{
	public bool spawned;
	
	void Start () 
	{
		spawned = false;
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag.Equals("Enemy"))
		{
			spawned = true;
		}
	}

	void Update () 
	{
	
	}
}
