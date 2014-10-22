using System.Collections;
using UnityEngine;

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
