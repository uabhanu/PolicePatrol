using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	//[HideInInspector]
	public bool enemySpawned;
	public Enemy enemyScript;
	public float spawnTimer;
	public GameObject enemyObj , sAgentObj;
	public SpawnerAgent sAgentScript;
	
	void Start () 
	{
		if(enemyObj != null)
		{
			enemyScript = enemyObj.GetComponent<Enemy>();
		}

		sAgentScript = sAgentObj.GetComponent<SpawnerAgent>();

		StartCoroutine("EnemySpawnTimer");
	}
	
	public void EnemySpawn()
	{
		if(!enemySpawned && sAgentScript.enemies < sAgentScript.maxEnemies)
		{
			if(transform.position.z > 0)
			{
				Debug.Log("Enemy Spawner");
				Instantiate (enemyObj , new Vector3(transform.position.x , transform.position.y , transform.position.z + 10.0f) , Quaternion.identity);
				sAgentScript.enemies++;
			}

			else if(transform.position.z < 0)
			{
				Debug.Log("Enemy Spawner");
				Instantiate (enemyObj , new Vector3(transform.position.x , transform.position.y , transform.position.z - 10.0f) , Quaternion.identity);
				sAgentScript.enemies++;
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag.Equals("Enemy") || col.gameObject.tag.Equals("Target"))
		{
			enemySpawned = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag.Equals("Enemy") || col.gameObject.tag.Equals("Target"))
		{
			enemySpawned = false;
		}
	}
	
	IEnumerator EnemySpawnTimer()
	{
		yield return new WaitForSeconds(spawnTimer);
		EnemySpawn();
		StartCoroutine("EnemySpawnTimer");
	}

	void Update () 
	{

	}
}
