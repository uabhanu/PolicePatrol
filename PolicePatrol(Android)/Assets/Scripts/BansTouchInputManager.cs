using UnityEngine;
using System.Collections;

//---------------------------------------------------------------------------------------------------
public enum BansTouchGestures
{
	Bans_TAPPED,
	Bans_DOUBLETAPPED,
	Bans_TAPHELD,
	Bans_RELEASED,
	Bans_SWIPEDRIGHT,
	Bans_SWIPEDLEFT,
	Bans_SWIPEDUP,
	Bans_SWIPEDDOWN,
	Bans_NONE,
}
//---------------------------------------------------------------------------------------------------

public struct TouchInfo
{
	public double           touchBeganTime;
	public Vector2          touchPosition;
	public BansTouchGestures touchGesture;
};

//---------------------------------------------------------------------------------------------------
public class BansTouchInputManager : MonoBehaviour 
{
	public delegate void TouchEvent(TouchInfo touchInfo);
	public event TouchEvent  Tapped;
	public event TouchEvent  DoubleTapped;
	public event TouchEvent  TapHeld;
	public event TouchEvent  Released;
	public event TouchEvent  Swiped;

    public static BansTouchInputManager Instance; //Singleton Instance

	[SerializeField] private float    m_doubleTapDelay    = 0.1f;
	[SerializeField] private float    m_touchHeldTime     = 0.20f;

	private Vector2     m_currentTouchPosition;
	private Vector2     m_firstTouchPosition;
	private float       m_firstTouchTime        = 0f;
	private float       m_secondTouchTime       = 0f;
	private TouchInfo   m_touchInfo;
	private bool        m_isIPhone              = false;
	private bool        m_hasTouched            = false;
	private bool        m_hasReleased           = false;
	private bool        m_tapped                = false;
	private bool        m_doubleTapped          = false;
	private bool        m_swipedLeft            = false;
	private bool        m_swipedRight           = false;
	private bool        m_swipedUp              = false;
	private bool        m_swipedDown            = false;
	private bool        m_touchHeld             = false;
	private bool        m_touchProcessed        = false;
	private bool        m_checkedDoubleTap      = false;

    void Awake()
    {
        Instance = this;
    }

	void Start () 
	{
		m_isIPhone = (Application.platform == RuntimePlatform.IPhonePlayer);

		m_touchInfo.touchGesture = BansTouchGestures.Bans_NONE;
	}

	void OnMouseDown()
	{

	}

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
	}

	private void ProcessTouchInput()
	{
		if(!m_touchProcessed && m_touchInfo.touchGesture != BansTouchGestures.Bans_NONE)
		{
			m_touchProcessed = true;

			switch (m_touchInfo.touchGesture)
			{
				case BansTouchGestures.Bans_TAPPED:
					if (Tapped != null)
					{
						Tapped(m_touchInfo);
					}
				break;

				case BansTouchGestures.Bans_DOUBLETAPPED:
					if (DoubleTapped != null)
					{
						DoubleTapped(m_touchInfo);
					}
				break;

				case BansTouchGestures.Bans_TAPHELD:
					if (TapHeld != null)
					{
						TapHeld(m_touchInfo);
					}
				break;

				case BansTouchGestures.Bans_RELEASED:
					if (Released != null)
					{
						Released(m_touchInfo);
					}
				break;

				case BansTouchGestures.Bans_SWIPEDRIGHT:
				case BansTouchGestures.Bans_SWIPEDLEFT:
				case BansTouchGestures.Bans_SWIPEDUP:

				case BansTouchGestures.Bans_SWIPEDDOWN:
					if (Swiped != null)
					{
						Swiped(m_touchInfo);
					}
				break;
			}

			m_touchInfo.touchGesture = BansTouchGestures.Bans_NONE;
		}
	}

	void RecieveIPhoneTouchInput()
	{
		m_hasTouched = (Input.touchCount > 0);

		if (m_hasTouched)
		{
			m_currentTouchPosition = Input.touches[0].position;
		}
		else
		{
			m_currentTouchPosition = Vector2.zero;
		}
	}

	void RecieveOtherTouchInput()
	{
		if(!m_hasTouched)
		{
			m_hasTouched = Input.GetMouseButton(0);

			if(m_hasTouched)
			{
				Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				m_firstTouchPosition = new Vector2(screenToWorld.x , screenToWorld.y);
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
				m_touchInfo.touchGesture = BansTouchGestures.Bans_TAPHELD;
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
					m_touchInfo.touchGesture = BansTouchGestures.Bans_RELEASED;
				}
				else
				{
					float xDiff = m_firstTouchPosition.x - m_currentTouchPosition.x;
					float yDiff = m_firstTouchPosition.y - m_currentTouchPosition.y;
					bool horizontalSwipe = false;
					bool verticalSwipe   = false;

					if (xDiff > 0.5f || xDiff < -0.5f)
					{
						horizontalSwipe = true;
					}
					if (yDiff > 0.5f || yDiff < -0.5f)
					{
						verticalSwipe = true;
					}

                    if(Time.time - m_firstTouchTime >= m_doubleTapDelay)
			        {
				        m_checkedDoubleTap = true;
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
								m_touchInfo.touchGesture = BansTouchGestures.Bans_SWIPEDLEFT; //Swipe Left
							}
							else
							{
								m_touchInfo.touchGesture = BansTouchGestures.Bans_SWIPEDRIGHT; //Swipe Right
							}
						}
						else if(verticalSwipe)
						{
							if (yDiff > 0f)
							{
								m_touchInfo.touchGesture = BansTouchGestures.Bans_SWIPEDDOWN; //Swipe Down
							}
							else
							{
								m_touchInfo.touchGesture = BansTouchGestures.Bans_SWIPEDUP; //Swipe Up
							}
						}
					}

					else if (m_doubleTapped)
					{
						m_touchInfo.touchGesture = BansTouchGestures.Bans_DOUBLETAPPED;
						m_checkedDoubleTap = false;
					}

					else if (m_tapped && m_checkedDoubleTap)
					{
						m_touchInfo.touchGesture = BansTouchGestures.Bans_TAPPED;
						m_tapped = false;
						m_checkedDoubleTap = false;
					}

					else
					{
						m_touchInfo.touchGesture = BansTouchGestures.Bans_NONE;
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
}
