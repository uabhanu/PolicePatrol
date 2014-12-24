using System;
using System.Collections;
using TouchScript.Gestures;
using UnityEngine;

public class MyTouchInput : MonoBehaviour
{
	private float timeToPress;
	
	private void Awake()
	{

	}
	
	private void OnEnable()
	{
		timeToPress = GetComponent<LongPressGesture>().TimeToPress;
		
		GetComponent<PressGesture>().Pressed += pressedHandler;
		GetComponent<ReleaseGesture>().Released += releasedHandler;
		GetComponent<LongPressGesture>().StateChanged += longPressStateChangedHandler;
	}
	
	private void OnDisable()
	{
		GetComponent<PressGesture>().Pressed -= pressedHandler;
		GetComponent<ReleaseGesture>().Released -= releasedHandler;
		GetComponent<LongPressGesture>().StateChanged -= longPressStateChangedHandler;
	}
	
	private void longPressStateChangedHandler(object sender, GestureStateChangeEventArgs e)
	{
		switch (e.State)
		{
			case Gesture.GestureState.Recognized:
			case Gesture.GestureState.Failed:
			case Gesture.GestureState.Cancelled:
				Debug.Log("Touch Not Recognized");
			break;
		}
		
		if (e.State == Gesture.GestureState.Recognized)
		{
			Debug.Log("Touch Held");
			Application.LoadLevel("LevelSelection");
		}
	}
	
	private void pressedHandler(object sender, EventArgs e)
	{

	}
	
	private void releasedHandler(object sender, EventArgs e)
	{

	}
}