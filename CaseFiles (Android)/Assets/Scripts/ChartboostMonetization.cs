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
		CBExternal.cacheInPlay(CBLocation.Default);
		CBExternal.hasInPlay(CBLocation.Default);
		CBExternal.getInPlay(CBLocation.Default);
	}
	
//	public static event Action didCacheInterstitial;
//	public static event Action didCacheMoreApps;
//	public static event Action didCacheRewardedVideo;
//	public static event Action didClickInterstitial;
//	public static event Action didClickMoreApps;
//	public static event Action didClickRewardedVideo;
//	public static event Action didCloseInterstitial;
//	public static event Action didCloseMoreApps;
//	public static event Action didCloseRewardedVideo;
//	public static event Action didDismissInterstitial;
//	public static event Action didDismissMoreApps;
//	public static event Action didDismissRewardedVideo;
//	public static event Action didDisplayInterstitial;
//	public static event Action didDisplayMoreApps;
//	public static event Action didDisplayRewardedVideo;
//	public static event Action<CBLocation> willDisplayVideo;
//	public static event Action<CBLocation , int> didCompleteRewardedVideo;
//	public static event Action<CBLocation , CBImpressionError> didFailToLoadInterstitial;
//	public static event Action<CBLocation , CBImpressionError> didFailToLoadMoreApps;
//	public static event Action<CBLocation , CBImpressionError> didFailToLoadRewardedVideo;
//	public static event Action<CBLocation , CBImpressionError> didFailToRecordClick;
//	public static event Func<CBLocation , bool> shouldDisplayInterstitial;
//	public static event Func<CBLocation , bool> shouldDisplayMoreApps;
//	public static event Func<CBLocation, bool> shouldDisplayRewardedVideo;

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
