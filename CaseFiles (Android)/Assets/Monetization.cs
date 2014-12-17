using ChartboostSDK;
using System.Collections;
using UnityEngine;

public class Monetization : MonoBehaviour 
{
	
	void Start () 
	{
		CBExternal.cacheInterstitial(CBLocation.Default);
		CBExternal.hasInterstitial(CBLocation.Default);
		CBExternal.showInterstitial(CBLocation.Default);
		CBExternal.cacheMoreApps(CBLocation.Default);
		CBExternal.hasMoreApps(CBLocation.Default);
		CBExternal.showMoreApps(CBLocation.Default);
		CBExternal.cacheRewardedVideo(CBLocation.Default);
		CBExternal.hasRewardedVideo(CBLocation.Default);
		CBExternal.showRewardedVideo(CBLocation.Default);
		CBExternal.cacheInPlay(CBLocation.Default);
		CBExternal.hasInPlay(CBLocation.Default);
		CBExternal.getInPlay(CBLocation.Default);
	}

	public static CBInPlay getInPlay(CBLocation location) 
	{
		return CBExternal.getInPlay(location);
	}

	public static bool hasInPlay(CBLocation location) 
	{
		return CBExternal.hasInPlay(location);
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
