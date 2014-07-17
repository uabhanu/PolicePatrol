using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public bool selected;
	public float speed;
	
	void Start () 
	{
	
	}

	void Update () 
	{

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag.Equals("Enemy"))
		{
			Debug.Log("Collided");
		}
	}

	void OnMouseDown()
	{
		Debug.Log("Player Selected");
		selected = true;
	}
}
