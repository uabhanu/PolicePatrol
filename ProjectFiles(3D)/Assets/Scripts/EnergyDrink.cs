using UnityEngine;
using System.Collections;

public class EnergyDrink : MonoBehaviour 
{
	public EDSpawner edSpawnScript;
	public GameObject edSpawnObj , policeObj;
	public Police policeScript;

	void Start () 
	{
		edSpawnObj = GameObject.FindGameObjectWithTag("EDSpawn");

		if(edSpawnObj != null)
		{
			edSpawnScript = edSpawnObj.GetComponent<EDSpawner>();
		}

		policeObj = GameObject.FindGameObjectWithTag("Player");

		if(policeObj != null)
		{
			policeScript = policeObj.GetComponent<Police>();
		}

		StartCoroutine("ExistenceTimer");
	}

	IEnumerator ExistenceTimer()
	{
		yield return new WaitForSeconds(10);
		edSpawnScript.count--;
		Destroy(this.gameObject);
		StartCoroutine("ExistenceTimer");
	}

	void OnMouseDown()
	{
		//Debug.Log("Energy Drink Selected");
		
		if(policeScript.currentState != Police.State.Attack)
		{	
			policeScript.target = this.gameObject.transform;
			policeScript.SetState(1);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
			Debug.Log("Player Collided");
			edSpawnScript.count--;
			Destroy(this.gameObject);
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
