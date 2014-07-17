using UnityEngine;
using System.Collections;

public class Deselect : MonoBehaviour 
{
	Player playerScript;
	public GameObject playerObj;
	
	void Start () 
	{
		playerObj = GameObject.FindGameObjectWithTag("Player");

		if(playerObj != null)
		{
			playerScript = playerObj.GetComponent<Player>();
		}
	}

	void Update () 
	{
	
	}

	void OnMouseDown()
	{
		playerScript.selected = false;
	}
}
