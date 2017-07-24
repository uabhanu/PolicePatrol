using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thug : MonoBehaviour 
{
    public enum EnemyState
	{
		ATTACK,
        COPDISAPPEARED,
		DEAD,
		DYING,
		IDLE,
        RUN,
		WALK,
	};
	
	public EnemyState m_currentState;
	public EnemyState m_previousState;
	
    public bool m_copBlended , m_copVisible , m_isFacingRight , m_isMovingLeft , m_isMovingRight , m_isRunning , m_thugChasing , m_isWalking;
    public float m_flipTime , m_rayDistance , m_rayDistanceFromSelf , m_runSpeed , m_timeToGoBack , m_walkSpeed;
    protected PoliceController m_policeController;
    protected Rigidbody2D m_thugBody2D;
    protected Transform m_startPosition;

    void Start() 
    {
        
	}

    protected IEnumerator FlippingRoutine()
	{
		yield return new WaitForSeconds(m_flipTime);
            
        if(m_currentState == EnemyState.IDLE)
        {
            Flip();
			StartCoroutine("FlippingRoutine");
        }
	}

    protected void Attack()
    {

    }

    protected void Flip()
	{
		m_isFacingRight = !m_isFacingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    protected void Idle()
    {
        m_thugBody2D.velocity = new Vector2(0f , m_thugBody2D.velocity.y);

        if(m_isFacingRight)
			{
				RaycastHit2D hit2D = Physics2D.Raycast(new Vector2(transform.position.x + m_rayDistanceFromSelf , transform.position.y) , -transform.right , m_rayDistance);
				
				if(hit2D) 
				{
                    if(hit2D.collider.tag.Equals("Cop") && m_copVisible)
                    {
                        SetState(EnemyState.RUN);
                    }
				}
				
				Debug.DrawRay(new Vector2(transform.position.x + m_rayDistanceFromSelf , transform.position.y) , -transform.right * m_rayDistance , Color.red);
			}
			
			else if(!m_isFacingRight)
			{
				RaycastHit2D hit2D = Physics2D.Raycast(new Vector2(transform.position.x - m_rayDistanceFromSelf , transform.position.y) , transform.right , m_rayDistance);
				
				if(hit2D) 
				{            
					if(hit2D.collider.tag.Equals("Cop") && m_copVisible)
					{
						SetState(EnemyState.RUN);
					}
				}
				
				Debug.DrawRay(new Vector2(transform.position.x - m_rayDistanceFromSelf , transform.position.y) , transform.right * m_rayDistance , Color.red);
			}
    }

    protected void SetState(EnemyState newState)
	{
		if (m_currentState == newState)
		{
			return;
		}
		
		m_previousState = m_currentState;
		m_currentState = newState;
	}

    protected void Walk()
    {
        m_isRunning = false;
        m_isWalking = true;

        if(m_isMovingRight)
		{
			if(!m_isFacingRight)
			{
				Flip();
			}
			
			m_thugBody2D.velocity = new Vector2(m_walkSpeed , m_thugBody2D.velocity.y);
		}
		
		else if(m_isMovingLeft)
		{
			if(m_isFacingRight)
			{
				Flip();
			}
			
			m_thugBody2D.velocity = new Vector2(-m_walkSpeed , m_thugBody2D.velocity.y);
		}
		
		else
		{
			return;
		}
    }
}
