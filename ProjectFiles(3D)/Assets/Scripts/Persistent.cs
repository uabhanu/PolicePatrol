using UnityEngine;
using System.Collections;

public class Persistent : MonoBehaviour 
{
	public GameObject selectionObj , splashObj;
	public Selection selectionScript;
	public Texture[] buttonTextures;
	
	void Awake () 
	{
		DontDestroyOnLoad(transform.gameObject);

		selectionObj = GameObject.FindGameObjectWithTag("Select");

		if(selectionObj != null)
		{
			selectionScript = selectionObj.GetComponent<Selection>();
		}

		buttonTextures[0] = selectionScript.buttonTextures[0];
		buttonTextures[1] = selectionScript.buttonTextures[1];

		splashObj = GameObject.FindGameObjectWithTag("Splash");
	}

	void Update () 
	{
	
	}
}
