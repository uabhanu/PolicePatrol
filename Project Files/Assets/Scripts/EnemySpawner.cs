using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	Enemy enemyScript;
	//public bool enemyPlaced;
	public GameObject enemyObj;
	public GameObject[] wayPoints;
	public int enemies , maxEnemies;
	public Vector2[] randomLocations;
	Vector2 enemySpawnLocation;
	
	void Start () 
	{
		if(enemyObj != null)
		{
			enemyScript = enemyObj.GetComponent<Enemy>();
		}

		randomLocations[0] = new Vector2(-1.4f , 4.2f);
		randomLocations[1] = new Vector2(-1.7f , -5.0f);
		randomLocations[2] = new Vector2(1.75f , -5.0f);
		randomLocations[3] = new Vector2(1.4f , 4.2f);
		randomLocations[4] = new Vector2(1.4f , 4.2f);
		randomLocations[5] = new Vector2(1.4f , 4.2f);
		randomLocations[6] = new Vector2(1.4f , 4.2f);
		randomLocations[7] = new Vector2(1.4f , 4.2f);
	
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
