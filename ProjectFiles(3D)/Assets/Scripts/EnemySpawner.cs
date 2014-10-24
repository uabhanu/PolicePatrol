using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	//[HideInInspector]
	public InGameUI iguiScript;
	public float firstEnemyTime , spawnTimer , spawnLocationX , spawnLocationZ;
	public float[] xPositions , zPositions;
	public GameObject iguiObj , thugObj;
	public int randomPos;
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
				
		StartCoroutine("EnemySpawnTimer");
		StartCoroutine("FirstEnemySpawnTimer");
		StartCoroutine("RandomSpawnTimer");
	}

	IEnumerator EnemySpawnTimer()
	{
		yield return new WaitForSeconds(spawnTimer);
		EnemySpawn();
		StartCoroutine("EnemySpawnTimer");
	}

	IEnumerator FirstEnemySpawnTimer()
	{
		yield return new WaitForSeconds(firstEnemyTime);

		if(randomPos == 0)
		{
			spawnLocationX = xPositions[0];
			spawnLocationZ = zPositions[0];
		}
		
		if(randomPos == 1)
		{
			spawnLocationX = xPositions[0];
			spawnLocationZ = zPositions[1];
		}
		
		if(randomPos == 2)
		{
			spawnLocationX = xPositions[1];
			spawnLocationZ = zPositions[0];
		}
		
		if(randomPos == 3)
		{
			spawnLocationX = xPositions[1];
			spawnLocationZ = zPositions[1];
		}
		
		if(randomPos == 4)
		{
			spawnLocationX = xPositions[2];
			spawnLocationZ = zPositions[0];
		}
		
		if(randomPos == 5)
		{
			spawnLocationX = xPositions[2];
			spawnLocationZ = zPositions[1];
		}
		
		if(randomPos == 6)
		{
			spawnLocationX = xPositions[3];
			spawnLocationZ = zPositions[0];
		}
		
		if(randomPos == 7)
		{
			spawnLocationX = xPositions[3];
			spawnLocationZ = zPositions[1];
		}
		
		//Debug.Log("Enemy Spawner");
		Instantiate (thugObj , new Vector3(spawnLocationX , 0 , spawnLocationZ) , Quaternion.identity);
		iguiScript.thugCount++;
	}

	IEnumerator RandomSpawnTimer()
	{
		yield return new WaitForSeconds(1);
		randomPos = (int)Random.Range(0 , 8);
		StartCoroutine("RandomSpawnTimer");
	}
	
	public void EnemySpawn()
	{
		if(randomPos == 0)
		{
			spawnLocationX = xPositions[0];
			spawnLocationZ = zPositions[0];
		}
		
		if(randomPos == 1)
		{
			spawnLocationX = xPositions[0];
			spawnLocationZ = zPositions[1];
		}
		
		if(randomPos == 2)
		{
			spawnLocationX = xPositions[1];
			spawnLocationZ = zPositions[0];
		}
		
		if(randomPos == 3)
		{
			spawnLocationX = xPositions[1];
			spawnLocationZ = zPositions[1];
		}

		if(randomPos == 4)
		{
			spawnLocationX = xPositions[2];
			spawnLocationZ = zPositions[0];
		}

		if(randomPos == 5)
		{
			spawnLocationX = xPositions[2];
			spawnLocationZ = zPositions[1];
		}

		if(randomPos == 6)
		{
			spawnLocationX = xPositions[3];
			spawnLocationZ = zPositions[0];
		}

		if(randomPos == 7)
		{
			spawnLocationX = xPositions[3];
			spawnLocationZ = zPositions[1];
		}

		if(iguiScript != null)
		{
			if(iguiScript.thugCount < iguiScript.maxThugCount)
			{
				//Debug.Log("Enemy Spawner");
				Instantiate (thugObj , new Vector3(spawnLocationX , 0 , spawnLocationZ) , Quaternion.identity);
				iguiScript.thugCount++;
			}
		}
	}

	void Update () 
	{

	}
}
