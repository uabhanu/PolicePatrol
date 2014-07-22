using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	Enemy enemyScript;
	public GameObject enemyObj;
	public GameObject[] wayPoints;
	public int enemies = 0;
	public int maxEnemies = 5;
	//public Vector2 spawnLocation;
	
	void Start () 
	{
		if(enemyObj != null)
		{
			enemyScript = enemyObj.GetComponent<Enemy>();
		}


		StartCoroutine("EnemySpawnTimer");

		//wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
		//spawnLocation = Random.Range (0 , wayPoints.Length - 1);
	}

	public void EnemySpawn()
	{
		Instantiate (enemyObj , transform.position , Quaternion.identity);
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
