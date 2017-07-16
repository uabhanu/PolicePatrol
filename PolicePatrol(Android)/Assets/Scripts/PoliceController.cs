using System.Collections;
using UnityEngine;

public class PoliceController : MonoBehaviour 
{
    public enum PlayerState
	{
		ATTACK,
		BLEND,
		CROUCH,
		CROUCHMOVE,
		DEAD,
		DYING,
		IDLE,
		RUN,
		SLAP,
		WALK,
	};
	
	public PlayerState m_currentState;
	public PlayerState m_previousState;

    bool m_isFacingRight , m_isMoving , m_isMovingRight , m_registeredInputEvents , m_tapped , m_touchReleased;
    [SerializeField] float m_walkSpeed , m_runSpeed;
    float m_xInput = 0f;
    [SerializeField] Rigidbody2D m_policeBody2D;
    [SerializeField] SriTouchInputListener m_touchInputListener;

    private PlayerState GetState()
	{
		return m_currentState;
	}

    public void SetState(PlayerState newState)
	{
		if (m_currentState == newState)
		{
			return;
		}
		
		m_previousState = m_currentState;
		m_currentState = newState;
	}

    private void Start()
    {
        m_isFacingRight = true;
        SetState(PlayerState.IDLE);
        RegisterEvents();

    }

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        UpdateAnimations();
        UpdateStateMachine();
    }

    void Attack()
    {

    }

    void Blend()
    {

    }

    void Crouch()
    {

    }

    void CrouchWalk()
    {

    }

    void Death()
    {

    }

    void Dying()
    {

    }

    void Flip()
	{
		m_isFacingRight = !m_isFacingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    void Idle()
    {
        m_policeBody2D.velocity = new Vector2(0f , 0f);
    }

    private void OnDestroy()
    {
        UnregisterEvents();
    }

    void OnTapped(TouchInfo touchInfo)
    {
        Debug.Log("Tapped");

        if(!m_isMoving)
        {
            m_isMoving = true;
            SetState(PlayerState.WALK);
        }

        if(m_isMoving)
        {
            m_isMoving = false;
            SetState(PlayerState.IDLE);
        }
    }

    void RegisterEvents()
    {
        if(!m_registeredInputEvents && m_touchInputListener)
		{
			m_touchInputListener.Tap += OnTapped;
            // Register more events later
			m_registeredInputEvents = true;
		}
    }

    void Run()
    {

    }

    void ThighSlap()
    {

    }

    public void TouchInput(TouchInfo touchInfo)
    {
        SriTouchGestures gesture = touchInfo.touchGesture;

        switch(gesture)
        {
            case SriTouchGestures.SRI_NONE:
                Debug.Log("Nothing Happened");
            break;

            case SriTouchGestures.SRI_SWIPEDLEFT:
                Debug.Log("Swiped Left");
            break;

            case SriTouchGestures.SRI_SWIPEDRIGHT:
                Debug.Log("Swiped Right");
            break;

            case SriTouchGestures.SRI_SWIPEDUP:
                Debug.Log("Swiped Up");
            break;

            case SriTouchGestures.SRI_SWIPEDDOWN:
                Debug.Log("Swiped Down");
            break;

            case SriTouchGestures.SRI_DOUBLETAPPED:
                Debug.Log("Double Tapped");
            break;

            case SriTouchGestures.SRI_TAPHELD:
                Debug.Log("Tap Held");
            break;

            case SriTouchGestures.SRI_RELEASED:
                Debug.Log("Touch Released");
                m_tapped = false;
            break;

            case SriTouchGestures.SRI_TAPPED:
                Debug.Log("Tapped");
                m_tapped = true;
            break;
        }
    }

    void UnregisterEvents()
    {
        if(m_registeredInputEvents)
		{
			if(m_touchInputListener)
            {
                m_touchInputListener.Tap -= OnTapped;
            }
            
            // Unregister more events later
			m_registeredInputEvents = false;
		}
    }

    void Walk()
    {
        if(m_isMovingRight)
		{
			if(!m_isFacingRight)
			{
				Flip();
			}
			
			m_policeBody2D.velocity = new Vector2(m_walkSpeed , m_policeBody2D.velocity.y);
		}
		
		else if(!m_isMovingRight)
		{
			if(m_isFacingRight)
			{
				Flip();
			}
			
			m_policeBody2D.velocity = new Vector2(-m_walkSpeed , m_policeBody2D.velocity.y);
		}
    }

    private void UpdateAnimations()
	{
		switch(m_currentState)
		{
			case PlayerState.ATTACK: break;
			case PlayerState.BLEND: break;
			case PlayerState.CROUCH: break;
			case PlayerState.CROUCHMOVE: break;
			case PlayerState.DEAD: break;
			case PlayerState.DYING: break;
			case PlayerState.IDLE: break;
			case PlayerState.RUN: break;
			case PlayerState.SLAP: break;
			case PlayerState.WALK: break;
		}
	}

    private void UpdateStateMachine()
    {
	    switch(m_currentState)
	    {
		    case PlayerState.ATTACK:
			    Attack();
		    break;

		    case PlayerState.BLEND:
			    Blend();
		    break;
			
		    case PlayerState.CROUCH:
			    Crouch();
		    break;
			
		    case PlayerState.CROUCHMOVE:
			    CrouchWalk();
		    break;
			
		    case PlayerState.DEAD: 
			    Death();
		    break;
			
		    case PlayerState.DYING: 
			    Dying();
		    break;
			
		    case PlayerState.IDLE: 
			    Idle();
		    break;
			
		    case PlayerState.RUN:
			    Run();
		    break;
			
		    case PlayerState.SLAP: 
			    ThighSlap();
		    break;
			
		    case PlayerState.WALK: 
			    Walk();
		    break;
	    }
    }
}
