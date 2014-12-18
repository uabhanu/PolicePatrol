using System.Collections;
using System.Runtime;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour 
{
	public float xPosition;
	public string buttonname , imageName;

	void Start () 
	{

	}

	public void ButtonClick(string buttonName)
	{
		switch(buttonname)
		{
			case "Level 1" :

				if(imageName == "Spr_Unlock" && xPosition >= -65)
				{
					Application.LoadLevel(1);
				}
	
			break;

			case "Level 2" :
				
				if(imageName == "Spr_Unlock" && xPosition >= -65)
				{
					Application.LoadLevel(2);
				}
			
			break;

			case "Level 3" :
				
				if(imageName == "Spr_Unlock" && xPosition >= -65)
				{
					Application.LoadLevel(3);
				}
			
			break;

			case "Level 4" :
				
				if(imageName == "Spr_Unlock" && xPosition >= -65)
				{
					Application.LoadLevel(4);
				}
			
			break;

			case "Level 5" :
				
				if(imageName == "Spr_Unlock" && xPosition >= -65)
				{
					Application.LoadLevel(5);
				}
			
			break;

			case "Level 6" :
				
				if(imageName == "Spr_Unlock" && xPosition >= -65)
				{
					Application.LoadLevel(6);
				}
			
			break;
		}
	}

	void OnMouseDown()
	{
		if(buttonname == "Level 1")
		{
			ButtonClick("Level 1");
		}

		if(buttonname == "Level 2")
		{
			ButtonClick("Level 2");
		}

		if(buttonname == "Level 3")
		{
			ButtonClick("Level 3");
		}

		if(buttonname == "Level 4")
		{
			ButtonClick("Level 4");
		}

		if(buttonname == "Level 5")
		{
			ButtonClick("Level 5");
		}

		if(buttonname == "Level 6")
		{
			ButtonClick("Level 6");
		}
	}

	void Update () 
	{
		xPosition = transform.position.x;
	}
}
