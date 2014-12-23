using UnityEngine;
using System.Collections;

public class PoliceController : MonoBehaviour 
{
    //---------------------------------------------------------------------------------------------------
    public enum PlayerState
    {
        IDLE,
        RUN,
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
    public float m_moveSpeed;
    public float m_jumpHeight;
    public bool  m_isMoving = false;
    public bool  m_isMovingLeft = false;
    public bool  m_isMovingRight = false;
    public bool  m_isFacingRight = true;
    public bool  m_shouldFlip = false;
    public bool  m_isGrounded = false;
    public Transform m_groundCheckTransform;
    public LayerMask m_groundLayerMask;
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    public AudioSource  m_myAudioSource;
    public AudioClip    m_jumpSound;
    public AudioClip    m_thighSlapSound;
    public AudioClip    m_caughtSound;
    public AudioClip    m_levelWonSound;
    public AudioClip    m_levelLostSound;
    public AudioClip    m_pickupSound;
    //---------------------------------------------------------------------------------------------------


    //---------------------------------------------------------------------------------------------------
	void Start () 
    {
        m_currentState = PlayerState.IDLE;
        m_previousState = m_currentState;

        m_groundLayerMask = 1 << 8;
	}
	//---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
	void Update () 
    {
        CheckIfGrounded();
        CheckInput();
        ProcessInput();
        UpdateStateMachine();
        UpdateAnimations();
        ClearFlags();
	}
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void CheckIfGrounded()
    {
        
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

    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void UpdateStateMachine()
    {
        
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void UpdateAnimations()
    {

    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void SetState(PlayerState newState)
    {
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
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
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
        
    }
    //---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
    private void FlipPlayer()
    {
        // Switch the way the player is labelled as facing.
        m_isFacingRight = !m_isFacingRight;

        // Multiply the player's x local scale by -1.
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
}
