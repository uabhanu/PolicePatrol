using UnityEngine;
using System.Collections;

public class GUIPosition : MonoBehaviour 
{
	private Rect currentRect;
	
	void Start () 
	{
		currentRect = new Rect(15 , 15 , 150 , 150);
	}

	void OnGUI()
	{
		//Debug.Log("OnGUI()");
		currentRect.x = (Screen.width * 0.5f) - (currentRect.width * 0.5f);
		currentRect.y = (Screen.height * 0.5f) - (currentRect.height * 0.5f);
	}

	void Update () 
	{
	
	}
}
