using ChartboostSDK;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class Monetization : MonoBehaviour 
{
	public bool unityAdShown;
	public int levelNo;

	void Start () 
	{
		Advertisement.Initialize("21734");

		CBExternal.init();

		CBExternal.cacheInterstitial(CBLocation.Default);
		CBExternal.hasInterstitial(CBLocation.Default);
		CBExternal.showInterstitial(CBLocation.Default);
		CBExternal.cacheMoreApps(CBLocation.Default);
		CBExternal.hasMoreApps(CBLocation.Default);
		CBExternal.showMoreApps(CBLocation.Default);
		CBExternal.cacheRewardedVideo(CBLocation.Default);
		CBExternal.hasRewardedVideo(CBLocation.Default);
		CBExternal.showRewardedVideo(CBLocation.Default);

		levelNo = Application.loadedLevel;

		StartCoroutine("UnityAds");

		unityAdShown = false;
	}

	IEnumerator UnityAds()
	{
		yield return new WaitForSeconds(1);

		if(Advertisement.isReady() && levelNo == 0 && !unityAdShown)
		{
			Advertisement.Show();
			unityAdShown = true;
		}

		StartCoroutine("UnityAds");
	}

	public static bool hasInterstitial(CBLocation location) 
	{
		return CBExternal.hasInterstitial(location);
	}

	public static bool hasMoreApps(CBLocation location) 
	{
		return CBExternal.hasMoreApps(location);
	}

	public static bool hasRewardedVideo(CBLocation location) 
	{
		return CBExternal.hasRewardedVideo(location);
	}
	
	void Update () 
	{

	}
}
