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
        PATROL,
        RUN,
		WALK,
        WATCH
	};
	
	public EnemyState m_currentState;
	public EnemyState m_previousState;
	
    public bool m_copBlended , m_copVisible , m_isFacingLeft , m_isFacingRight , m_isMovingLeft , m_isMovingRight , m_isRunning , m_isWalking;
    [HideInInspector] public bool m_thugChasing;
    public float m_flipTime , m_rayDistance , m_rayDistanceFromSelf , m_runSpeed , m_timeToGoBack , m_walkSpeed;
    protected PoliceController m_policeController;
    protected Rigidbody2D m_thugBody2D;
    public Vector2 m_startPosition;

    void Start() 
    {
        
	}

    protected void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
    }

    protected IEnumerator FlippingRoutine()
	{
		yield return new WaitForSeconds(m_flipTime);
            
        if(m_currentState == EnemyState.WATCH)
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
        if(m_isFacingLeft)
        {
            m_isFacingLeft = false;
            m_isFacingRight = true;
        }

        else if(m_isFacingRight)
        {
            m_isFacingLeft = true;
            m_isFacingRight = false;
        }
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    protected void Patrol()
    {

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

        if(m_policeController.transform.position.x < transform.position.x)
        {
            m_isMovingRight = true;
        }

        else if(m_policeController.transform.position.x > transform.position.x)
        {
            m_isMovingLeft = true;
        }

        if(m_isMovingLeft)
		{
			if(m_isFacingRight)
			{
				Flip();
			}
		}

        else if(m_isMovingRight)
		{
			if(m_isFacingLeft)
			{
				Flip();
			}
		}
		
		else
		{
			return;
		}

        float step = m_walkSpeed * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position , m_startPosition , step);

        if(transform.position.x == m_startPosition.x)
        {
            SetState(EnemyState.WATCH);
            StartCoroutine("FlippingRoutine");
        }
    }
}
