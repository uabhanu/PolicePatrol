using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	Enemy enemyScript;
	//public bool enemyPlaced;
	public GameObject enemyObj;
	public GameObject[] wayPoints;
	public int enemies , i , maxEnemies;
	public Vector2[] randomLocations;
	Vector2 enemySpawnLocation;
	
	void Start () 
	{
		if(enemyObj != null)
		{
			enemyScript = enemyObj.GetComponent<Enemy>();
		}

		i = enemies;

		randomLocations[0] = new Vector2(-2.3f , -4.2f);
		randomLocations[1] = new Vector2(-4.2f , 4.2f);
		randomLocations[2] = new Vector2(1.4f , 4.2f);
		randomLocations[3] = new Vector2(1.7f , -4.2f);
		randomLocations[4] = new Vector2(-1.7f , 4.2f);
		randomLocations[5] = new Vector2(-5.2f , -4.2f);
		randomLocations[6] = new Vector2(4.2f , 4.2f);
		randomLocations[7] = new Vector2(5.2f , -4.2f);

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
