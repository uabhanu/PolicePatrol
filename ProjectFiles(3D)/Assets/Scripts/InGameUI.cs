using UnityEngine;
using System.Collections;

public class InGameUI : MonoBehaviour 
{
	public CircleCollider2D[] buttonColliders;
	public GUIText truckLeftScoreLabel , truckRightScoreLabel;
	public GUITexture[] buttonSprites;
	public int truckLeftScoreValue , truckRightScoreValue;

	void Start () 
	{
		Inactive("QuitButton");
		Inactive("ResumeButton");
	}

	public void Active(string name)
	{
		switch(name)
		{
			case "PauseButton" :
				buttonSprites[0].gameObject.SetActive(true);
				buttonColliders[0].gameObject.SetActive(true);
			break;

			case "QuitButton" :
				buttonSprites[1].gameObject.SetActive(true);
				buttonColliders[1].gameObject.SetActive(true);
			break;

			case "ResumeButton" :
				buttonSprites[2].gameObject.SetActive(true);
				buttonColliders[2].gameObject.SetActive(true);
			break;
		}
	}

	public void Inactive(string name)
	{
		switch(name)
		{
			case "PauseButton" :
				buttonSprites[0].gameObject.SetActive(false);
				buttonColliders[0].gameObject.SetActive(false);
			break;

			case "QuitButton" :
				buttonSprites[1].gameObject.SetActive(false);
				buttonColliders[1].gameObject.SetActive(false);
			break;
			
			case "ResumeButton" :
				buttonSprites[2].gameObject.SetActive(false);
				buttonColliders[2].gameObject.SetActive(false);
			break;
		}
	}

	void Update () 
	{
		if(Time.timeScale == 0)
		{
			return;
		}
		
		truckLeftScoreLabel.text = truckLeftScoreValue.ToString();
		truckRightScoreLabel.text = truckRightScoreValue.ToString();
	}
}
