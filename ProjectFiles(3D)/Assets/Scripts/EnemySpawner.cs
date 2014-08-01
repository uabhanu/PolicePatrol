using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	//[HideInInspector]
	public GameObject enemyObj;
	public int enemies , i , maxEnemies;
	public Vector3[] randomLocations;
	
	void Start () 
	{	
		i = enemies;
		
		randomLocations[0] = new Vector3(-32.0f , 2 , 37.0f);
		randomLocations[1] = new Vector3(-11.0f , 2 , 37.0f);
		randomLocations[2] = new Vector3(11.0f , 2 , 37.0f);
		randomLocations[3] = new Vector3(31.0f , 2 , 37.0f);
		randomLocations[4] = new Vector3(-38.0f , 2 , -24.0f);
		randomLocations[5] = new Vector3(-13.0f , 2 , -24.0f);
		randomLocations[6] = new Vector3(13.0f , 2 , -24.0f);
		randomLocations[7] = new Vector3(38.0f , 2 , -24.0f);
		
		StartCoroutine("EnemySpawnTimer");
		StartCoroutine("SpawnLocationTimer");
	}
	
	public void EnemySpawn()
	{
		Instantiate (enemyObj , randomLocations[i] , Quaternion.identity);
		enemies++;
		i++;
	}
	
	IEnumerator EnemySpawnTimer()
	{
		if(enemies < maxEnemies)
		{
			yield return new WaitForSeconds(4);
			EnemySpawn();
			StartCoroutine("EnemySpawnTimer");
		}
	}
	
	IEnumerator SpawnLocationTimer()
	{
		yield return new WaitForSeconds(32);
		i = 0;
		StartCoroutine("SpawnLocationTimer");
	}

	void Update () 
	{
	
	}
}
