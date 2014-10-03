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

		xPosition = positionValues[(int)Random.Range(1 , 5)];

		Doors();
		Instantiate();

		StartCoroutine("SpawnTimer");
	}

	public void Doors()
	{
		if((int)Random.Range(1 , 5) == 1)
		{
			cargoDoorObj = GameObject.FindGameObjectWithTag("Doors1");
		}
		
		else if((int)Random.Range(1 , 5) == 2)
		{
			cargoDoorObj = GameObject.FindGameObjectWithTag("Doors2");
		}
		
		else if((int)Random.Range(1 , 5) == 3)
		{
			cargoDoorObj = GameObject.FindGameObjectWithTag("Doors3");
		}
		
		else if((int)Random.Range(1 , 5) == 4)
		{
			cargoDoorObj = GameObject.FindGameObjectWithTag("Doors4");
		}
		
		else if((int)Random.Range(1 , 5) == 5)
		{
			cargoDoorObj = GameObject.FindGameObjectWithTag("Doors5");
		}
		
		
		if(cargoDoorObj != null)
		{
			openClose = cargoDoorObj.GetComponent<Animator>();
		}
	}

	public void Instantiate()
	{
		Debug.Log("Energy Drink Ready");
		Instantiate (PF_EnergyDrink , new Vector3(xPosition , 4.6f , 16.0f) , Quaternion.identity);
		openClose.Play(0);
	}

	void Update () 
	{
	
	}
}
