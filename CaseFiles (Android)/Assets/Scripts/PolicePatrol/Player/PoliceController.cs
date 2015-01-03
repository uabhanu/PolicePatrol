using System.Collections;
//using TouchScript;
using UnityEngine;

public class PoliceController : MonoBehaviour 
{
    //---------------------------------------------------------------------------------------------------
    public enum PlayerState
    {
        IDLE,
        MOVING,
        SLAP,
        DYING,
        DEAD,
        LiftDown,
		InLift,
		LiftUp
    };

    public PlayerState m_currentState;
    public PlayerState m_previousState;
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    public float m_moveSpeed  = 5f;
    public float m_jumpHeight = 10f;
    //---------------------------------------------------------------------------------------------------
    public bool  m_isMoving      = false;
    public bool  m_isMovingLeft  = false;
    public bool  m_isMovingRight = false;
    private bool  m_isGoingUp     = false;
    private bool  m_isGoingDown   = false;
    //---------------------------------------------------------------------------------------------------
    private bool  m_isFacingRight = true;
   // private bool  m_shouldFlip    = false;
   //---------------------------------------------------------------------------------------------------
	public Transform  m_groundCheckTransform;
    public LayerMask m_groundLayerMask;
    public float      m_radiusToCheckGround = 0.02f;
    public bool       m_isGrounded = false;
    public float      m_groundCheckOffSet = 1f;
    //---------------------------------------------------------------------------------------------------
    private float xInput = 0f;
    //private float yInput = 0f;
    //---------------------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------------------
    public AudioSource  m_myAudioSource;
    public AudioClip    m_jumpSound;
    public AudioClip    m_thighSlapSound;
    public AudioClip    m_caughtSound;
    public AudioClip    m_levelWonSound;
    public AudioClip    m_levelLostSound;
    public AudioClip    m_pickupSound;
    private bool m_touchHeld;
    public float m_touchDeadZone;
    public float debugTouchDistance;
    public bool m_hasReachedTargetPosition = false;
	public Animator anim;
    //---------------------------------------------------------------------------------------------------

