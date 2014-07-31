using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour 
{
	public GameObject playerObj;
	
	void Start () 
	{
		Instantiate(playerObj , new Vector3 (0 , 1.1f , 0) , Quaternion.identity);
	}

	void Update () 
	{
	
	}
}
