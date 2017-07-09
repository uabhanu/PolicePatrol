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

    bool m_isFacingRight , m_isMovingRight;
    [SerializeField] float m_walkSpeed , m_runSpeed;
    [SerializeField] Rigidbody2D m_policeBody2D;

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
        m_isMovingRight = true;
    }

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

       if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetState(PlayerState.WALK);

        }

       if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetState(PlayerState.WALK);
        }

       if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            SetState(PlayerState.IDLE);

        }

       if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            SetState(PlayerState.IDLE);
        }

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

    void FlipPlayer()
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

    void Run()
    {

    }

    void ThighSlap()
    {

    }

    void Walk()
    {
        if(m_isMovingRight)
		{
			if(!m_isFacingRight)
			{
				FlipPlayer();
			}
			
			m_policeBody2D.velocity = new Vector2(m_walkSpeed , m_policeBody2D.velocity.y);
		}
		
		else if(!m_isMovingRight)
		{
			if(m_isFacingRight)
			{
				FlipPlayer();
			}
			
			m_policeBody2D.velocity = new Vector2(-m_walkSpeed , m_policeBody2D.velocity.y);
		}
    }

    private void UpdateStateMachine()
	{
		switch (m_currentState)
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
