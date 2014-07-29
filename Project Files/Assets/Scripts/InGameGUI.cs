using UnityEngine;
using System.Collections;

public class InGameGUI : MonoBehaviour 
{
	public GUIText leftScoreLabel , rightScoreLabel;
	public int leftScoreValue , rightScoreValue;
	
	void Start () 
	{
	
	}

	void Update () 
	{
		if(Time.timeScale == 0)
		{
			return;
		}
		
		leftScoreLabel.text = leftScoreValue.ToString();
		rightScoreLabel.text = rightScoreValue.ToString();
	}
}
