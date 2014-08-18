using UnityEngine;
using System.Collections;

public class InGameUI : MonoBehaviour 
{
	public bool levelCompleted;
	public GameObject[] tempObjs;
	public GUIText timeLabel , timeDisplayLabel , truckLeftScoreLabel , truckLeftScoreDisplayLabel , truckRightScoreLabel , truckRightScoreDisplayLabel;
	public GUITexture[] buttonSprites;
	public int timeValue , truckLeftScoreValue , truckRightScoreValue;

	void Awake()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 30;
	}

	void Start () 
	{
		Inactive("LoseCard");
		Inactive("LoseCardText");
		Inactive("QuitButton");
		Inactive("ResumeButton");
		Inactive("WinCard");
		Inactive("WinCardText");

		StartCoroutine("GameTimer");
	}

	IEnumerator GameTimer()
	{
		yield return new WaitForSeconds(1);

		if(timeValue > 0)
		{
			timeValue--;
		}

		timeLabel.text = timeValue.ToString();

		if(timeValue <= 5)
		{
			timeLabel.color = Color.green;
			timeDisplayLabel.color = Color.green;
		}
		
		truckLeftScoreLabel.text = truckLeftScoreValue.ToString();
		truckRightScoreLabel.text = truckRightScoreValue.ToString();

		if(truckLeftScoreValue > 3)
		{
			truckLeftScoreLabel.color = Color.red;
			truckLeftScoreDisplayLabel.color = Color.red;
		}

		if(truckRightScoreValue > 3)
		{
			truckRightScoreLabel.color = Color.red;
			truckRightScoreDisplayLabel.color = Color.red;
		}

		StartCoroutine("GameTimer");
	}

	public void Active(string name)
	{
		switch(name)
		{
			case "LoseCard" :
				tempObjs[0].gameObject.SetActive(true);
			break;

			case "LoseCardText" :
				tempObjs[1].gameObject.SetActive(true);
			break;

			case "PauseButton" :
				buttonSprites[0].gameObject.SetActive(true);
			break;

			case "QuitButton" :
				buttonSprites[1].gameObject.SetActive(true);
			break;

			case "ResumeButton" :
				buttonSprites[2].gameObject.SetActive(true);
			break;

			case "WinCard" :
				tempObjs[2].gameObject.SetActive(true);
			break;

			case "WinCardText" :
				tempObjs[3].gameObject.SetActive(true);
			break;
		}
	}

	public void Inactive(string name)
	{
		switch(name)
		{
			case "LoseCard" :
				tempObjs[0].gameObject.SetActive(false);
			break;
			
			case "LoseCardText" :
				tempObjs[1].gameObject.SetActive(false);
			break;

			case "PauseButton" :
				buttonSprites[0].gameObject.SetActive(false);
			break;

			case "QuitButton" :
				buttonSprites[1].gameObject.SetActive(false);
			break;
			
			case "ResumeButton" :
				buttonSprites[2].gameObject.SetActive(false);
			break;

			case "WinCard" :
				tempObjs[2].gameObject.SetActive(false);
			break;
			
			case "WinCardText" :
				tempObjs[3].gameObject.SetActive(false);
			break;
		}
	}

	void Update () 
	{

	}
}
