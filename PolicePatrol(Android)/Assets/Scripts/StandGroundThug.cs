using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandGroundThug : Thug 
{
	private void Reset()
    {
        m_flipTime = 2.5f;
        m_rayDistance = 11.35f;
        m_rayDistanceFromSelf = 0.35f;
        m_runSpeed = 2.25f;
        m_walkSpeed = 1.50f;
    }

    void Start()
    {
        m_policeController = GameObject.FindGameObjectWithTag("Player").GetComponent<PoliceController>();
        m_startPosition = transform;	
        SetState(EnemyState.IDLE);
        StartCoroutine("Flipping");
        m_thugBody2D = GetComponent<Rigidbody2D>();
	}

    void Update() 
    {
		if(Time.timeScale == 0)
		{
			return;
		}

        m_copVisible = m_policeController.m_isVisible;

        if(m_isRunning)
        {
            m_thugChasing = true;
        }

        else if(!m_isRunning)
        {
            m_thugChasing = false;
        }

        if(m_isFacingRight)
        {
            m_isMovingRight = true;
            m_isMovingLeft = false;
        }

        else if(!m_isFacingRight)
        {
            m_isMovingRight = false;
            m_isMovingLeft = true;
        }

		UpdateStateMachine();
	}

    private EnemyState GetState()
	{
		return m_currentState;
	}
}
