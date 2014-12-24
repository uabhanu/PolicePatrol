using ChartboostSDK;
using GameThrivePush;
//using Soomla;
//using Soomla.Highway;
//using Soomla.Levelup;
//using Soomla.Profile;
//using Soomla.Store;
//using Soomla.Store.PolicePatrol;
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
		//Advertisement.Initialize("21734"); Uncomment before Releasing the game

//		CBExternal.init(); Uncomment before Releasing the game
//
//		CBExternal.cacheInterstitial(CBLocation.Default); Uncomment before Releasing the game
//		CBExternal.hasInterstitial(CBLocation.Default); Uncomment before Releasing the game
//		CBExternal.showInterstitial(CBLocation.Default); Uncomment before Releasing the game
//		CBExternal.cacheMoreApps(CBLocation.Default); Uncomment before Releasing the game
//		CBExternal.hasMoreApps(CBLocation.Default); Uncomment before Releasing the game
//		CBExternal.showMoreApps(CBLocation.Default); Uncomment before Releasing the game
//		CBExternal.cacheRewardedVideo(CBLocation.Default); Uncomment before Releasing the game
//		CBExternal.hasRewardedVideo(CBLocation.Default); Uncomment before Releasing the game
//		CBExternal.showRewardedVideo(CBLocation.Default); Uncomment before Releasing the game

		m_levelName = Application.loadedLevelName;

		StartCoroutine("Push");
		StartCoroutine("UnityAds");

		//StoreEvents.OnSoomlaStoreInitialized += OnSoomlaStoreInitialized;
		//SoomlaProfile.Initialize();
		//SoomlaProfileAndroid.Login(Provider.FACEBOOK , "" , null);
		//SoomlaStore.Initialize(new InAppPurchases());
		//StoreEvents.OnMarketPurchase += OnMarketPurchase;

		m_unityAdShown = false;
	}

	IEnumerator Push()
	{
		yield return new WaitForSeconds(4);
		GameThrive.Init("5aba553a-89e1-11e4-bce5-3b48afb5f3a2" , "804055631157" , HandleNotification);
	}

	IEnumerator UnityAds()
	{
		yield return new WaitForSeconds(1);

		if(Advertisement.isReady() && m_levelName == m_adLevelName && !m_unityAdShown)
		{
			Advertisement.Show();
			m_unityAdShown = true;
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

//	public void OnMarketPurchase(PurchasableVirtualItem pvi , string payload , Dictionary<string , string> extra) 
//	{
//		 pvi is the PurchasableVirtualItem that was just purchased
//		 payload is a text that you can give when you initiate the purchase operation and you want to receive back upon completion
//		 extra will contain platform specific information about the market purchase.
//		      Android: The "extra" dictionary will contain "orderId" and "purchaseToken".
//		      iOS: The "extra" dictionary will contain "receipt" and "token".
//		
//		if(persistentScript != null)
//		{
//			persistentScript.noAds = true;
//		}
//	}
//	
//	public void OnSoomlaStoreInitialized()
//	{
//		persistentScript.soomlaStarted = true;
//		StoreInfo.GetPurchasableItemWithProductId("no_ads_04");
//	}

	void HandleNotification(string message , Dictionary<string , object> additionalData , bool isActive)
	{
		
	}
	
	void Update () 
	{

	}
}
