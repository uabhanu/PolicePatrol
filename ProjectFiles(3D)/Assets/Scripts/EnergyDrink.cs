using UnityEngine;
using System.Collections;

public class EnergyDrink : MonoBehaviour 
{
	public EDSpawner edSpawnScript;
	public GameObject edSpawnObj , playerObj;
	public Player playerScript;

	void Start () 
	{
		edSpawnObj = GameObject.FindGameObjectWithTag("EDSpawn");

		if(edSpawnObj != null)
		{
			edSpawnScript = edSpawnObj.GetComponent<EDSpawner>();
		}

		playerObj = GameObject.FindGameObjectWithTag("Player");

		if(playerObj != null)
		{
			playerScript = playerObj.GetComponent<Player>();
		}

		StartCoroutine("ExistenceTimer");
	}

	IEnumerator ExistenceTimer()
	{
		yield return new WaitForSeconds(10);
		edSpawnScript.count--;

		if(edSpawnScript.count == 0 && edSpawnScript.i == 5)
		{
			edSpawnScript.count = 0;
			edSpawnScript.i = 0;
		}

		Destroy(this.gameObject);
		StartCoroutine("ExistenceTimer");
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
			Debug.Log("Player Collided");
			edSpawnScript.count--;
			Destroy(this.gameObject);
		}
	}

	void OnMouseDown()
	{
		//Debug.Log("Energy Drink Selected");
		
		if(playerScript.currentState != Player.State.Attack)
		{	
			playerScript.target = this.gameObject.transform;
			playerScript.SetState(1);
		}
	}

	void Update () 
	{
		if(Time.timeScale == 0)
		{
			return;
		}

		if(transform.position.z > 10)
		{
			transform.position = new Vector3(transform.position.x , transform.position.y , transform.position.z - 1.0f);
		}
	}
}
