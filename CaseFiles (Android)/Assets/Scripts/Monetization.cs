//using ChartboostSDK;
using Soomla;
using Soomla.Highway;
using Soomla.Levelup;
using Soomla.Profile;
using Soomla.Store;
using Soomla.Store.PolicePatrol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Advertisements;

public class Monetization : MonoBehaviour 
{
	public bool unityAdShown;
	public int levelNo;

	void Start () 
	{
//		Advertisement.Initialize("21734");
//
//		CBExternal.init();
//
//		CBExternal.cacheInterstitial(CBLocation.Default);
//		CBExternal.hasInterstitial(CBLocation.Default);
//		CBExternal.showInterstitial(CBLocation.Default);
//		CBExternal.cacheMoreApps(CBLocation.Default);
//		CBExternal.hasMoreApps(CBLocation.Default);
//		CBExternal.showMoreApps(CBLocation.Default);
//		CBExternal.cacheRewardedVideo(CBLocation.Default);
//		CBExternal.hasRewardedVideo(CBLocation.Default);
//		CBExternal.showRewardedVideo(CBLocation.Default);

		levelNo = Application.loadedLevel;

		StartCoroutine("UnityAds");

		StoreEvents.OnSoomlaStoreInitialized += OnSoomlaStoreInitialized;

		SoomlaProfile.Initialize();
		//SoomlaProfileAndroid.Login(Provider.FACEBOOK , "" , null);

		//SoomlaStore.Initialize(new InAppPurchases());

		StoreEvents.OnMarketPurchase += OnMarketPurchase;

		unityAdShown = false;
	}

	IEnumerator UnityAds()
	{
		yield return new WaitForSeconds(1);

//		if(Advertisement.isReady() && levelNo == 0 && !unityAdShown)
//		{
//			Advertisement.Show();
//			unityAdShown = true;
//		}

		StartCoroutine("UnityAds");
	}

//	public static bool hasInterstitial(CBLocation location) 
//	{
//		return CBExternal.hasInterstitial(location);
//	}
//
//	public static bool hasMoreApps(CBLocation location) 
//	{
//		return CBExternal.hasMoreApps(location);
//	}
//
//	public static bool hasRewardedVideo(CBLocation location) 
//	{
//		return CBExternal.hasRewardedVideo(location);
//	}

	public void OnMarketPurchase(PurchasableVirtualItem pvi , string payload , Dictionary<string , string> extra) 
	{
		// pvi is the PurchasableVirtualItem that was just purchased
		// payload is a text that you can give when you initiate the purchase operation and you want to receive back upon completion
		// extra will contain platform specific information about the market purchase.
		//      Android: The "extra" dictionary will contain "orderId" and "purchaseToken".
		//      iOS: The "extra" dictionary will contain "receipt" and "token".
		
		//if(persistentScript != null)
		//{
			//persistentScript.noAds = true;
		//}
	}
	
	public void OnSoomlaStoreInitialized()
	{
		//persistentScript.soomlaStarted = true;
		//StoreInfo.GetPurchasableItemWithProductId("no_ads_04");
	}
	
	void Update () 
	{

	}
}
