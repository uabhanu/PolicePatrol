using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Soomla.Highway
{
	public class SoomlaHighway
	{
#if UNITY_IOS 
		//&& !UNITY_EDITOR
		[DllImport ("__Internal")]
		private static extern int soomlaHighway_initialize(string gameKey, string envKey);
		[DllImport ("__Internal")]
		private static extern int soomlaHighway_setUrl(string url);
		[DllImport ("__Internal")]
		private static extern int soomlaHighway_start();
		[DllImport ("__Internal")]
		private static extern int soomlaHighway_startDurationNagger();
		[DllImport ("__Internal")]
		private static extern int soomlaHighway_stopDurationNagger();
#endif

		public static void Initialize() {
			SoomlaUtils.LogDebug (TAG, "SOOMLA/UNITY Initializing Highway");
#if UNITY_ANDROID 
			//&& !UNITY_EDITOR
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaHighwayClass = new AndroidJavaClass("com.soomla.highway.SoomlaHighway")) {

				AndroidJavaObject jniSoomlaHighwayInstance = jniSoomlaHighwayClass.CallStatic<AndroidJavaObject>("getInstance");
				jniSoomlaHighwayInstance.Call("initialize", HighwaySettings.HighwayGameKey, HighwaySettings.HighwayEnvKey);

				// Uncomment this and change the URL for testing
//				using(AndroidJavaObject jniConfigObject = jniSoomlaHighwayInstance.Call<AndroidJavaObject>("getConfig")) {
//					jniConfigObject.Call("setUrl", "http://example.com");
//				}

				jniSoomlaHighwayInstance.Call("start");
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
#elif UNITY_IOS
			//&& !UNITY_EDITOR
			soomlaHighway_initialize(HighwaySettings.HighwayGameKey, HighwaySettings.HighwayEnvKey);

			// Uncomment this and change the URL for testing
			// soomlaHighway_setUrl("http://example.com");

			soomlaHighway_start();
#endif
		}

		public static void StartDurationNagger() {
			SoomlaUtils.LogDebug (TAG, "SOOMLA/UNITY Starting Duration Nagger");
#if UNITY_ANDROID 
			//&& !UNITY_EDITOR
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaHighwayClass = new AndroidJavaClass("com.soomla.highway.SoomlaHighway")) {
				AndroidJavaObject jniSoomlaHighwayInstance = jniSoomlaHighwayClass.CallStatic<AndroidJavaObject>("getInstance");
				jniSoomlaHighwayInstance.Call("startDurationNagger");
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
#elif UNITY_IOS 
			//&& !UNITY_EDITOR
			soomlaHighway_startDurationNagger();
#endif
		}

		public static void StopDurationNagger() {
			SoomlaUtils.LogDebug (TAG, "SOOMLA/UNITY Stopping Duration Nagger");
#if UNITY_ANDROID 
			//&& !UNITY_EDITOR
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaHighwayClass = new AndroidJavaClass("com.soomla.highway.SoomlaHighway")) {
				AndroidJavaObject jniSoomlaHighwayInstance = jniSoomlaHighwayClass.CallStatic<AndroidJavaObject>("getInstance");
				jniSoomlaHighwayInstance.Call("stopDurationNagger");
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
#elif UNITY_IOS 
			//&& !UNITY_EDITOR
			soomlaHighway_stopDurationNagger();
#endif
		}


		/// <summary> Class Members </summary>

		private const string TAG = "SOOMLA SoomlaHighway";

	}
}
