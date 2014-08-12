using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	//[HideInInspector]
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
		if(sAgentScript.enemies < sAgentScript.maxEnemies)
		{
			Debug.Log("Enemy Spawner");
			Instantiate (enemyObj , transform.position , Quaternion.identity);
			sAgentScript.enemies++;
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
