using UnityEngine;
using System.Collections;

public class EDSpawner : MonoBehaviour 
{
	float xPosition;
	public Animator openClose;
	public float[] positionValues;
	public GameObject cargoDoorObj , PF_EnergyDrink;

	void Start () 
	{
		StartCoroutine("SpawnTimer");
	}

	IEnumerator SpawnTimer()
	{
		yield return new WaitForSeconds(24);

		if((int)Random.Range(1 , 5) == 1)
		{
			xPosition = positionValues[0];
			cargoDoorObj = GameObject.FindGameObjectWithTag("Doors1");
		}

		if((int)Random.Range(1 , 5) == 2)
		{
			xPosition = positionValues[1];
			cargoDoorObj = GameObject.FindGameObjectWithTag("Doors2");
		}

		if((int)Random.Range(1 , 5) == 3)
		{
			xPosition = positionValues[2];
			cargoDoorObj = GameObject.FindGameObjectWithTag("Doors3");
		}

		if((int)Random.Range(1 , 5) == 4)
		{
			xPosition = positionValues[3];
			cargoDoorObj = GameObject.FindGameObjectWithTag("Doors4");
		}

		if((int)Random.Range(1 , 5) == 5)
		{
			xPosition = positionValues[4];
			cargoDoorObj = GameObject.FindGameObjectWithTag("Doors5");
		}

		if(cargoDoorObj != null)
		{
			openClose = cargoDoorObj.GetComponent<Animator>();
		}

		openClose.Play(0);
		Instantiate();
		StartCoroutine("SpawnTimer");
	}

	public void Instantiate()
	{
		Debug.Log("Energy Drink Ready");
		Instantiate(PF_EnergyDrink , new Vector3(xPosition , 4.6f , 16.0f) , Quaternion.identity);
	}

	void Update () 
	{
	
	}
}
