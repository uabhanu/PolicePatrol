using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour 
{
	public GameObject persistentObj , persistentPrefab;
	public GUITexture[] buttonSprites;
	public Persistent persistentScript;
	
	void Start () 
	{
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
				buttonSprites[0].guiTexture.color = Color.red;
			break;

			case "Level2" :
				buttonSprites[1].guiTexture.color = Color.red;
			break;

			case "Level3" :
				buttonSprites[2].guiTexture.color = Color.red;
			break;

			case "Level4" :
				buttonSprites[3].guiTexture.color = Color.red;
			break;

			case "Level5" :
				buttonSprites[4].guiTexture.color = Color.red;
			break;

			case "Level6" :
				buttonSprites[5].guiTexture.color = Color.red;
			break;

			case "Level7" :
				buttonSprites[6].guiTexture.color = Color.red;
			break;

			case "Level8" :
				buttonSprites[7].guiTexture.color = Color.red;
			break;

			case "Level9" :
				buttonSprites[8].guiTexture.color = Color.red;
			break;

			case "Level10" :
				buttonSprites[9].guiTexture.color = Color.red;
			break;

			case "Level11" :
				buttonSprites[10].guiTexture.color = Color.red;
			break;

			case "Level12" :
				buttonSprites[11].guiTexture.color = Color.red;
			break;

			case "Level13" :
				buttonSprites[12].guiTexture.color = Color.red;
			break;

			case "Level14" :
				buttonSprites[13].guiTexture.color = Color.red;
			break;

			case "Level15" :
				buttonSprites[14].guiTexture.color = Color.red;
			break;

			case "Level16" :
				buttonSprites[15].guiTexture.color = Color.red;
			break;

			case "Level17" :
				buttonSprites[16].guiTexture.color = Color.red;
			break;

			case "Level18" :
				buttonSprites[17].guiTexture.color = Color.red;
			break;

			case "Level19" :
				buttonSprites[18].guiTexture.color = Color.red;
			break;

			case "Level20" :
				buttonSprites[19].guiTexture.color = Color.red;
			break;

			case "Level21" :
				buttonSprites[20].guiTexture.color = Color.red;
			break;

			case "Level22" :
				buttonSprites[21].guiTexture.color = Color.red;
			break;
		}
	}

	public void Unlock(string name)
	{
		switch(name)
		{
			case "Level1" :
				buttonSprites[0].guiTexture.color = Color.green;
			break;
			
			case "Level2" :
				buttonSprites[1].guiTexture.color = Color.green;
			break;
			
			case "Level3" :
				buttonSprites[2].guiTexture.color = Color.green;
			break;
			
			case "Level4" :
				buttonSprites[3].guiTexture.color = Color.green;
			break;
			
			case "Level5" :
				buttonSprites[4].guiTexture.color = Color.green;
			break;
			
			case "Level6" :
				buttonSprites[5].guiTexture.color = Color.green;
			break;
			
			case "Level7" :
				buttonSprites[6].guiTexture.color = Color.green;
			break;
			
			case "Level8" :
				buttonSprites[7].guiTexture.color = Color.green;
			break;
			
			case "Level9" :
				buttonSprites[8].guiTexture.color = Color.green;
			break;
			
			case "Level10" :
				buttonSprites[9].guiTexture.color = Color.green;
			break;
			
			case "Level11" :
				buttonSprites[10].guiTexture.color = Color.green;
			break;
			
			case "Level12" :
				buttonSprites[11].guiTexture.color = Color.green;
			break;
			
			case "Level13" :
				buttonSprites[12].guiTexture.color = Color.green;
			break;
			
			case "Level14" :
				buttonSprites[13].guiTexture.color = Color.green;
			break;
			
			case "Level15" :
				buttonSprites[14].guiTexture.color = Color.green;
			break;
			
			case "Level16" :
				buttonSprites[15].guiTexture.color = Color.green;
			break;
			
			case "Level17" :
				buttonSprites[16].guiTexture.color = Color.green;
			break;
			
			case "Level18" :
				buttonSprites[17].guiTexture.color = Color.green;
			break;
			
			case "Level19" :
				buttonSprites[18].guiTexture.color = Color.green;
			break;
			
			case "Level20" :
				buttonSprites[19].guiTexture.color = Color.green;
			break;
			
			case "Level21" :
				buttonSprites[20].guiTexture.color = Color.green;
			break;
			
			case "Level22" :
				buttonSprites[21].guiTexture.color = Color.green;
			break;
		}
	}

	void Update () 
	{
	
	}	
}
