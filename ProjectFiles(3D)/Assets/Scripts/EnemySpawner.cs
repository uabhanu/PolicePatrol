using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	//[HideInInspector]
	public bool enemySpawned;
	public InGameUI iguiScript;
	public float spawnTimer;
	public GameObject iguiObj , thugObj;
	public Thug thugScript;
	
	void Start () 
	{
		iguiObj = GameObject.FindGameObjectWithTag("IGUI");

		if(iguiObj != null)
		{
			iguiScript = iguiObj.GetComponent<InGameUI>();
		}

		if(thugObj != null)
		{
			thugScript = thugObj.GetComponent<Thug>();
		}

		StartCoroutine("EnemySpawnTimer");
	}
	
	public void EnemySpawn()
	{
		if(iguiScript != null)
		{
			if(!enemySpawned && iguiScript.thugCount < iguiScript.maxThugCount)
			{
				if(transform.position.z > 0)
				{
					//Debug.Log("Enemy Spawner");
					Instantiate (thugObj , new Vector3(transform.position.x , transform.position.y , transform.position.z + 10.0f) , Quaternion.identity);
					iguiScript.thugCount++;
				}
				
				else if(transform.position.z < 0)
				{
					//Debug.Log("Enemy Spawner");
					Instantiate (thugObj , new Vector3(transform.position.x , transform.position.y , transform.position.z - 10.0f) , Quaternion.identity);
					iguiScript.thugCount++;
				}
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
