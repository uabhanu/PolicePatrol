using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour 
{
	public InGameUI iguiScript;
	public GameObject selectionObj;
	public Selection selectionScript;
	public string buttonName , level , relativePath;
	
	void Start () 
	{
		selectionObj = GameObject.FindGameObjectWithTag("Select");

		if(selectionObj != null)
		{
			selectionScript = selectionObj.GetComponent<Selection>();
		}

		//Debug.Log(selectionScript.buttons[0].texture);
		//Debug.Log(selectionScript.buttonTextures[0]);
	}

	void ButtonClick(string buttonName)
	{
		switch(buttonName)
		{
			case "Continue" :
				Application.LoadLevel(0);
			break;

			case "Level1" :
				
				if(selectionScript.buttons[0].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level1");
					Time.timeScale = 1;
				}

			break;

			case "Level2" :

				if(selectionScript.buttons[1].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level2");
					Time.timeScale = 1;
				}

			break;

			case "Level3" :

				if(selectionScript.buttons[2].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level3");
					Time.timeScale = 1;
				}

			break;

			case "Level4" :

				if(selectionScript.buttons[3].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level4");
					Time.timeScale = 1;
				}

			break;

			case "Level5" :

				if(selectionScript.buttons[4].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level5");
					Time.timeScale = 1;
				}

			break;

			case "Level6" :

				if(selectionScript.buttons[5].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level6");
					Time.timeScale = 1;
				}

			break;

			case "Level7" :

				if(selectionScript.buttons[6].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level7");
					Time.timeScale = 1;
				}

			break;

			case "Level8" :

				if(selectionScript.buttons[7].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level8");
					Time.timeScale = 1;
				}

			break;

			case "Level9" :

				if(selectionScript.buttons[8].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level9");
					Time.timeScale = 1;
				}

			break;

			case "Level10" :

				if(selectionScript.buttons[9].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level10");
					Time.timeScale = 1;
				}

			break;

			case "Level11" :

				if(selectionScript.buttons[10].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level11");
					Time.timeScale = 1;
				}

			break;

			case "Level12" :

				if(selectionScript.buttons[11].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level12");
					Time.timeScale = 1;
				}

			break;

			case "Level13" :

				if(selectionScript.buttons[12].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level13");
					Time.timeScale = 1;
				}

			break;

			case "Level14" :

				if(selectionScript.buttons[13].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level14");
					Time.timeScale = 1;
				}

			break;

			case "Level15" :

				if(selectionScript.buttons[14].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level15");
					Time.timeScale = 1;
				}

			break;

			case "Level16" :

				if(selectionScript.buttons[15].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level16");
					Time.timeScale = 1;
				}

			break;

			case "Level17" :

				if(selectionScript.buttons[16].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level17");
					Time.timeScale = 1;
				}

			break;

			case "Level18" :

				if(selectionScript.buttons[17].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level18");
					Time.timeScale = 1;
				}

			break;

			case "Level19" :

				if(selectionScript.buttons[18].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level19");
					Time.timeScale = 1;
				}

			break;

			case "Level20" :

				if(selectionScript.buttons[19].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level20");
					Time.timeScale = 1;
				}

			break;

			case "Level21" :

				if(selectionScript.buttons[20].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level21");
					Time.timeScale = 1;
				}

			break;

			case "Level22" :

				if(selectionScript.buttons[21].GetComponent<GUITexture>().texture == selectionScript.buttonTextures[0])
				{
					Application.LoadLevel("Level22");
					Time.timeScale = 1;
				}

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

			case "Retry" :
				Application.LoadLevel(Application.loadedLevel);
				Time.timeScale = 1;
			break;
		}
	}

	void OnMouseDown()
	{
		if(buttonName == "Continue")
		{
			ButtonClick("Continue");
		}

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

		if(buttonName == "Retry")
		{
			ButtonClick("Retry");
		}
	}

	void Update () 
	{
	
	}	
}