    public int dubug_CollisionCount = 0;
    public bool m_touchReleased;
    private Vector3 m_mountPosition;
    private Vector3 m_targetPosition;
    private GameObject m_liftReference;
    public float m_liftSpeed = 0.5f;
    //---------------------------------------------------------------------------------------------------
	void Start () 
    {
        m_groundCheckTransform.position = new Vector3(transform.position.x , transform.position.y - m_groundCheckOffSet);

        m_currentState = PlayerState.IDLE;
        m_previousState = m_currentState;

        //m_groundLayerMask = 1 << 12;

		anim = GetComponent<Animator>();
	}
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
	void OnTriggerEnter2D(Collider2D col2D)
	{
		
	}
	//---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    void OnTriggerStay2D(Collider2D col2D)
    {
        if (col2D.gameObject.tag.Equals("Lift"))
        {
            if (m_currentState == PlayerState.IDLE)
            {
                SetState(PlayerState.InLift);
                m_mountPosition.x = col2D.transform.position.x;
                m_mountPosition.y = transform.position.y;
                m_mountPosition.z = transform.position.z;

                m_liftReference = col2D.gameObject;
            }
        }
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
	void Update () 
    {
        //CheckInput();
        //ProcessInput();
        UpdateStateMachine();
        UpdateAnimations();
        ClearFlags();
	}
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    void FixedUpdate()
    {
        m_groundCheckTransform.position = new Vector3(transform.position.x , transform.position.y - m_groundCheckOffSet);
        CheckIfGrounded();
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void CheckIfGrounded()
    {
        if(!m_isGoingUp || !m_isGoingDown)
        {
            m_isGrounded = Physics2D.OverlapCircle(m_groundCheckTransform.position , m_radiusToCheckGround , m_groundLayerMask);
        }
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void CheckInput()
    {
        CheckKeyboardAndControllerInput();
        CheckTouchInput();
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void ProcessInput()
    {
        if (m_isMoving)
        {
            if(xInput != 0)
            {
                SetState(PlayerState.MOVING);
            }
            else
            {
                m_isMoving = false;
                SetState(PlayerState.IDLE);
            }
        }
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void UpdateStateMachine()
    {
        switch (m_currentState)
        {
            case PlayerState.IDLE: 
                PerformIdle();
        	break;

            case PlayerState.MOVING: 
                PerformMovement();
        	break;

            case PlayerState.LiftDown: 
                PerformFall();
        	break;

            case PlayerState.SLAP: 
                PerformThighSlap();
        	break;

            case PlayerState.DYING: 
                PerformDying();
        	break;

            case PlayerState.DEAD: 
                PerformDeath();
        	break;

			case PlayerState.InLift:
				PerformInLift();
			break;

			case PlayerState.LiftUp:
				PerformClimb();
			break;
        }
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void UpdateAnimations()
    {
        switch (m_currentState)
        {
            case PlayerState.IDLE: break;
            case PlayerState.MOVING: break;
            case PlayerState.LiftUp: break;
            case PlayerState.LiftDown: break;
            case PlayerState.SLAP: break;
            case PlayerState.DYING: break;
            case PlayerState.DEAD: break;
        }
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void SetState(PlayerState newState)
    {
        if (m_currentState == newState)
        {
            return;
        }

        m_previousState = m_currentState;
        m_currentState = newState;
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private PlayerState GetState()
    {
        return m_currentState;
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void CheckKeyboardAndControllerInput()
    {
        xInput = Input.GetAxis("Horizontal");
        //yInput = Input.GetAxis("Vertical");

        if (xInput != 0)
        {
            m_isMoving = true;

            if (xInput > 0)
            {
                m_isMovingRight = true;

                if (!m_isFacingRight)
                {
                    FlipPlayer();
                }

                m_isMovingLeft = false;
            }

            else if (xInput < 0)
            {
                m_isMovingLeft = true;

                if (m_isFacingRight)
                {
                    FlipPlayer();
                }

                m_isMovingRight = false;
            }
        }
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void CheckTouchInput()
    {
//        if(TouchScript.Gestures.LongPressGesture.GestureState.Began)
//		{
//			Debug.Log("Touch Held");
//		}
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void FlipPlayer()
    {
        m_isFacingRight = !m_isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void ClearFlags()
    {
        if (!m_isMoving)
        {
            m_isMovingLeft = false;
            m_isMovingRight = false;
        }
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void PerformIdle()
    {
        rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);
        m_isMoving = false;
    }
    //---------------------------------------------------------------------------------------------------
    
    //---------------------------------------------------------------------------------------------------
    public void PerformMovement()
    {
        if (!m_isMoving || m_hasReachedTargetPosition)
        {
            SetState(PlayerState.IDLE);
            return;
        }

        if (m_isMovingRight)
        {
            if(!m_isFacingRight)
            {
                FlipPlayer();
            }

            rigidbody2D.velocity = new Vector2(m_moveSpeed , rigidbody2D.velocity.y);
        }

        else if (m_isMovingLeft)
        {
            if (m_isFacingRight)
            {
                FlipPlayer();
            }
            rigidbody2D.velocity = new Vector2(-m_moveSpeed , rigidbody2D.velocity.y);
        }

        else
        {
            m_isMoving = false;
            return;
        }

    }
   
	public void PerformInLift()
	{
		anim.SetInteger("AnimIndex" , 5);
        transform.position = m_mountPosition;
        rigidbody2D.velocity = new Vector2(0f, 0f);
        if (m_isGoingUp)
        {
            SetState(PlayerState.LiftUp);
            m_targetPosition.x = transform.position.x;
            m_targetPosition.y = transform.position.y + m_jumpHeight;
            m_targetPosition.z = transform.position.z;
        }
        else if (m_isGoingDown)
        {
            SetState(PlayerState.LiftDown);
            m_targetPosition.x = transform.position.x;
            m_targetPosition.y = transform.position.y - m_jumpHeight;
            m_targetPosition.z = transform.position.z;
        }
	}

	//---------------------------------------------------------------------------------------------------
	public void PerformClimb()
    {
        if (transform.position.y - m_targetPosition.y > -m_touchDeadZone)
        {
            SetState(PlayerState.IDLE);
            m_isGoingUp = false;
            rigidbody2D.velocity = new Vector2(0f, 0f);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, m_liftSpeed);
            m_liftReference.transform.position = new Vector3(m_liftReference.transform.position.x, transform.position.y, m_liftReference.transform.position.z);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, m_liftSpeed);
        }
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    public void PerformFall()
    {
        if (transform.position.y - m_targetPosition.y < m_touchDeadZone || m_isGrounded)
        {
            SetState(PlayerState.IDLE);
            m_isGoingDown = false;
            rigidbody2D.velocity = new Vector2(0f, 0f);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -m_liftSpeed);
            m_liftReference.transform.position = new Vector3(m_liftReference.transform.position.x, transform.position.y, m_liftReference.transform.position.z);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -m_liftSpeed);
        }
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void PerformThighSlap()
    {

    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void PerformDying()
    {

    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void PerformDeath()
    {

    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    public void TouchInput(TouchInfo touchInfo)
    {
        SriTouchGestures gesture = touchInfo.touchGesture;
        m_touchReleased = false;
        switch(gesture)
        {
            case SriTouchGestures.SRI_NONE:
                break;
            case SriTouchGestures.SRI_SWIPEDLEFT:
                //SwipedLeft();
                break;
            case SriTouchGestures.SRI_SWIPEDRIGHT:
                //SwipedRight();
                break;
            case SriTouchGestures.SRI_SWIPEDUP:
                if(m_currentState == PlayerState.InLift)
                {
                    m_isGoingUp = true;
                }
                break;
            case SriTouchGestures.SRI_SWIPEDDOWN:
                if (m_currentState == PlayerState.InLift)
                {
                    m_isGoingDown = true;
                }
                break;
            case SriTouchGestures.SRI_DOUBLETAPPED:
                //DoubleTapped();
                break;
            case SriTouchGestures.SRI_TAPPED:
                break;
            case SriTouchGestures.SRI_TAPHELD:
                m_touchHeld = true;
                TouchHeld(touchInfo);
                break;
            case SriTouchGestures.SRI_RELEASED:
                TouchReleased();
                break;
        }
    }
    //---------------------------------------------------------------------------------------------------
   
    //---------------------------------------------------------------------------------------------------
    public void TouchHeld(TouchInfo touchInfo)
    {
        debugTouchDistance = touchInfo.touchPosition.x - transform.position.x;
        
                if(m_touchHeld && !m_hasReachedTargetPosition)
                {
                    m_isMoving = true;
                    SetState(PlayerState.MOVING);
                    if (debugTouchDistance > m_touchDeadZone)
                    {
                        m_isMovingRight = true;
                        m_isMovingLeft = false;
                    }
                    else if (debugTouchDistance < -m_touchDeadZone)
                    {
                        m_isMovingLeft = true;
                        m_isMovingRight = false;
                    }
                    else
                    {
                        m_hasReachedTargetPosition = true;
                    }

                    anim.SetInteger("AnimIndex", 2);
                }

    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    public void TouchReleased()
    {
        m_touchReleased = true;
        if(m_touchHeld)
        {
            m_touchHeld = false;
            SetState(PlayerState.IDLE);
            m_hasReachedTargetPosition = false;
			anim.SetInteger("AnimIndex" , 0);
        }
    }
    //---------------------------------------------------------------------------------------------------	
}
