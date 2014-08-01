using UnityEngine;
using System.Collections;

public class InGameUI : MonoBehaviour 
{
	public GUIText truckLeftScoreLabel , truckRightScoreLabel;
	public int truckLeftScoreValue , truckRightScoreValue;

	void Start () 
	{
	
	}

	void Update () 
	{
		if(Time.timeScale == 0)
		{
			return;
		}
		
		truckLeftScoreLabel.text = truckLeftScoreValue.ToString();
		truckRightScoreLabel.text = truckRightScoreValue.ToString();
	}
}
