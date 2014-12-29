using UnityEngine;
using System.Collections;

//---------------------------------------------------------------------------------------------------
public enum SriTouchGestures
{
    SRI_TAPPED,
    SRI_DOUBLETAPPED,
    SRI_TAPHELD,
    SRI_RELEASED,
    SRI_SWIPEDRIGHT,
    SRI_SWIPEDLEFT,
    SRI_SWIPEDUP,
    SRI_SWIPEDDOWN,
    SRI_NONE,
}
//---------------------------------------------------------------------------------------------------

public struct TouchInfo
{
    public double touchBeganTime;
    public Vector2 touchPosition;
    public SriTouchGestures touchGesture;
};

//---------------------------------------------------------------------------------------------------
public class SriTouchInputManager : MonoBehaviour 
{
    public float m_doubleTapDelay = 0.15f;
    //---------------------------------------------------------------------------------------------------
    public bool m_isIPhone = false;
    public bool m_hasTouched = false;
    public bool m_hasReleased = false;
    public Vector2 m_currentTouchPosition;
    public Vector2 m_firstTouchPosition;
    public float m_firstTouchTime = 0f;
    public float m_secondTouchTime = 0f;
    public bool m_tapped = false;
    public bool m_doubleTapped = false;
    public bool m_swipedLeft = false;
    public bool m_swipedRight = false;
    public bool m_swipedUp = false;
    public bool m_swipedDown = false;
    public SriTouchInputListener[] m_sriTouchListeners;
    public TouchInfo m_touchInfo;
    public float m_touchHeldTime = 0.20f;
    public bool m_touchHeld = false;
    public bool m_touchProcessed = false;
    public bool m_checkedDoubleTap = false;
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
	void Start () 
    {
        m_isIPhone = (Application.platform == RuntimePlatform.IPhonePlayer);

        m_touchInfo.touchGesture = SriTouchGestures.SRI_NONE;

        m_sriTouchListeners = GameObject.FindObjectsOfType<SriTouchInputListener>();
    }
	//---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
	void Update () 
    {
	    if(m_isIPhone)
        {
            RecieveIPhoneTouchInput();
        }
        else
        {
            RecieveOtherTouchInput();
        }

        ProcessTouchInput();
        if(m_sriTouchListeners.Length == 0)
        {
            m_sriTouchListeners = GameObject.FindObjectsOfType<SriTouchInputListener>();
        }
	}
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void ProcessTouchInput()
    {
        if(!m_touchProcessed && m_touchInfo.touchGesture != SriTouchGestures.SRI_NONE)
        {
            m_touchProcessed = true;
            int index = -1;
            while (++index < m_sriTouchListeners.Length )
            {
                m_sriTouchListeners[index].TouchInputListener(m_touchInfo);
            }
            m_touchInfo.touchGesture = SriTouchGestures.SRI_NONE;
        }
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void RecieveIPhoneTouchInput()
    {
          m_hasTouched = (Input.touchCount > 0);
          m_currentTouchPosition = Input.touches[0].position;
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void RecieveOtherTouchInput()
    {
        if(!m_hasTouched)
        {
            m_hasTouched = Input.GetMouseButton(0);
            if(m_hasTouched)
            {
                Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                m_firstTouchPosition = new Vector2(screenToWorld.x, screenToWorld.y);
                m_currentTouchPosition = m_firstTouchPosition;
                m_touchInfo.touchPosition = m_currentTouchPosition;
                m_firstTouchTime = Time.time;
                m_touchInfo.touchBeganTime = m_firstTouchTime;

                if(m_tapped)
                {
                    if(m_hasReleased && Time.time - m_firstTouchTime < m_doubleTapDelay)
                    {
                        m_tapped = false;
                        m_doubleTapped = true;
                    }
                    m_checkedDoubleTap = true;
                }
                else
                {
                    m_tapped = true;
                }
            }
            else
            {
                if(m_tapped)
                {
                    m_tapped = false;
                    m_doubleTapped = false;
                }
            }
        }
        else
        {
            m_hasReleased = false;

            Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            m_currentTouchPosition = new Vector2(screenToWorld.x, screenToWorld.y);
            m_touchInfo.touchPosition = m_currentTouchPosition;

            if(Time.time - m_firstTouchTime > m_touchHeldTime)
            {
                m_touchHeld = true;
                m_touchProcessed = false;
                m_touchInfo.touchGesture = SriTouchGestures.SRI_TAPHELD;
            }
        }

        if(!m_hasReleased)
        {
            m_hasReleased = Input.GetMouseButtonUp(0);
            if(m_hasReleased && m_hasTouched)
            {
                m_hasTouched = false;
                m_hasReleased = false;
                m_touchProcessed = false;
                
                if(!m_tapped)
                {
                    m_tapped = true;
                }
                
                // Check Swipe
                if (m_touchHeld)
                {
                    m_touchHeld = false;
                    m_touchInfo.touchGesture = SriTouchGestures.SRI_RELEASED;
                }
                else
                {
                    float xDiff = m_firstTouchPosition.x - m_currentTouchPosition.x;
                    float yDiff = m_firstTouchPosition.y - m_currentTouchPosition.y;
                    bool horizontalSwipe = false;
                    bool verticalSwipe   = false;

                    if (xDiff > 0.5f || xDiff < -0.5f) // left swipe
                    {
                        horizontalSwipe = true;
                    }
                    if (yDiff > 0.5f || yDiff < -0.5f) // up swipe
                    {
                        verticalSwipe = true;
                    }

                    if(horizontalSwipe || verticalSwipe)
                    {
                        if(horizontalSwipe && verticalSwipe)
                        {
                            if(xDiff * xDiff >= yDiff * yDiff)
                            {
                                verticalSwipe = false;
                            }
                            else
                            {
                                horizontalSwipe = false;
                            }
                        }
                        
                        if(horizontalSwipe)
                        {
                            if(xDiff > 0f)
                            {
                                m_touchInfo.touchGesture = SriTouchGestures.SRI_SWIPEDLEFT;
                            }
                            else
                            {
                                m_touchInfo.touchGesture = SriTouchGestures.SRI_SWIPEDRIGHT;
                            }
                        }
                        else if(verticalSwipe)
                        {
                            if (yDiff > 0f)
                            {
                                m_touchInfo.touchGesture = SriTouchGestures.SRI_SWIPEDDOWN;
                            }
                            else
                            {
                                m_touchInfo.touchGesture = SriTouchGestures.SRI_SWIPEDUP;
                            }
                        }
                    }
                    else if (m_doubleTapped)
                    {
                        m_touchInfo.touchGesture = SriTouchGestures.SRI_DOUBLETAPPED;
                        m_checkedDoubleTap = false;
                    }
                    else if (m_tapped && m_checkedDoubleTap)
                    {
                        m_touchInfo.touchGesture = SriTouchGestures.SRI_TAPPED;
                        m_tapped = false;
                        m_checkedDoubleTap = false;
                    }
                    else
                    {
                        m_touchInfo.touchGesture = SriTouchGestures.SRI_NONE;
                    }
                }
                
                m_touchInfo.touchPosition = m_currentTouchPosition;            
            }
        }
        else
        {
            if(Time.time - m_firstTouchTime >= m_doubleTapDelay)
            {
                m_checkedDoubleTap = true;
            }
        }
       
    }
    //---------------------------------------------------------------------------------------------------

}
