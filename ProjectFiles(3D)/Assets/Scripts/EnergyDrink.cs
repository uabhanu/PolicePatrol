using UnityEngine;
using System.Collections;

public class EnergyDrink : MonoBehaviour 
{
	public EDSpawner edSpawnScript;
	public GameObject edSpawnObj;

	void Start () 
	{
		edSpawnObj = GameObject.FindGameObjectWithTag("EDSpawn");

		if(edSpawnObj != null)
		{
			edSpawnScript = edSpawnObj.GetComponent<EDSpawner>();
		}

		StartCoroutine("ExistenceTimer");
	}

	IEnumerator ExistenceTimer()
	{
		yield return new WaitForSeconds(3);
		edSpawnScript.count--;

		if(edSpawnScript.count == 0 && edSpawnScript.i == 5)
		{
			edSpawnScript.count = 0;
			edSpawnScript.i = 0;
		}

		Destroy(this.gameObject);
		StartCoroutine("ExistenceTimer");
	}

	void Update () 
	{
	
	}
}
