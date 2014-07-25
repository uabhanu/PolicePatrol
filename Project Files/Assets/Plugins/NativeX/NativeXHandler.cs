using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using System.Runtime.Serialization;


public class NativeXHandler : MonoBehaviour {
	
	/** Called when SDK has finished initializing
 	*
 	* @param bool - Will return true if the SDK has successfully initialized
 	* 				Well return false if there was an error
	*/
	public static event Action<bool> e_didSDKinitialize;

	/** Called when the interstitial is loaded and ready to be displayed
 	*  If showInterstitial() was called this will fire immediately before the ad is shown
 	*  If using fetchInterstitial() use this method to know 
 	*  when you have an interstitial ready to show instantly
 	*
 	* @param string - this string will be returned with the name of the interstitial that has been loaded
	*                 if the interstitial has no name it will return "NAME_UNDEFINED"
 	*                 if no interstitial was loaded this event will return "NO_INTERSTITIAL_LOADED"
 	*/
	public static event Action<string> e_didAdLoad;

	/** Called when there was no ad loaded
 	*  If using fetchInterstitial() use this method to know 
 	*  that you were unable to receive an ad
 	*
 	* @param string - this string will be returned with the name of the interstitial that has been loaded
	*                 if the interstitial has no name it will return "NAME_UNDEFINED"
 	*                 if no interstitial was loaded this event will return an empty string
 	*/
	public static event Action<string> e_noAdLoaded;

	/** Called when the Banner Ad Unit will expand to fullscreen
 	*
 	* @param string - This string will return the name of the Ad Unit
 	*                 if the interstitial has no name it will return "NAME_UNDEFINED"
	*/
	public static event Action<string> e_adWillExpand;

	/** Called when the Banner Ad Unit will collapse back to normal banner view
 	*
 	* @param string - This string will return the name of the Ad Unit
 	*                 if the interstitial has no name it will return "NAME_UNDEFINED"
	*/
	public static event Action<string> e_adWillCollapse;

	/** Called when the Banner Ad Unit will resize
 	*
 	* @param string - This string will return the name of the Ad Unit
 	*                 if the interstitial has no name it will return "NAME_UNDEFINED"
	*/
	public static event Action<string> e_adWillResize;

	/** Called when the Ad Unit has been closed by the user after being displayed
 	*
 	* @param string - This string will return the name of the interstitial that has been closed
 	*                 if the interstitial has no name it will return "NAME_UNDEFINED"
	*/
	public static event Action<string> e_actionCompleted;

	/** Called when the Ad Unit has failed to either load or display
 	*
	 * @param string - This string will return the name of the interstitial that has failed to load
 	*                 if the interstitial has no name it will return "NAME_UNDEFINED"
 	*/
	public static event Action<string> e_actionFailed;

	/** Called when the User has chosen to go through with the presented offer and will be redirected from you application
 	*	
 	* @param string - This string will return the name of the interstitial that has redirected the user
 	*                 if the interstitial has no name it will return "NAME_UNDEFINED"
 	*/
	public static event Action<bool> e_userLeavingApplication;

	/** Called when a balance is returned from calling redeemBalance()
	 * 
	 *  @param List<NativeXBalance> - This List will return any number of NativeXBalance objects containing information that 
	 * 								  should be used to award the player with the credits they earned
	 */
	public static event Action<NativeXCurrencyData> e_balanceTransfered;

	/** Called when the SDK has successfully intitialized
	 * 
	 * @param string - Will contain the current Session Id
	 * 
	 */
	public static event Action<string> e_sessionId;

	/** Called when a user clicks through to either rate your app or sign up for automatic updates(Android only)
	 * 
	 * @param bool - Will return true of they continue, false if the close or cancel
	 * 
	 */
	public static event Action<bool> e_didPerformAction;

	/** Called when the Ad expired to let the developer know he should fetch a new Ad
	 * 
	 * @param string - Will return the placement name of the Ad that has expired
	 * 				   if the interstitial has no name it will return "NAME_UNDEFINED"
	 */
	public static event Action<string> e_adDidExpire;

	/** Called if we were able to load addition adInfo from the advertisement
	 * 
	 * @param Dictionary - Will return a Dictionary object containing the contents
	 * 					   of the adInfo meta data within the loaded advertisement
	 * 				   
	 */
	public static event Action<Dictionary<string,object>> e_adInfo;

	/* Called when the ad that we are about to show will contain audio
	 * 
	 *  @param bool - This will return true if there will be audio within the ad about to be shown
	 */
	public static event Action<bool> e_willPlayAudio;

	public void didSDKinitialize(string init)
	{
		if(e_didSDKinitialize!=null){
			if(init == "1"){
				e_didSDKinitialize(true);
			}
			else{
				e_didSDKinitialize(false);
			}
		}
	}

	public void didAdLoad(string a_name)
	{
		if(e_didAdLoad!=null){
			if(null != a_name){
				e_didAdLoad(a_name);
			}
		}
	}

	public void noAdLoaded(string a_name)
	{
		if(e_noAdLoaded!=null){
			if(null != a_name){
				e_noAdLoaded(a_name);
			}
		}
	}
	
	public void adWillExpand(string name)
	{
		if(e_adWillExpand!=null){
			if(null != name){
				e_adWillExpand(name);
			}
		}
	}

	public void adWillCollapse(string name)
	{
		if(e_adWillCollapse!=null){
			if(null != name){
				e_adWillCollapse(name);
			}
		}
	}

	public void adWillResize(string name)
	{
		if(e_adWillResize!=null){
			if(null != name){
				e_adWillResize(name);
			}
		}
	}

	public void actionComplete(string type)
	{
		if(e_actionCompleted!=null){
			if(type!=null){
				e_actionCompleted(type);
			}
		}
	}

	public void actionFailed(string type)
	{
		if(e_actionFailed!=null){
			if(type !=null){
				e_actionFailed(type);
			}
		}
	}

	public void adDidExpire(string a_name)
	{
		if(e_adDidExpire!=null){
			if(a_name !=null){
				e_adDidExpire(a_name);
			}
		}
	}

	public void userLeavingApplication(string leaving)
	{
		if(e_userLeavingApplication!=null){
			if (leaving == "0") {
				e_userLeavingApplication (false);
			} else {
				e_userLeavingApplication (true);
			}
		}
	}

	public void balanceTransfered(string json)
	{
		if(e_balanceTransfered!=null)
		{
			Debug.Log("We have hit the balanceTransfered()");
			if(json != null){
				if(json.Length > 0){
					Debug.Log("Found a Balance:");
					Debug.Log(json);
					e_balanceTransfered(NativeXCurrencyData.convertJson(json));
				}
				else{
					e_balanceTransfered(new NativeXCurrencyData());
				}
				
			}
		}
	}

	public void sessionId(string sessionId)
	{
		if(e_sessionId!=null){
			if(sessionId!=null){
				e_sessionId(sessionId);
			}
		}	
	}

	public void didPerformAction(string action)
	{
			if (e_didPerformAction != null) {
					if (action == "1") {
							e_didPerformAction (true);
					} else {
							e_didPerformAction (false);
					}
			}
	}

	public void adInfo(string json)
	{
		Dictionary<string, object> dict = new Dictionary<string, object>();
		dict = JsonReader.Deserialize<Dictionary<string,object>>(json);

		if(null != e_adInfo){
			if(null != dict){
				e_adInfo(dict);
			}
		}
	}

	public void willPlayAudio(string audio)
	{
		if(null != e_willPlayAudio){
			if("1" == audio){
				e_willPlayAudio(true);
			}else{
				e_willPlayAudio(false);
			}
		}
	}

}
