using UnityEngine;
using System.Collections.Generic;


public class TestUI: MonoBehaviour
{
	public static string resultText = "default";
	public static NativeXAndroid android;
	public static NativeXiOS iOS;
	
	void Start()
	{
		iOS = new NativeXiOS(14052,"", null);
		android = new NativeXAndroid(5077, "","","Test Pub");
		iOS.actionId = 17;
		android.actionId = 16;
		Debug.Log(iOS.ToString());
		Debug.Log("NativeX - Unity has Started");
		NativeXCore.initialization(android, iOS);
	}

	void OnEnable() 
	{
		NativeXHandler.e_didSDKinitialize += didSDKInititialize;
		NativeXHandler.e_didAdLoad += didAdLoad;
		NativeXHandler.e_actionCompleted += actionComplete;
		NativeXHandler.e_actionFailed += actionFailed;
		NativeXHandler.e_userLeavingApplication += userLeavingApplication;
		NativeXHandler.e_balanceTransfered += balanceTransfered;
		NativeXHandler.e_didPerformAction += didPerformAction;

	}


	void OnGUI()
	{
		float yPos = 5.0f;
		float xPos = 5.0f;
		float width = ((Screen.width/2) - (Screen.width/15));
		float height = Screen.height/10;
		float heightPlus = height + 10.0f;
		
		GUI.skin.button.fontSize = 30;
		GUI.skin.button.fontStyle = FontStyle.Bold;

		if( GUI.Button( new Rect( xPos, yPos, width, height ), "Fetch Interstitial" ) )
		{
			NativeXCore.fetchAd("testOne");
			Debug.Log("Get And Cache Interstitial has been clicked");
		}

		if( GUI.Button( new Rect( xPos, yPos+=heightPlus, width, height ), "Show Interstitial" ) )
		{
			NativeXCore.showAd("testOne");
			Debug.Log("Show Interstitial has been clicked.");
		}

		if( GUI.Button( new Rect( xPos, yPos+=heightPlus, width, height ), "Fetch Banner" ) )
		{
			NativeXCore.fetchBanner("default", NativeXBannerPosition.TOP);
			Debug.Log("Fetch Banner has been clicked.");
		}

		if( GUI.Button( new Rect( xPos, yPos+=heightPlus, width, height ), "Show Banner" ) )
		{
			NativeXCore.showBanner("default", NativeXBannerPosition.TOP);
			Debug.Log("Show Banner has been clicked.");
		}

		//Moving buttons to the other side of the screen
		xPos = Screen.width - width - 5.0f;
		yPos = 5.0f;

		if( GUI.Button( new Rect( xPos, yPos, width, height ), "Redeem Currency" ) )
		{
			NativeXCore.redeemCurrency();
			Debug.Log("Redeem Currency has been clicked");
		}

		if( GUI.Button( new Rect( xPos, yPos+=heightPlus, width, height ), "Action Taken" ) )
		{
			NativeXCore.actionTaken(17,16);
			Debug.Log("Action Taken has been clicked");
		}
#if UNITY_IPHONE
		if( GUI.Button( new Rect( xPos, yPos+=heightPlus, width, height ), "Track In App Purchase" ) )
		{
			NativeXCore.trackInAppPurchase("prodId","storeId",2.0f,2,"prodTitle");
			Debug.Log("Track In App Purchase has been clicked");
		}
#endif
		
		GUI.Label(new Rect(xPos, yPos += heightPlus, width, height), resultText);

	}

	void userLeavingApplication (bool obj)
	{
		resultText = "userLeavingApplication:" +obj;
	}
	
	void balanceTransfered (NativeXCurrencyData obj)
	{
		resultText = "";
		foreach(var me in obj.balances){
			resultText += "balanceTransfered:" +me.ToString()+"\n";
			Debug.Log("Amout: "+ me.Amount + "-- Display Name: "+me.DisplayName+" -- External: "+me.ExternalCurrencyId+" -- ID: "+me.Id);
		}

	}
	
	void actionFailed (string obj)
	{
		resultText = "actionFailed:" +obj;
	}
	
	void actionComplete (string obj)
	{
		resultText = "actionComplete:" +obj;
	}
	
	void didAdLoad (string obj)
	{
		resultText = "didAdLoad:" +obj;
		Debug.Log(resultText);
	}
	
	void didFeaturedOfferLoad (bool obj)
	{
		resultText = "didFeaturedOfferLoad:" +obj;
	}
	
	void didSDKInititialize (bool obj)
	{
		resultText = "didSDKInititialize:" +obj;
	}
	
	void didPerformAction(bool action)
		{
				resultText = "didPerformAction: " + action;
		}
	
}


