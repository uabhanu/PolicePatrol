using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour 
{
	public GameObject persistentObj , persistentPrefab;
	public GUITexture[] buttons;
	public Persistent persistentScript;
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

		if(persistentObj == null)
		{
			persistentObj = Instantiate(persistentPrefab , new Vector3 (0 , 0 , 0) , Quaternion.identity) as GameObject;
			persistentScript = persistentObj.GetComponent<Persistent>();
		}
	}

	public void Lock(string name)
	{
		switch(name)
		{
			case "Level1" :
				buttons[0].guiTexture.texture = buttonTextures[1];
			break;

			case "Level2" :
				buttons[1].guiTexture.texture = buttonTextures[1];
			break;

			case "Level3" :
				buttons[2].guiTexture.texture = buttonTextures[1];
			break;

			case "Level4" :
				buttons[3].guiTexture.texture = buttonTextures[1];
			break;

			case "Level5" :
				buttons[4].guiTexture.texture = buttonTextures[1];
			break;

			case "Level6" :
				buttons[5].guiTexture.texture = buttonTextures[1];
			break;

			case "Level7" :
				buttons[6].guiTexture.texture = buttonTextures[1];
			break;

			case "Level8" :
				buttons[7].guiTexture.texture = buttonTextures[1];
			break;

			case "Level9" :
				buttons[8].guiTexture.texture = buttonTextures[1];
			break;

			case "Level10" :
				buttons[9].guiTexture.texture = buttonTextures[1];
			break;

			case "Level11" :
				buttons[10].guiTexture.texture = buttonTextures[1];
			break;

			case "Level12" :
				buttons[11].guiTexture.texture = buttonTextures[1];
			break;

			case "Level13" :
				buttons[12].guiTexture.texture = buttonTextures[1];
			break;

			case "Level14" :
				buttons[13].guiTexture.texture = buttonTextures[1];
			break;

			case "Level15" :
				buttons[14].guiTexture.texture = buttonTextures[1];
			break;

			case "Level16" :
				buttons[15].guiTexture.texture = buttonTextures[1];
			break;

			case "Level17" :
				buttons[16].guiTexture.texture = buttonTextures[1];
			break;

			case "Level18" :
				buttons[17].guiTexture.texture = buttonTextures[1];
			break;

			case "Level19" :
				buttons[18].guiTexture.texture = buttonTextures[1];
			break;

			case "Level20" :
				buttons[19].guiTexture.texture = buttonTextures[1];
			break;

			case "Level21" :
				buttons[20].guiTexture.texture = buttonTextures[1];
			break;

			case "Level22" :
				buttons[21].guiTexture.texture = buttonTextures[1];
			break;
		}
	}

	public void Unlock(string name)
	{
		switch(name)
		{
			case "Level1" :
				buttons[0].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level2" :
				buttons[1].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level3" :
				buttons[2].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level4" :
				buttons[3].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level5" :
				buttons[4].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level6" :
				buttons[5].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level7" :
				buttons[6].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level8" :
				buttons[7].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level9" :
				buttons[8].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level10" :
				buttons[9].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level11" :
				buttons[10].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level12" :
				buttons[11].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level13" :
				buttons[12].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level14" :
				buttons[13].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level15" :
				buttons[14].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level16" :
				buttons[15].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level17" :
				buttons[16].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level18" :
				buttons[17].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level19" :
				buttons[18].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level20" :
				buttons[19].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level21" :
				buttons[20].guiTexture.texture = buttonTextures[0];
			break;
			
			case "Level22" :
				buttons[21].guiTexture.texture = buttonTextures[0];
			break;
		}
	}

	void Update () 
	{
	
	}	
}
