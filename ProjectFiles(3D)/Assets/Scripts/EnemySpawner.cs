using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	//[HideInInspector]
	public InGameUI iguiScript;
	public float spawnTimer , spawnLocationX , spawnLocationZ;
	public float[] xPositions , zPositions;
	public GameObject iguiObj , thugObj;
	public GameObject[] spawnChecks;
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

		spawnChecks = GameObject.FindGameObjectsWithTag("SCheck");

		if(thugObj != null)
		{
			thugScript = thugObj.GetComponent<Thug>();
		}
				
		StartCoroutine("EnemySpawnFalse");
		StartCoroutine("EnemySpawnTimer");
	}
	
	public void EnemySpawn()
	{
		if(randomPos == 0)
		{
			randomPos++;
		}

		if(randomPos == 1)
		{
			spawnLocationX = xPositions[0];
			spawnLocationZ = zPositions[0];
		}
		
		if(randomPos == 2)
		{
			spawnLocationX = xPositions[1];
			spawnLocationZ = zPositions[0];
		}
		
		if(randomPos == 3)
		{
			spawnLocationX = xPositions[2];
			spawnLocationZ = zPositions[1];
		}
		
		if(randomPos == 4)
		{
			spawnLocationX = xPositions[3];
			spawnLocationZ = zPositions[1];
		}

		if(iguiScript != null)
		{
			if(sCheckScript != null && !sCheckScript.spawned && iguiScript.thugCount < iguiScript.maxThugCount)
			{
				//Debug.Log("Enemy Spawner");
				Instantiate (thugObj , new Vector3(spawnLocationX , 0 , spawnLocationZ) , Quaternion.identity);
				iguiScript.thugCount++;
			}
		}
	}

	IEnumerator EnemySpawnFalse()
	{
		yield return new WaitForSeconds(10);

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
