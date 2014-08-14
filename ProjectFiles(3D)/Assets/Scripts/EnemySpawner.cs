using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	//[HideInInspector]
	public Enemy enemyScript;
	public EnemySpawnCheck escScript;
	public float spawnTimer;
	public GameObject enemyObj , escObj , sAgentObj;
	public SpawnerAgent sAgentScript;
	
	void Start () 
	{
		if(enemyObj != null)
		{
			enemyScript = enemyObj.GetComponent<Enemy>();
		}

		escObj = GameObject.FindGameObjectWithTag("SCheck");

		if(escObj != null)
		{
			escScript = escObj.GetComponent<EnemySpawnCheck>();
		}

		sAgentScript = sAgentObj.GetComponent<SpawnerAgent>();

		StartCoroutine("EnemySpawnTimer");
	}
	
	public void EnemySpawn()
	{
		if(!escScript.enemySpawned && sAgentScript.enemies < sAgentScript.maxEnemies)
		{
			//Debug.Log("Enemy Spawner");
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
