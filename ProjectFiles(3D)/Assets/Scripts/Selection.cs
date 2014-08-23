using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour 
{
	public bool levelProgress;
	public GameObject iguiObj , progressObj;
	public GUITexture[] buttons;
	public InGameUI iguiScript;
	public LevelProgress progressScript;
	public Texture[] buttonTextures;
	
	void Start () 
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 30;

		Unlock("Level1");

		Lock("Level2");
		Lock("Level3");
		Lock("Level4");
		Lock("Level5");
		Lock("Level6");
		Lock("Level7");
		Lock("Level8");
		Lock("Level9");
		Lock("Level10");
		Lock("Level11");
		Lock("Level12");
		Lock("Level13");
		Lock("Level14");
		Lock("Level15");
		Lock("Level16");
		Lock("Level17");
		Lock("Level18");
		Lock("Level19");
		Lock("Level20");
		Lock("Level21");
		Lock("Level22");

		progressObj = GameObject.FindGameObjectWithTag("Progress");

		if(progressObj != null)
		{
			progressScript = progressObj.GetComponent<LevelProgress>();
		}

		if(progressScript.levelProgress)
		{
			if(buttons[1].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level2");
				progressScript.levelProgress = false;
			}

			else if(buttons[2].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level3");
				progressScript.levelProgress = false;
			}

			else if(buttons[3].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level4");
				progressScript.levelProgress = false;
			}

			else if(buttons[4].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level5");
				progressScript.levelProgress = false;
			}

			else if(buttons[5].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level6");
				progressScript.levelProgress = false;
			}

			else if(buttons[6].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level7");
				progressScript.levelProgress = false;
			}

			else if(buttons[7].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level8");
				progressScript.levelProgress = false;
			}

			else if(buttons[8].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level9");
				progressScript.levelProgress = false;
			}

			else if(buttons[9].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level10");
				progressScript.levelProgress = false;
			}

			else if(buttons[10].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level11");
				progressScript.levelProgress = false;
			}

			else if(buttons[11].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level12");
				progressScript.levelProgress = false;
			}

			else if(buttons[12].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level13");
				progressScript.levelProgress = false;
			}

			else if(buttons[13].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level14");
				progressScript.levelProgress = false;
			}

			else if(buttons[14].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level15");
				progressScript.levelProgress = false;
			}

			else if(buttons[15].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level16");
				progressScript.levelProgress = false;
			}

			else if(buttons[16].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level17");
				progressScript.levelProgress = false;
			}

			else if(buttons[17].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level18");
				progressScript.levelProgress = false;
			}

			else if(buttons[18].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level19");
				progressScript.levelProgress = false;
			}

			else if(buttons[19].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level20");
				progressScript.levelProgress = false;
			}

			else if(buttons[20].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level21");
				progressScript.levelProgress = false;
			}

			else if(buttons[21].GetComponent<GUITexture>().texture == buttonTextures[1])
			{
				Unlock("Level22");
				progressScript.levelProgress = false;
			}
		}
	}

	public void Lock(string name)
	{
		switch(name)
		{
			case "Level1" :
				buttons[0].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level2" :
				buttons[1].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level3" :
				buttons[2].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level4" :
				buttons[3].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level5" :
				buttons[4].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level6" :
				buttons[5].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level7" :
				buttons[6].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level8" :
				buttons[7].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level9" :
				buttons[8].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level10" :
				buttons[9].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level11" :
				buttons[10].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level12" :
				buttons[11].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level13" :
				buttons[12].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level14" :
				buttons[13].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level15" :
				buttons[14].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level16" :
				buttons[15].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level17" :
				buttons[16].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level18" :
				buttons[17].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level19" :
				buttons[18].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level20" :
				buttons[19].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level21" :
				buttons[20].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;

			case "Level22" :
				buttons[21].GetComponent<GUITexture>().texture = buttonTextures[1];
			break;
		}
	}

	public void Unlock(string name)
	{
		switch(name)
		{
			case "Level1" :
				buttons[0].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level2" :
				buttons[1].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level3" :
				buttons[2].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level4" :
				buttons[3].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level5" :
				buttons[4].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level6" :
				buttons[5].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level7" :
				buttons[6].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level8" :
				buttons[7].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level9" :
				buttons[8].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level10" :
				buttons[9].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level11" :
				buttons[10].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level12" :
				buttons[11].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level13" :
				buttons[12].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level14" :
				buttons[13].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level15" :
				buttons[14].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level16" :
				buttons[15].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level17" :
				buttons[16].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level18" :
				buttons[17].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level19" :
				buttons[18].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level20" :
				buttons[19].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level21" :
				buttons[20].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
			
			case "Level22" :
				buttons[21].GetComponent<GUITexture>().texture = buttonTextures[0];
			break;
		}
	}

	void Update () 
	{
	
	}	
}
