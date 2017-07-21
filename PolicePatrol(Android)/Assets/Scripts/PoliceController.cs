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

    bool m_isFacingRight , m_isMovingLeft , m_isMovingRight , m_registeredInputEvents , m_tapped , m_tappedLeft , m_tappedRight , m_touchReleased;
    public bool m_coverBlown , m_isVisible;
    [SerializeField] float m_walkSpeed , m_runSpeed;
    float m_xInput = 0f;
    Rigidbody2D m_copBody2D;
    [SerializeField] SpriteRenderer m_copRenderer;
    [SerializeField] SriTouchInputListener m_touchInputListener;
    Vector2 m_firstTouchPosition;

    private void Reset()
    {
        m_runSpeed = 2.0f;
        m_walkSpeed = 1.25f;
    }

    private void Start()
    {
        m_copBody2D = GetComponent<Rigidbody2D>();
        m_copRenderer = GetComponent<SpriteRenderer>();
        m_isFacingRight = true;
        m_isMovingLeft = false;
        m_isMovingRight = true;
        RegisterEvents();
        SetState(PlayerState.IDLE);
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

    private PlayerState GetState()
	{
		return m_currentState;
	}

    void Idle()
    {
        m_copBody2D.velocity = new Vector2(0f , m_copBody2D.velocity.y);
    }

    private void OnDestroy()
    {
        UnregisterEvents();
    }

    void OnTapped(TouchInfo touchInfo)
    {
        Debug.Log("Tapped");

        if(!m_coverBlown)
        {
            if (m_currentState != PlayerState.WALK)
            {
                SetState(PlayerState.WALK);
            }

            else if (m_currentState == PlayerState.WALK)
            {
                SetState(PlayerState.IDLE);
            }
        }

        else if(m_coverBlown) //Figure out a way to make this true as you can't use Thug Classes
        {
            if (m_currentState != PlayerState.RUN)
            {
                SetState(PlayerState.RUN);
            }
        }
        
        Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		m_firstTouchPosition = new Vector2(screenToWorld.x , screenToWorld.y);

        if(screenToWorld.x < m_copBody2D.position.x)
        {
            //Debug.Log("Left to Constable");
            m_isMovingLeft = true;
            m_isMovingRight = false;
        }

        else if(screenToWorld.x > m_copBody2D.position.x)
        {
           //Debug.Log("Right to Constable");
           m_isMovingLeft = false;
            m_isMovingRight = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col2DEnter)
    {
        if(col2DEnter.gameObject.tag.Equals("Light"))
        {
            m_isVisible = true;
            m_copRenderer.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D col2DExit)
    {
        if(col2DExit.gameObject.tag.Equals("Light"))
        {
            m_isVisible = false;
            m_copRenderer.color = Color.white;
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

    public void SetState(PlayerState newState)
	{
		if (m_currentState == newState)
		{
			return;
		}
		
		m_previousState = m_currentState;
		m_currentState = newState;
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
			
			m_copBody2D.velocity = new Vector2(m_walkSpeed , m_copBody2D.velocity.y);
		}
		
		else if(m_isMovingLeft)
		{
			if(m_isFacingRight)
			{
				Flip();
			}
			
			m_copBody2D.velocity = new Vector2(-m_walkSpeed , m_copBody2D.velocity.y);
		}
		
		else
		{
			return;
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
