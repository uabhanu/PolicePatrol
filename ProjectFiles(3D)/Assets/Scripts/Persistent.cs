using UnityEngine;
using System.Collections;

public class Persistent : MonoBehaviour 
{
	public bool levelProgress;
	public GameObject iguiObj , selectionObj , splashObj;
	public InGameUI iguiScript;
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

		StartCoroutine("GameTimer");
	}

	IEnumerator GameTimer()
	{
		yield return new WaitForSeconds(0.4f);

		if(iguiObj == null)
		{
			iguiObj = GameObject.FindGameObjectWithTag("IGUI");
		}

		if(iguiObj != null)
		{
			iguiScript = iguiObj.GetComponent<InGameUI>();

			if(iguiScript.timeValue > 0 && iguiScript.truckLeftScoreValue == 5 && iguiScript.truckRightScoreValue == 5)
			{
				iguiScript.Active("LoseCard");
				iguiScript.Active("LoseCardText");
				Time.timeScale = 0;
			}

			else if(iguiScript.timeValue == 0)
			{
				iguiScript.Active("WinCard");
				iguiScript.Active("WinCardText");
				Time.timeScale = 0;
				iguiScript.levelCompleted = true;
				levelProgress = iguiScript.levelCompleted;
			}
		}

		StartCoroutine("GameTimer");
	}

	void Update () 
	{
		
	}
}
