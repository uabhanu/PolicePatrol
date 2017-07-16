using UnityEngine;
using System.Collections;


public class SriTouchInputListener : MonoBehaviour
{
	#region Events
	public delegate void TouchEvent(TouchInfo touchInfo);
	public event TouchEvent Tap;
	public event TouchEvent DoubleTap;
	public event TouchEvent Held;
	public event TouchEvent Released;
	public event TouchEvent SwipedRight;
	public event TouchEvent SwipedLeft;
	public event TouchEvent SwipedUp;
	public event TouchEvent SwipedDown;
	#endregion

	#region Private
	private bool m_registeredInputEvents    = false;
	private bool m_calledOnHeld             = false;
	#endregion

	#region Private Methods
	void Start()
	{
		RegisterInputEvents();
    }

	void OnDestoy()
	{
		UnregisterInputEvents();
	}
	#endregion

	#region Event Registations
	private void RegisterInputEvents()
	{
		if (!m_registeredInputEvents)
		{
			SriTouchInputManager.Instance.Tapped        += OnTapped;
			SriTouchInputManager.Instance.DoubleTapped  += OnDoubleTapped;
			SriTouchInputManager.Instance.TapHeld       += OnTapHeld;
			SriTouchInputManager.Instance.Released      += OnReleased;
			SriTouchInputManager.Instance.Swiped        += OnSwiped;
			m_registeredInputEvents                      = true;
		}
	}

	private void UnregisterInputEvents()
	{
		if (m_registeredInputEvents)
		{
			SriTouchInputManager.Instance.Tapped        -= OnTapped;
			SriTouchInputManager.Instance.DoubleTapped  -= OnDoubleTapped;
			SriTouchInputManager.Instance.TapHeld       -= OnTapHeld;
			SriTouchInputManager.Instance.Released      -= OnReleased;
			SriTouchInputManager.Instance.Swiped        -= OnSwiped;
			m_registeredInputEvents                      = false;
		}
	}
	#endregion

	#region Event Handlers
	private void OnTapped(TouchInfo touchInfo)
	{
		if (Tap != null)
		{
            Tap(touchInfo);
		}
	}

	private void OnDoubleTapped(TouchInfo touchInfo)
	{
		if (DoubleTap != null)
		{
			DoubleTap(touchInfo);
		}
	}

	private void OnTapHeld(TouchInfo touchInfo)
	{
		if (Held != null && !m_calledOnHeld)
		{
			Held(touchInfo);
			m_calledOnHeld = true;
		}
	}

	private void OnReleased(TouchInfo touchInfo)
	{
		m_calledOnHeld = false;
		if (Released != null)
		{
			Released(touchInfo);
		}
	}

	private void OnSwiped(TouchInfo touchInfo)
	{
		switch(touchInfo.touchGesture)
		{
			case SriTouchGestures.SRI_SWIPEDRIGHT:
				if (SwipedRight != null)
				{
					SwipedRight(touchInfo);
				}
				break;
			case SriTouchGestures.SRI_SWIPEDLEFT:
				if (SwipedLeft != null)
				{
					SwipedLeft(touchInfo);
				}
				break;
			case SriTouchGestures.SRI_SWIPEDUP:
				if (SwipedUp != null)
				{
					SwipedUp(touchInfo);
				}
				break;
			case SriTouchGestures.SRI_SWIPEDDOWN:
				if (SwipedDown != null)
				{
					SwipedDown(touchInfo);
				}
				break;
		}
	}
	#endregion
}
