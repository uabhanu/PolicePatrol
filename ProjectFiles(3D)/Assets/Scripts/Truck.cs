using UnityEngine;
using System.Collections;

public class Truck : MonoBehaviour 
{
	public GameObject iguiObj;
	public InGameUI iguiScript;
	
	void Start () 
	{
		iguiObj = GameObject.FindGameObjectWithTag("IGUI");

		if(iguiObj != null)
		{
			iguiScript = iguiObj.GetComponent<InGameUI>();
		}
	}

	void Update () 
	{
		if(this.gameObject.tag.Equals("Left") && iguiScript.truckLeftScoreValue == 5)
		{
			transform.position = new Vector3(transform.position.x - 1.5f , transform.position.y , transform.position.z);

			if(transform.position.x < -105.0f)
			{
				Destroy(this.gameObject);
			}
		}

		if(this.gameObject.tag.Equals("Right") && iguiScript.truckRightScoreValue == 5)
		{
			transform.position = new Vector3(transform.position.x + 1.5f , transform.position.y , transform.position.z);

			if(transform.position.x > 85.0f)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
