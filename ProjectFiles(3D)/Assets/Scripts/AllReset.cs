using UnityEngine;
using System.Collections;

public class AllReset : MonoBehaviour 
{
	
	void Start () 
	{
		PlayerPrefs.DeleteAll();
	}

	void Update () 
	{
	
	}
}
