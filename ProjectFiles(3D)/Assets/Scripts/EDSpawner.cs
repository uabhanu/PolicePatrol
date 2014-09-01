using UnityEngine;
using System.Collections;

public class EDSpawner : MonoBehaviour 
{
	float xPosition;
	public float[] positionValues;
	public GameObject PF_EnergyDrink;
	public int count;

	void Start () 
	{
		StartCoroutine("SpawnTimer");
	}

	IEnumerator SpawnTimer()
	{
		yield return new WaitForSeconds(5);

		xPosition = Random.Range(positionValues[0] , positionValues[4]);

		if(count < 5)
		{
			Debug.Log("Energy Drink Ready");
			Instantiate (PF_EnergyDrink , new Vector3(xPosition , 4.6f , 11.0f) , Quaternion.identity);
			count++;
		}

		StartCoroutine("SpawnTimer");
	}

	void Update () 
	{
	
	}
}
