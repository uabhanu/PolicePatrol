using System.Collections;
using System.Runtime;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour 
{
	public int levelToLoad;
	public string imageName;

	void Start () 
	{

	}

	public void ButtonClick(int levelToLoad)
	{
		if(imageName.Equals("Spr_Unlock"))
		{
			Application.LoadLevel(levelToLoad);
		}
	}

	void Update () 
	{
	
	}
}
