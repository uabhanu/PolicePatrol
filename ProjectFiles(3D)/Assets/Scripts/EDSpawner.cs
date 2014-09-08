using UnityEngine;
using System.Collections;

public class EDSpawner : MonoBehaviour 
{
	float xPosition;
	public Animator openClose;
	public float[] positionValues;
	public GameObject cargoDoorObj , PF_EnergyDrink;
	public int count , i;

	void Start () 
	{
		StartCoroutine("SpawnTimer");
	}

	IEnumerator SpawnTimer()
	{
		yield return new WaitForSeconds(24);

		xPosition = positionValues[i];

		Doors();
		Instantiate();

		StartCoroutine("SpawnTimer");
	}

	public void Doors()
	{
		if(i == 0)
		{
			cargoDoorObj = GameObject.FindGameObjectWithTag("Doors1");
		}
		
		else if(i == 1)
		{
			cargoDoorObj = GameObject.FindGameObjectWithTag("Doors2");
		}
		
		else if(i == 2)
		{
			cargoDoorObj = GameObject.FindGameObjectWithTag("Doors3");
		}
		
		else if(i == 3)
		{
			cargoDoorObj = GameObject.FindGameObjectWithTag("Doors4");
		}
		
		else if(i == 4)
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
		if(count < 1)
		{
			Debug.Log("Energy Drink Ready");
			Instantiate (PF_EnergyDrink , new Vector3(xPosition , 4.6f , 16.0f) , Quaternion.identity);
			openClose.Play(0);

			if(i < 5)
			{
				i++;

				if(i == 5 && count == 0)
				{
					i = 0;
				}
			}
			
			count++;
		}
	}

	void Update () 
	{
	
	}
}
