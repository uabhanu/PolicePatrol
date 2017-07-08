using System.Collections;
using System.Runtime;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour 
{
	public float xScale;
	public LevelMenu2D levelMenu2DScript;
	public string buttonname , imageName;

	void Start () 
	{

	}

	public void ButtonClick(string buttonName)
	{
		switch(buttonname)
		{
			case "Level 1" :

				if(imageName == "Spr_Unlock" && xScale >= 5)
				{
					SceneManager.LoadScene("Level 1");
				}
	
			break;

			case "Level 2" :
				
				if(imageName == "Spr_Unlock" && xScale >= 5)
				{
					SceneManager.LoadScene("Level 2");
				}
			
			break;

			case "Level 3" :
				
				if(imageName == "Spr_Unlock" && xScale >= 5)
				{
					SceneManager.LoadScene("Level 3");
				}
			
			break;

			case "Level 4" :
				
				if(imageName == "Spr_Unlock" && xScale >= 5)
				{
					SceneManager.LoadScene("Level 4");;
				}
			
			break;

			case "Level 5" :
				
				if(imageName == "Spr_Unlock" && xScale >= 5)
				{
					SceneManager.LoadScene("Level 5");
				}
			
			break;

			case "Level 6" :
				
				if(imageName == "Spr_Unlock" && xScale >= 5)
				{
					SceneManager.LoadScene("Level 6");;
				}
			
			break;

			case "Play" :
				SceneManager.LoadScene("LevelSelection");
			break;

			case "Rate" :
				Application.OpenURL("https://play.google.com/store/apps/details?id=com.The3Brothers.C3"); //Correct URL will come here when ready
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

		if(buttonname == "Play")
		{
			ButtonClick("Play");
		}

		if(buttonname == "Rate")
		{
			ButtonClick("Rate");
		}
	}

	void Update () 
	{
		xScale = transform.localScale.x;
	}
}
