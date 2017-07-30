using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandGroundThug : Thug 
{
	void Reset()
    {
        m_flipTime = 2.5f;
        m_rayDistance = 11.35f;
        m_rayDistanceFromSelf = 0.35f;
        m_runSpeed = 2.25f;
        m_walkSpeed = 1.50f;
    }

    void Start()
    {
        m_policeController = GameObject.FindGameObjectWithTag("Cop").GetComponent<PoliceController>();
        SetState(EnemyState.IDLE);
        StartCoroutine("FlippingRoutine");
        m_thugBody2D = GetComponent<Rigidbody2D>();
	}

    void Update() 
    {
		if(Time.timeScale == 0)
		{
			return;
		}

        m_copBlended = m_policeController.m_isBlending;
        m_copVisible = m_policeController.m_isVisible;
        m_timeToGoBack = m_policeController.m_blendTime;

        if(m_isRunning)
        {
            m_thugChasing = true;
        }

        else if(!m_isRunning)
        {
            m_thugChasing = false;
        }

        //if(m_isFacingRight)
        //{
        //    m_isMovingRight = true;
        //    m_isMovingLeft = false;
        //}

        //else if(!m_isFacingRight)
        //{
        //    m_isMovingRight = false;
        //    m_isMovingLeft = true;
        //}

		UpdateStateMachine();
	}

    IEnumerator GoBackRoutine()
    {
        yield return new WaitForSeconds(m_timeToGoBack);
        SetState(EnemyState.WALK);
    }

    void CopDisappeared()
    {
        StartCoroutine("GoBackRoutine");
        m_thugBody2D.velocity = new Vector2(0f , m_thugBody2D.velocity.y);
        m_thugChasing = false;
    }

    void Death()
    {

    }

    void Dying()
    {

    }

    EnemyState GetState()
    {
        return m_currentState;
    }

    void Run()
    {
        if(m_policeController.m_isFacingRight && !m_isRunning)
        {
            m_isMovingLeft = true;
            m_isMovingRight = false;
        }

        else if(!m_policeController.m_isFacingRight && !m_isRunning)
        {
            m_isMovingLeft = false;
            m_isMovingRight = true;
        }

        m_isRunning = true;
        m_isWalking = false;

        if(m_isMovingRight)
		{
			if(!m_isFacingRight)
			{
				Flip();
			}
			
			m_thugBody2D.velocity = new Vector2(m_runSpeed , m_thugBody2D.velocity.y);
            
            if(m_copBlended)
            {
                SetState(EnemyState.COPDISAPPEARED);
            }
		}
		
		else if(m_isMovingLeft)
		{
			if(m_isFacingRight)
			{
				Flip();
			}
			
			m_thugBody2D.velocity = new Vector2(-m_runSpeed , m_thugBody2D.velocity.y);

            if(m_copBlended)
            {
                SetState(EnemyState.COPDISAPPEARED);
            }
		}

		else
		{
			return;
		}
    }

    void UpdateStateMachine()
	{
		switch (m_currentState)
		{
			case EnemyState.ATTACK:
				Attack();
			break;

            case EnemyState.COPDISAPPEARED:
			    CopDisappeared();
			break;

			case EnemyState.DEAD: 
				Death();
			break;
			
			case EnemyState.DYING: 
				Dying();
			break;

			case EnemyState.IDLE: 
				Idle();
			break;

            case EnemyState.RUN:
                Run();
            break;

			case EnemyState.WALK:
                Walk();
			break;
		}
	}
}
