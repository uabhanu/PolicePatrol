using ChartboostSDK;
using System.Collections;
using UnityEngine;

public class ChartboostMonetization : MonoBehaviour 
{
	void Start () 
	{
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
