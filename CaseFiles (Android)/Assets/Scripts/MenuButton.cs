using System.Collections;
using UnityEngine;

public class MenuButton : MonoBehaviour 
{	
	public int levelToLoad;

	void Start () 
	{

	}

	public void ButtonClick(int levelToLoad)
	{
		Application.LoadLevel(levelToLoad);
	}

	void Update () 
	{
	
	}
}
