using UnityEngine;
using System.Collections;

public class EDSpawner : MonoBehaviour 
{
	float xPosition;
	public float[] positionValues;
	public GameObject PF_EnergyDrink;
	public int count , i;

	void Start () 
	{
		StartCoroutine("SpawnTimer");
	}

	IEnumerator SpawnTimer()
	{
		yield return new WaitForSeconds(25);

		xPosition = positionValues[i];

		if(count < 1)
		{
			Debug.Log("Energy Drink Ready");
			Instantiate (PF_EnergyDrink , new Vector3(xPosition , 4.6f , 11.0f) , Quaternion.identity);

			if(i < 5)
			{
				i++;
			}

			count++;
		}

		StartCoroutine("SpawnTimer");
	}

	void Update () 
	{
	
	}
}
