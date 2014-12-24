using System;
using System.Collections;
using TouchScript.Gestures;
using UnityEngine;

public class MyTouchInput : MonoBehaviour
{
	private float timeToPress;	
	public int levelNo;
	
	private void Awake()
	{

	}
	
	private void OnEnable()
	{
		timeToPress = GetComponent<LongPressGesture>().TimeToPress;
		
		GetComponent<PressGesture>().Pressed += PressedHandler;
		GetComponent<ReleaseGesture>().Released += ReleasedHandler;
		GetComponent<LongPressGesture>().StateChanged += LongPressStateChangedHandler;
	}
	
	private void OnDisable()
	{
		GetComponent<PressGesture>().Pressed -= PressedHandler;
		GetComponent<ReleaseGesture>().Released -= ReleasedHandler;
		GetComponent<LongPressGesture>().StateChanged -= LongPressStateChangedHandler;
	}
	
	private void LongPressStateChangedHandler(object sender, GestureStateChangeEventArgs e)
	{
		switch(e.State)
		{
			case Gesture.GestureState.Recognized:
			case Gesture.GestureState.Failed:
			case Gesture.GestureState.Cancelled:
				Debug.Log("Touch Not Recognized");
			break;
		}
		
		if(e.State == Gesture.GestureState.Recognized)
		{
			Debug.Log("Touch Held");

			if(levelNo == 1)
			{
				Application.LoadLevel("LevelSelection");
			}

			if(levelNo == 0)
			{
				Application.Quit();
			}
		}
	}
	
	private void PressedHandler(object sender, EventArgs e)
	{

	}
	
	private void ReleasedHandler(object sender, EventArgs e)
	{

	}

	void Update()
	{
		if(Time.timeScale == 0)
		{
			return;
		}

		levelNo = Application.loadedLevel;
	}
}