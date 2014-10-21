using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	//[HideInInspector]
	public InGameUI iguiScript;
	public float spawnTimer , spawnLocationX , spawnLocationZ;
	public float[] xPositions , zPositions;
	public GameObject iguiObj , thugObj;
	public int randomPos;
	public SpawnCheck sCheckScript;
	public Thug thugScript;
	
	void Start () 
	{
		iguiObj = GameObject.FindGameObjectWithTag("IGUI");

		if(iguiObj != null)
		{
			iguiScript = iguiObj.GetComponent<InGameUI>();
		}

		if(thugObj != null)
		{
			thugScript = thugObj.GetComponent<Thug>();
		}
				
		StartCoroutine("EnemySpawnFalse");
		StartCoroutine("EnemySpawnTimer");
	}
	
	public void EnemySpawn()
	{
		if(randomPos == 1)
		{
			if(sCheckScript != null && !sCheckScript.spawned)
			{
				spawnLocationX = xPositions[0];
				spawnLocationZ = zPositions[0];
			}
		}
		
		if(randomPos == 2)
		{
			if(sCheckScript != null && !sCheckScript.spawned)
			{
				spawnLocationX = xPositions[1];
				spawnLocationZ = zPositions[0];
			}
		}
		
		if(randomPos == 3)
		{
			if(sCheckScript != null && !sCheckScript.spawned)
			{
				spawnLocationX = xPositions[2];
				spawnLocationZ = zPositions[1];
			}
		}
		
		if(randomPos == 4)
		{
			if(sCheckScript != null && !sCheckScript.spawned)
			{
				spawnLocationX = xPositions[3];
				spawnLocationZ = zPositions[1];
			}
		}

		if(iguiScript != null)
		{
			if(sCheckScript != null && !sCheckScript.spawned && iguiScript.thugCount < iguiScript.maxThugCount)
			{
				//Debug.Log("Enemy Spawner");
				Instantiate (thugObj , new Vector3(spawnLocationX , 0 , spawnLocationZ) , Quaternion.identity);
				iguiScript.thugCount++;
				sCheckScript.spawned = true;				
			}
		}
	}

	IEnumerator EnemySpawnFalse()
	{
		yield return new WaitForSeconds(8);

		if(sCheckScript.spawned)
		{
			sCheckScript.spawned = false;
		}

		StartCoroutine("EnemySpawnFalse");
	}

	IEnumerator EnemySpawnTimer()
	{
		yield return new WaitForSeconds(spawnTimer);
		EnemySpawn();
		StartCoroutine("EnemySpawnTimer");
	}

	void Update () 
	{
		randomPos = (int)Random.Range(0 , 4);
	}
}
