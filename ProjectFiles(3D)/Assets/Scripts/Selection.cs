using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour 
{
	public BoxCollider2D[] buttonColliders;
	public GUITexture[] buttonSprites;
	
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
	}

	public void Lock(string name)
	{
		switch(name)
		{
			case "Level1" :
				buttonColliders[0].enabled = false;
				buttonSprites[0].guiTexture.color = Color.red;
			break;

			case "Level2" :
				buttonColliders[1].enabled = false;
				buttonSprites[1].guiTexture.color = Color.red;
			break;

			case "Level3" :
				buttonColliders[2].enabled = false;
				buttonSprites[2].guiTexture.color = Color.red;
			break;

			case "Level4" :
				buttonColliders[3].enabled = false;
				buttonSprites[3].guiTexture.color = Color.red;
			break;

			case "Level5" :
				buttonColliders[4].enabled = false;
				buttonSprites[4].guiTexture.color = Color.red;
			break;

			case "Level6" :
				buttonColliders[5].enabled = false;
				buttonSprites[5].guiTexture.color = Color.red;
			break;

			case "Level7" :
				buttonColliders[6].enabled = false;
				buttonSprites[6].guiTexture.color = Color.red;
			break;

			case "Level8" :
				buttonColliders[7].enabled = false;
				buttonSprites[7].guiTexture.color = Color.red;
			break;

			case "Level9" :
				buttonColliders[8].enabled = false;
				buttonSprites[8].guiTexture.color = Color.red;
			break;

			case "Level10" :
				buttonColliders[9].enabled = false;
				buttonSprites[9].guiTexture.color = Color.red;
			break;

			case "Level11" :
				buttonColliders[10].enabled = false;
				buttonSprites[10].guiTexture.color = Color.red;
			break;

			case "Level12" :
				buttonColliders[11].enabled = false;
				buttonSprites[11].guiTexture.color = Color.red;
			break;

			case "Level13" :
				buttonColliders[12].enabled = false;
				buttonSprites[12].guiTexture.color = Color.red;
			break;

			case "Level14" :
				buttonColliders[13].enabled = false;
				buttonSprites[13].guiTexture.color = Color.red;
			break;

			case "Level15" :
				buttonColliders[14].enabled = false;
				buttonSprites[14].guiTexture.color = Color.red;
			break;

			case "Level16" :
				buttonColliders[15].enabled = false;
				buttonSprites[15].guiTexture.color = Color.red;
			break;

			case "Level17" :
				buttonColliders[16].enabled = false;
				buttonSprites[16].guiTexture.color = Color.red;
			break;

			case "Level18" :
				buttonColliders[17].enabled = false;
				buttonSprites[17].guiTexture.color = Color.red;
			break;

			case "Level19" :
				buttonColliders[18].enabled = false;
				buttonSprites[18].guiTexture.color = Color.red;
			break;

			case "Level20" :
				buttonColliders[19].enabled = false;
				buttonSprites[19].guiTexture.color = Color.red;
			break;

			case "Level21" :
				buttonColliders[20].enabled = false;
				buttonSprites[20].guiTexture.color = Color.red;
			break;

			case "Level22" :
				buttonColliders[21].enabled = false;
				buttonSprites[21].guiTexture.color = Color.red;
			break;
		}
	}

	public void Unlock(string name)
	{
		switch(name)
		{
			case "Level1" :
				buttonColliders[0].enabled = true;
				buttonSprites[0].guiTexture.color = Color.green;
			break;
			
			case "Level2" :
				buttonColliders[1].enabled = true;
				buttonSprites[1].guiTexture.color = Color.green;
			break;
			
			case "Level3" :
				buttonColliders[2].enabled = true;
				buttonSprites[2].guiTexture.color = Color.green;
			break;
			
			case "Level4" :
				buttonColliders[3].enabled = true;
				buttonSprites[3].guiTexture.color = Color.green;
			break;
			
			case "Level5" :
				buttonColliders[4].enabled = true;
				buttonSprites[4].guiTexture.color = Color.green;
			break;
			
			case "Level6" :
				buttonColliders[5].enabled = true;
				buttonSprites[5].guiTexture.color = Color.green;
			break;
			
			case "Level7" :
				buttonColliders[6].enabled = true;
				buttonSprites[6].guiTexture.color = Color.green;
			break;
			
			case "Level8" :
				buttonColliders[7].enabled = true;
				buttonSprites[7].guiTexture.color = Color.green;
			break;
			
			case "Level9" :
				buttonColliders[8].enabled = true;
				buttonSprites[8].guiTexture.color = Color.green;
			break;
			
			case "Level10" :
				buttonColliders[9].enabled = true;
				buttonSprites[9].guiTexture.color = Color.green;
			break;
			
			case "Level11" :
				buttonColliders[10].enabled = true;
				buttonSprites[10].guiTexture.color = Color.green;
			break;
			
			case "Level12" :
				buttonColliders[11].enabled = true;
				buttonSprites[11].guiTexture.color = Color.green;
			break;
			
			case "Level13" :
				buttonColliders[12].enabled = true;
				buttonSprites[12].guiTexture.color = Color.green;
			break;
			
			case "Level14" :
				buttonColliders[13].enabled = true;
				buttonSprites[13].guiTexture.color = Color.green;
			break;
			
			case "Level15" :
				buttonColliders[14].enabled = true;
				buttonSprites[14].guiTexture.color = Color.green;
			break;
			
			case "Level16" :
				buttonColliders[15].enabled = true;
				buttonSprites[15].guiTexture.color = Color.green;
			break;
			
			case "Level17" :
				buttonColliders[16].enabled = true;
				buttonSprites[16].guiTexture.color = Color.green;
			break;
			
			case "Level18" :
				buttonColliders[17].enabled = true;
				buttonSprites[17].guiTexture.color = Color.green;
			break;
			
			case "Level19" :
				buttonColliders[18].enabled = true;
				buttonSprites[18].guiTexture.color = Color.green;
			break;
			
			case "Level20" :
				buttonColliders[19].enabled = true;
				buttonSprites[19].guiTexture.color = Color.green;
			break;
			
			case "Level21" :
				buttonColliders[20].enabled = true;
				buttonSprites[20].guiTexture.color = Color.green;
			break;
			
			case "Level22" :
				buttonColliders[21].enabled = true;
				buttonSprites[21].guiTexture.color = Color.green;
			break;
		}
	}

	void Update () 
	{
	
	}	
}
