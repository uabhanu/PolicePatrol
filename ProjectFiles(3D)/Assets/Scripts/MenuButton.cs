using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour 
{
	public InGameUI iguiScript;
	public GameObject iguiObj;
	public string buttonName , level , relativePath;
	
	void Start () 
	{

	}

	void ButtonClick(string buttonName)
	{
		switch(buttonName)
		{
			case "Level1" :
				Application.LoadLevel("Level1");
			break;

			case "Level2" :
				Application.LoadLevel("Level2");
			break;

			case "Level3" :
				Application.LoadLevel("Level3");
			break;

			case "Level4" :
				Application.LoadLevel("Level4");
			break;

			case "Level5" :
				Application.LoadLevel("Level5");
			break;

			case "Level6" :
				Application.LoadLevel("Level6");
			break;

			case "Level7" :
				Application.LoadLevel("Level7");
			break;

			case "Level8" :
				Application.LoadLevel("Level8");
			break;

			case "Level9" :
				Application.LoadLevel("Level9");
			break;

			case "Level10" :
				Application.LoadLevel("Level10");
			break;

			case "Level11" :
				Application.LoadLevel("Level11");
			break;

			case "Level12" :
				Application.LoadLevel("Level12");
			break;

			case "Level13" :
				Application.LoadLevel("Level13");
			break;

			case "Level14" :
				Application.LoadLevel("Level14");
			break;

			case "Level15" :
				Application.LoadLevel("Level15");
			break;

			case "Level16" :
				Application.LoadLevel("Level16");
			break;

			case "Level17" :
				Application.LoadLevel("Level17");
			break;

			case "Level18" :
				Application.LoadLevel("Level18");
			break;

			case "Level19" :
				Application.LoadLevel("Level19");
			break;

			case "Level20" :
				Application.LoadLevel("Level20");
			break;

			case "Level21" :
				Application.LoadLevel("Level21");
			break;

			case "Level22" :
				Application.LoadLevel("Level22");
			break;

			case "Pause" :
				Debug.Log("PauseButton");
				Time.timeScale = 0;
				iguiScript.Inactive("PauseButton");
				iguiScript.Active("QuitButton");
				iguiScript.Active("ResumeButton");
			break;

			case "Quit" :
				Debug.Log("QuitButton");
				Application.Quit();
			break;
				
			case "Resume" :
				Debug.Log("ResumeButton");	
				Time.timeScale = 1;
				iguiScript.Active("PauseButton");
				iguiScript.Inactive("QuitButton");
				iguiScript.Inactive("ResumeButton");
			break;
		}
	}

	void OnMouseDown()
	{
		if(buttonName == "Level1")
		{
			ButtonClick("Level1");
		}

		if(buttonName == "Level2")
		{
			ButtonClick("Level2");
		}

		if(buttonName == "Level3")
		{
			ButtonClick("Level3");
		}

		if(buttonName == "Level4")
		{
			ButtonClick("Level4");
		}

		if(buttonName == "Level5")
		{
			ButtonClick("Level5");
		}

		if(buttonName == "Level6")
		{
			ButtonClick("Level6");
		}

		if(buttonName == "Level7")
		{
			ButtonClick("Level7");
		}

		if(buttonName == "Level8")
		{
			ButtonClick("Level8");
		}

		if(buttonName == "Level9")
		{
			ButtonClick("Level9");
		}

		if(buttonName == "Level10")
		{
			ButtonClick("Level10");
		}

		if(buttonName == "Level11")
		{
			ButtonClick("Level11");
		}

		if(buttonName == "Level12")
		{
			ButtonClick("Level12");
		}

		if(buttonName == "Level13")
		{
			ButtonClick("Level13");
		}

		if(buttonName == "Level14")
		{
			ButtonClick("Level14");
		}

		if(buttonName == "Level15")
		{
			ButtonClick("Level15");
		}

		if(buttonName == "Level16")
		{
			ButtonClick("Level16");
		}

		if(buttonName == "Level17")
		{
			ButtonClick("Level17");
		}

		if(buttonName == "Level18")
		{
			ButtonClick("Level18");
		}

		if(buttonName == "Level19")
		{
			ButtonClick("Level19");
		}

		if(buttonName == "Level20")
		{
			ButtonClick("Level20");
		}

		if(buttonName == "Level21")
		{
			ButtonClick("Level21");
		}

		if(buttonName == "Level22")
		{
			ButtonClick("Level22");
		}

		if(buttonName == "Pause")
		{
			ButtonClick("Pause");
		}

		if(buttonName == "Quit")
		{
			ButtonClick("Quit");
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
