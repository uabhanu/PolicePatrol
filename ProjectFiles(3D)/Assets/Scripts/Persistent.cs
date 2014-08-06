using UnityEngine;
using System.Collections;

public class Persistent : MonoBehaviour 
{
	public GameObject splashObj;
	
	void Awake () 
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 30;
		DontDestroyOnLoad(transform.gameObject);
		splashObj = GameObject.FindGameObjectWithTag("Splash");
	}

	void Update () 
	{
	
	}
}
