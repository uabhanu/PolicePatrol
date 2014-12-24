using System;
using System.Collections;
using TouchScript.Gestures;
using UnityEngine;

public class MyTouchInput : MonoBehaviour
{
	private float timeToPress;
	private Vector2 firstFingerPos , lastFingerPos , startPos;

	public int levelNo;
	public float minSwipeDistY;
	public float minSwipeDistX;
	public PoliceController policeControlScript;
	public Transform police;
	
	private void Awake()
	{
		policeControlScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PoliceController>();
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
			//Application.LoadLevel("LevelSelection");
			policeControlScript.PerformMovement();
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

		foreach(Touch touch in Input.touches)
		{
			if(touch.phase == TouchPhase.Began)
			{
				firstFingerPos = touch.position;
				lastFingerPos = touch.position;
			}

			if(touch.phase == TouchPhase.Moved)
			{
				lastFingerPos = touch.position;
			}

			if(touch.phase == TouchPhase.Ended)
			{
				if((firstFingerPos.x - lastFingerPos.x) > 80) // left swipe
				{

				}

				else if((firstFingerPos.x - lastFingerPos.x) < -80) // right swipe
				{

				}

				else if((firstFingerPos.y - lastFingerPos.y) < -80 ) // up swipe
				{
					//Application.LoadLevel("LevelSelection");
					policeControlScript.PerformJump();
				}

				else if((firstFingerPos.y - lastFingerPos.y) > 80) //down swipe
				{
					//Application.Quit();
				}
			}
		}
	}
}