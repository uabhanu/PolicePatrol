using UnityEngine;
using System.Collections;

public class LevelSelection : MonoBehaviour 
{
	public bool levelProgress;
	public GameObject iguiObj , PF_LevelProgress , progressObj;
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

		//progressObj = GameObject.Find("PF_LevelProgress(Clone)");
		progressObj = GameObject.FindGameObjectWithTag("Progress");

		if(progressObj != null)
		{
			//progressObj = Instantiate(PF_LevelProgress , Vector3.zero , Quaternion.identity) as GameObject;
			progressScript = progressObj.GetComponent<LevelProgress>();
		}

		#region Selection
		if(progressScript != null && progressScript.levelProgress)
		{
			if(buttons[1].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 1)
			{
				Unlock("Level2");
				progressScript.levelProgress = false;
			}

			if(buttons[2].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 2)
			{
				Unlock("Level2");
				Unlock("Level3");
				progressScript.levelProgress = false;
			}

			if(buttons[3].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 3)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				progressScript.levelProgress = false;
			}

			if(buttons[4].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 4)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				progressScript.levelProgress = false;
			}

			if(buttons[5].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 5)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				progressScript.levelProgress = false;
			}

			if(buttons[6].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 6)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				progressScript.levelProgress = false;
			}

			if(buttons[7].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 7)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				progressScript.levelProgress = false;
			}

			if(buttons[8].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 8)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				Unlock("Level9");
				progressScript.levelProgress = false;
			}

			if(buttons[9].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 9)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				Unlock("Level9");
				Unlock("Level10");
				progressScript.levelProgress = false;
			}

			if(buttons[10].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 10)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				Unlock("Level9");
				Unlock("Level10");
				Unlock("Level11");
				progressScript.levelProgress = false;
			}

			if(buttons[11].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 11)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				Unlock("Level9");
				Unlock("Level10");
				Unlock("Level11");
				Unlock("Level12");
				progressScript.levelProgress = false;
			}

			if(buttons[12].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 12)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				Unlock("Level9");
				Unlock("Level10");
				Unlock("Level11");
				Unlock("Level12");
				Unlock("Level13");
				progressScript.levelProgress = false;
			}

			if(buttons[13].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 13)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				Unlock("Level9");
				Unlock("Level10");
				Unlock("Level11");
				Unlock("Level12");
				Unlock("Level13");
				Unlock("Level14");
				progressScript.levelProgress = false;
			}

			if(buttons[14].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 14)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				Unlock("Level9");
				Unlock("Level10");
				Unlock("Level11");
				Unlock("Level12");
				Unlock("Level13");
				Unlock("Level14");
				Unlock("Level15");
				progressScript.levelProgress = false;
			}

			if(buttons[15].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 15)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				Unlock("Level9");
				Unlock("Level10");
				Unlock("Level11");
				Unlock("Level12");
				Unlock("Level13");
				Unlock("Level14");
				Unlock("Level15");
				Unlock("Level16");
				progressScript.levelProgress = false;
			}

			if(buttons[16].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 16)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				Unlock("Level9");
				Unlock("Level10");
				Unlock("Level11");
				Unlock("Level12");
				Unlock("Level13");
				Unlock("Level14");
				Unlock("Level15");
				Unlock("Level16");
				Unlock("Level17");
				progressScript.levelProgress = false;
			}

			if(buttons[17].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 17)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				Unlock("Level9");
				Unlock("Level10");
				Unlock("Level11");
				Unlock("Level12");
				Unlock("Level13");
				Unlock("Level14");
				Unlock("Level15");
				Unlock("Level16");
				Unlock("Level17");
				Unlock("Level18");
				progressScript.levelProgress = false;
			}

			if(buttons[18].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 18)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				Unlock("Level9");
				Unlock("Level10");
				Unlock("Level11");
				Unlock("Level12");
				Unlock("Level13");
				Unlock("Level14");
				Unlock("Level15");
				Unlock("Level16");
				Unlock("Level17");
				Unlock("Level18");
				Unlock("Level19");
				progressScript.levelProgress = false;
			}

			if(buttons[19].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 19)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				Unlock("Level9");
				Unlock("Level10");
				Unlock("Level11");
				Unlock("Level12");
				Unlock("Level13");
				Unlock("Level14");
				Unlock("Level15");
				Unlock("Level16");
				Unlock("Level17");
				Unlock("Level18");
				Unlock("Level19");
				Unlock("Level20");
				progressScript.levelProgress = false;
			}

			if(buttons[20].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 20)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				Unlock("Level9");
				Unlock("Level10");
				Unlock("Level11");
				Unlock("Level12");
				Unlock("Level13");
				Unlock("Level14");
				Unlock("Level15");
				Unlock("Level16");
				Unlock("Level17");
				Unlock("Level18");
				Unlock("Level19");
				Unlock("Level20");
				Unlock("Level21");
				progressScript.levelProgress = false;
			}

			if(buttons[21].GetComponent<GUITexture>().texture == buttonTextures[1] && progressScript.levelNo == 21)
			{
				Unlock("Level2");
				Unlock("Level3");
				Unlock("Level4");
				Unlock("Level5");
				Unlock("Level6");
				Unlock("Level7");
				Unlock("Level8");
				Unlock("Level9");
				Unlock("Level10");
				Unlock("Level11");
				Unlock("Level12");
				Unlock("Level13");
				Unlock("Level14");
				Unlock("Level15");
				Unlock("Level16");
				Unlock("Level17");
				Unlock("Level18");
				Unlock("Level19");
				Unlock("Level20");
				Unlock("Level21");
				Unlock("Level22");
				progressScript.levelProgress = false;
			}
		}
		#endregion
	}

	#region Lock Method
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
	#endregion

	#region Unlock Method
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
	#endregion

	void Update () 
	{

	}	
}