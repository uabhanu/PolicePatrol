using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour 
{	
	void Start () 
	{

	}

	IEnumerator DestroyTimer()
	{
		yield return new WaitForSeconds(3);
		Destroy(this.gameObject);
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag.Equals("Floor"))
		{
			//Debug.Log("Box on the Floor");
			StartCoroutine("DestroyTimer");
		}
	}

	void Update () 
	{
	
	}
}
