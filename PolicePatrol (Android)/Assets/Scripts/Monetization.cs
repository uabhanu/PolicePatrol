//using GameThrivePush;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Monetization : MonoBehaviour 
{
	private string m_levelName;

	public bool m_unityAdShown;
    public string m_adLevelName = "LevelSelection";

	void Start () 
	{
		m_levelName = Application.loadedLevelName;

		StartCoroutine("Social");
		StartCoroutine("UnityAds");

		m_unityAdShown = false;
	}

	IEnumerator Social()
	{
		yield return new WaitForSeconds(4);
		//GameThrive.Init("5aba553a-89e1-11e4-bce5-3b48afb5f3a2" , "804055631157" , HandleNotification);
	}

	IEnumerator UnityAds()
	{
		yield return new WaitForSeconds(2);

		if(Advertisement.isReady() && m_levelName == m_adLevelName && !m_unityAdShown)
		{
			Advertisement.Show();
			m_unityAdShown = true;
		}

		StartCoroutine("UnityAds");
	}
}
