using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	public float speed;
	
	void Start () 
	{
	
	}

	void Update () 
	{
		transform.Translate(speed , 0 , 0);	
	}
}
