using UnityEngine;
using System.Collections;

public class LevelProgress : MonoBehaviour 
{
	public GameObject iguiObj , truckLeftObj , truckRightObj;
	public InGameUI iguiScript;
	public int leftScore , levelNo , level1Progress , level2Progress , level3Progress , rightScore;
	
	void Start () 
	{
		DontDestroyOnLoad(this.gameObject);

		level1Progress = PlayerPrefs.GetInt("level1Progress");
		level2Progress = PlayerPrefs.GetInt("level2Progress");
		level3Progress = PlayerPrefs.GetInt("level3Progress");

		StartCoroutine("GameTimer");
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

					if(levelNo == 1 && level1Progress < 1)
					{
						level1Progress++;
						PlayerPrefs.SetInt("level1Progress" , level1Progress);
					}

					if(levelNo == 2 && level2Progress < 1)
					{
						level2Progress++;
						PlayerPrefs.SetInt("level2Progress" , level2Progress);
					}

					if(levelNo == 3 && level3Progress < 1)
					{
						level3Progress++;
						PlayerPrefs.SetInt("level3Progress" , level3Progress);
					}
				}
			}
		}

		PlayerPrefs.GetInt("levelProgress");
		
		StartCoroutine("GameTimer");
	}

	void Update () 
	{
	
	}
}
