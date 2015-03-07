using System.Collections;
using UnityEngine;

public class Collectibles : MonoBehaviour 
{
	void Start () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D col2D)
	{
		if(col2D.gameObject.tag.Equals("Player"))
		{
			Destroy(this.gameObject);
		}
	}

	void Update () 
	{
	
	}
}
