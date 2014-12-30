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
        JUMP,
        SLAP,
        DYING,
        DEAD,
        FALLING
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
    private LayerMask m_groundLayerMask;
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


    //---------------------------------------------------------------------------------------------------
	void Start () 
    {
        m_groundCheckTransform.position = new Vector3(transform.position.x , transform.position.y - m_groundCheckOffSet);

        m_currentState = PlayerState.IDLE;
        m_previousState = m_currentState;

        m_groundLayerMask = 1 << 8;

		anim = GetComponent<Animator>();
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
        if (m_isGoingUp)
        {
            SetState(PlayerState.JUMP);
        }
        else if (m_isGoingDown)
        {
            SetState(PlayerState.FALLING);
        }
        else if (m_isMoving)
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

            case PlayerState.JUMP: 
                PerformJump();
        	break;

            case PlayerState.FALLING: 
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
            case PlayerState.JUMP: break;
            case PlayerState.FALLING: break;
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
        if (rigidbody2D.velocity.x != 0f)
        {
            rigidbody2D.velocity = new Vector2(0f , rigidbody2D.velocity.y);
            m_isMoving = false;
        }
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
    //---------------------------------------------------------------------------------------------------
    public void PerformJump()
    {
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x , m_jumpHeight);
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    public void PerformFall()
    {
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x , -m_jumpHeight);
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
                m_isGoingUp = true;
                break;
            case SriTouchGestures.SRI_SWIPEDDOWN:
                m_isGoingDown = true;
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

			anim.SetInteger("AnimIndex" , 2);
            SetState(PlayerState.MOVING);
        }
        
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    public void TouchReleased()
    {
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
