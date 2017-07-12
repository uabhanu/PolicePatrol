using System.Collections;
using UnityEngine;

public class PoliceController : MonoBehaviour 
{
#region Player States
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
#endregion

#region Variables Decleration
    bool m_isFacingRight , m_isMoving , m_isMovingRight;
    [SerializeField] float m_walkSpeed , m_runSpeed;
    [SerializeField] Rigidbody2D m_policeBody2D;
    #endregion

#region Get State
    private PlayerState GetState()
	{
		return m_currentState;
	}
#endregion

#region Set State
    public void SetState(PlayerState newState)
	{
		if (m_currentState == newState)
		{
			return;
		}
		
		m_previousState = m_currentState;
		m_currentState = newState;
	}
#endregion

#region Start Method
    private void Start()
    {
        m_isFacingRight = true;
        m_isMovingRight = true;
    }
#endregion

#region Update Method
    private void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        UpdateAnimations();
        UpdateStateMachine();
    }
#endregion

#region Attack Method
    void Attack()
    {

    }
    #endregion

#region Blend Method
    void Blend()
    {

    }
    #endregion

#region Crouch Method
    void Crouch()
    {

    }
    #endregion

#region Crouch Walk Method
    void CrouchWalk()
    {

    }
    #endregion

#region Death Method
    void Death()
    {

    }
    #endregion

#region Dying Method
    void Dying()
    {

    }
    #endregion

#region Flip Method
    void Flip()
	{
		m_isFacingRight = !m_isFacingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    #endregion

#region Idle Method
    void Idle()
    {
        m_policeBody2D.velocity = new Vector2(0f , 0f);
    }
    #endregion

#region Run Method
    void Run()
    {

    }
    #endregion

#region Tapped Method
    public void Tapped(TouchInfo touchInfo)
	{
		m_isMoving = true;
		SetState(PlayerState.WALK);
    }
    #endregion

#region Thigh Slap Method
    void ThighSlap()
    {

    }
    #endregion

#region Walk Method
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
    #endregion

#region Update Animations Method
    private void UpdateAnimations()
	{
		switch (m_currentState)
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
    #endregion

    #region Update State Machine Method
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
#endregion
}
