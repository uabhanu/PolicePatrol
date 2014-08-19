using UnityEngine;
using System.Collections;

public class EnemySpawnCheck : MonoBehaviour 
{
	public bool enemySpawned;

	void Start () 
	{
	
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag.Equals("Enemy") || col.gameObject.tag.Equals("Target"))
		{
			Debug.Log("Spawn Check");
			enemySpawned = true;
		}
	}

	void Update () 
	{
	
	}
}
