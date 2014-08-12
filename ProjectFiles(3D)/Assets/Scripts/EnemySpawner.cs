using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	//[HideInInspector]
	public Enemy enemyScript;
	public float spawnTimer;
	public GameObject enemyObj;
	
	void Start () 
	{
		if(enemyObj != null)
		{
			enemyScript = enemyObj.GetComponent<Enemy>();
		}

		StartCoroutine("EnemySpawnTimer");
	}
	
	public void EnemySpawn()
	{
		Debug.Log("Enemy Spawner");
		Instantiate (enemyObj , transform.position , Quaternion.identity);
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
