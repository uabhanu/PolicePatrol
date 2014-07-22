using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	Enemy enemyScript;
	//public bool enemyPlaced;
	public GameObject enemyObj;
	public GameObject[] wayPoints;
	public int enemies = 0 , maxEnemies = 4;
	public Vector2[] randomLocations;
	public Vector2 enemySpawnLocation;
	
	void Start () 
	{
		if(enemyObj != null)
		{
			enemyScript = enemyObj.GetComponent<Enemy>();
		}

		randomLocations[0] = new Vector2(-1.3f , 5.0f);
		randomLocations[1] = new Vector2(-1.7f , -5.0f);
		randomLocations[2] = new Vector2(1.75f , -5.0f);
		randomLocations[3] = new Vector2(1.4f , 5.0f);
	
		StartCoroutine("EnemySpawnTimer");
	}

	public void EnemySpawn()
	{
		//enemySpawnLocation = randomLocations[Random.Range(0 , 3)];
		enemySpawnLocation = randomLocations[enemies];
		Instantiate (enemyObj , enemySpawnLocation , Quaternion.identity);
		enemies++;
	}

	IEnumerator EnemySpawnTimer()
	{
		if(enemies < maxEnemies)
		{
			yield return new WaitForSeconds(2);
			EnemySpawn();
			StartCoroutine("EnemySpawnTimer");
		}
	}

	void Update () 
	{

	}
}
