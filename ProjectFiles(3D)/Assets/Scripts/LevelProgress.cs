﻿using UnityEngine;
using System.Collections;

public class LevelProgress : MonoBehaviour 
{
	public GameObject iguiObj , truckLeftObj , truckRightObj;
	public InGameUI iguiScript;
	public int leftScore , levelNo , levelProgress , rightScore;
	
	void Start () 
	{
		DontDestroyOnLoad(this.gameObject);
		StartCoroutine("GameTimer");

		PlayerPrefs.GetInt("levelProgress");
	}

	IEnumerator GameTimer()
	{
		yield return new WaitForSeconds(0.4f);
		
		if(iguiObj == null)
		{
			iguiObj = GameObject.FindGameObjectWithTag("IGUI");
		}

		if(truckLeftObj == null)
		{
			truckLeftObj = GameObject.FindGameObjectWithTag("Left");
		}

		if(truckRightObj == null)
		{
			truckRightObj = GameObject.FindGameObjectWithTag("Right");
		}
		
		if(iguiObj != null)
		{
			iguiScript = iguiObj.GetComponent<InGameUI>();

			if(truckLeftObj != null)
			{
				leftScore = iguiScript.truckLeftScoreValue;
			}

			if(truckRightObj != null)
			{
				rightScore = iguiScript.truckRightScoreValue;
			}

			if(iguiScript != null)
			{
				levelNo = iguiScript.levelNo;

				if(iguiScript.timeValue > 0) //This part works only if game started from Level Selection Screen which is correct
				{
					if(leftScore == 5 && truckLeftObj == null || rightScore == 5 && truckRightObj == null)
					{
						Debug.Log("Truck 5/5");
						iguiScript.Active("LoseCard");
						iguiScript.Active("LoseCardText");
						iguiScript.Inactive("PauseButton");
						iguiScript.Active("RetryButton");
						Time.timeScale = 0;
					}
				}
				
				else if(iguiScript.timeValue == 0)
				{
					Debug.Log("Back up arrived on Time");
					iguiScript.Active("WinCard");
					iguiScript.Active("WinCardText");
					iguiScript.Inactive("PauseButton");
					iguiScript.Active("ContinueButton");
					Time.timeScale = 0;
					levelProgress++;
					PlayerPrefs.SetInt("levelProgress" , 1);
				}
			}
		}
		
		StartCoroutine("GameTimer");
	}

	void Update () 
	{
	
	}
}
