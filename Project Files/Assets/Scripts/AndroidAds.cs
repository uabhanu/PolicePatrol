using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AndroidAds : MonoBehaviour 
{
	public int androidActionID , iOSActionID;
	public List<NativeXBalance> balancesList;
	public NativeXAndroid androidAds;
	public NativeXiOS iOSAds;
	
	void Start () 
	{
		//androidActionID = //This will be available after you successfully completed creating a Campaign from NativeX Self Service
		NativeXCore.initialization(androidAds , iOSAds);
		NativeXCore.appWasRun();
		NativeXCore.actionTaken(20146 , iOSActionID);
		NativeXCore.redeemCurrency();
		NativeXCore.showAd("Startup");
	}

	void OnEnable()
	{
		NativeXHandler.e_balanceTransfered += e_balanceTransfered;
		NativeXHandler. e_didSDKinitialize += e_didSDKinitialize;
	}

	void OnDisable()
	{
		NativeXHandler. e_balanceTransfered -= e_balanceTransfered;
		NativeXHandler. e_didSDKinitialize -= e_didSDKinitialize;
	}

	void e_didSDKinitialize ( bool result)
	{
		//Here you would place your logic for whether to
		//continue with your calls into our SDK
	}

	void e_balanceTransfered(NativeXCurrencyData balance)
	{
		//Here you would place your logic for rewarding the player
		//the currency they have earned
	}

	void Update () 
	{
	
	}
}
