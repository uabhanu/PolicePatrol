using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	//[HideInInspector]
	public bool firstEnemy;
	public GameObject enemyObj;
	public int enemies , i , maxEnemies;
	public Vector3[] randomLocations;
	
	void Start () 
	{	
		i = enemies;
		
		randomLocations[0] = new Vector3(-34.0f , 2 , 39.0f);
		randomLocations[1] = new Vector3(-14.0f , 2 , 39.0f);
		randomLocations[2] = new Vector3(6.0f , 2 , 39.0f);
		randomLocations[3] = new Vector3(27.0f , 2 , 39.0f);
		randomLocations[4] = new Vector3(-34.0f , 2 , -36.0f);
		randomLocations[5] = new Vector3(-14.0f , 2 , -36.0f);
		randomLocations[6] = new Vector3(6.0f , 2 , -36.0f);
		randomLocations[7] = new Vector3(26.0f , 2 , -36.0f);
		
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

			yield return new WaitForSeconds(1);

			if(!firstEnemy)
			{
				Debug.Log("1st enemy spawned");
				Time.timeScale = 0;
				firstEnemy = true;
			}

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
