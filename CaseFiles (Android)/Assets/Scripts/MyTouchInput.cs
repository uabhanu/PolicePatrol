using System;
using System.Collections;
//using TouchScript.Gestures;
using UnityEngine;

public class MyTouchInput : MonoBehaviour
{
	private float timeToPress;
	private Vector2 firstFingerPos , lastFingerPos , startPos;

	//public int levelNo;
	//public float minSwipeDistY;
	//public float minSwipeDistX;
	public PoliceController policeControlScript;
	public Transform police;

    //public PressGesture     m_myPressGesture;
    //public ReleaseGesture   m_myReleaseGesture;
    //public LongPressGesture m_myLongPressGesture;

    public bool m_hasTouched = false;
    public bool m_hasReleased = false;
    public double m_touchBeganTime = 0f;
    public TouchInfo m_touchInfo;


	private void Awake()
	{
		//policeControlScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PoliceController>();
	}
	
	private void OnEnable()
	{
        //timeToPress = m_myLongPressGesture.TimeToPress;
        //
        //m_myPressGesture.Pressed += PressedHandler;
        //m_myReleaseGesture.Released += ReleasedHandler;
        //m_myLongPressGesture.StateChanged += LongPressStateChangedHandler;
	}
	
	private void OnDisable()
	{
        //m_myPressGesture.Pressed -= PressedHandler;
        //m_myReleaseGesture.Released -= ReleasedHandler;
        //m_myLongPressGesture.StateChanged -= LongPressStateChangedHandler;
	}
	
	#region Touch Held Logic
// 	private void LongPressStateChangedHandler(object sender, GestureStateChangeEventArgs e)
// 	{
// // 		switch(e.State)
// // 		{
// // 			case Gesture.GestureState.Recognized:
// //                 Debug.Log("Touch Held");
// //                 //Application.LoadLevel("LevelSelection");
// //                 //policeControlScript.PerformMovement();
// //                 //SendMessage("Touched", new Vector2());
// //                 break;
// // 			case Gesture.GestureState.Failed:
// // 			case Gesture.GestureState.Cancelled:
// // 				Debug.Log("Touch Not Recognized");
// // 			break;
// // 		}
// 	}
	#endregion
	
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

		#region Swipe Logic
		foreach(Touch touch in Input.touches)
		{
			if(touch.phase == TouchPhase.Began)
			{
				firstFingerPos = touch.position;
				lastFingerPos = touch.position;
                if(!m_hasTouched)
                {
                    m_hasTouched = true;
                    m_touchBeganTime = Time.deltaTime;
                }
                m_touchInfo.touchBeganTime = m_touchBeganTime;
                m_touchInfo.touchPosition = firstFingerPos;
                SendMessage("Touched", m_touchInfo);
			}

			if(touch.phase == TouchPhase.Moved)
			{
				lastFingerPos = touch.position;
			}

			if(touch.phase == TouchPhase.Ended)
			{
                if (m_hasTouched)
                {
                    m_hasTouched = false;
                    m_touchBeganTime = Time.deltaTime;
                }
                SendMessage("TouchReleased");

                if((firstFingerPos.x - lastFingerPos.x) > 80) // left swipe
				{
                    SendMessage("SwipeLeft");
				}

				else if((firstFingerPos.x - lastFingerPos.x) < -80) // right swipe
				{
                    SendMessage("SwipeRight");
				}

				else if((firstFingerPos.y - lastFingerPos.y) < -80 ) // up swipe
				{
					//Application.LoadLevel("LevelSelection");
					//policeControlScript.PerformJump();
                    SendMessage("SwipeUp");
				}

				else if((firstFingerPos.y - lastFingerPos.y) > 80) //down swipe
				{
					//Application.Quit();
                    SendMessage("SwipeDown");
				}


			}
		}
		#endregion
	}
}