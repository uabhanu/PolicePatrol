using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour 
{
	public InGameUI iguiScript;
	public GameObject iguiObj;
	public string buttonName , level , relativePath;
	
	void Start () 
	{
		Time.timeScale = 1;
	}

	void ButtonClick(string buttonName)
	{
		switch(buttonName)
		{
			case "Pause" :
				Time.timeScale = 0;
				iguiScript.Inactive("PauseButton");
				iguiScript.Active("QuitButton");
				iguiScript.Active("ResumeButton");
			break;
				
			case "Resume" :
				Time.timeScale = 1;
				iguiScript.Active("PauseButton");
				iguiScript.Inactive("QuitButton");
				iguiScript.Inactive("ResumeButton");
			break;
		}
	}

	void OnMouseDown()
	{
		if(buttonName == "Pause")
		{
			ButtonClick("Pause");
		}

		if(buttonName == "Resume")
		{
			ButtonClick("Resume");
		}
	}

	void Update () 
	{
	
	}	
}
