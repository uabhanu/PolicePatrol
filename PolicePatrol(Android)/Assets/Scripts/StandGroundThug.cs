using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandGroundThug : MonoBehaviour 
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
	
    bool m_copVisible , m_isFacingRight;
    [SerializeField] float m_flipTime , m_rayDistance , m_rayDistanceFromSelf;
    PoliceController m_policeController;
    Rigidbody2D m_thugBody2D;
    [SerializeField] Transform m_startPosition;

    private void Reset()
    {
        m_flipTime = 2.5f;
        m_rayDistance = 11.35f;
        m_rayDistanceFromSelf = 0.35f;
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
		UpdateStateMachine();
	}

    IEnumerator Flipping()
	{
		yield return new WaitForSeconds(m_flipTime);
            
        if(m_currentState == EnemyState.IDLE)
        {
            Flip();
			StartCoroutine("Flipping");
        }
	}

    void Attack()
    {

    }

    void CopDisappeared()
    {

    }

    void Death()
    {

    }

    void Dying()
    {

    }

    private void Flip()
	{
		m_isFacingRight = !m_isFacingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    private EnemyState GetState()
	{
		return m_currentState;
	}

    void Idle()
    {
        m_thugBody2D.velocity = new Vector2(0f , m_thugBody2D.velocity.y);

        if(m_isFacingRight)
			{
				RaycastHit2D hit2D = Physics2D.Raycast(new Vector2(transform.position.x + m_rayDistanceFromSelf , transform.position.y) , -transform.right , m_rayDistance);
				
				if(hit2D) 
				{
                    if(hit2D.collider.tag.Equals("Player") && m_copVisible)
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
					if(hit2D.collider.tag.Equals("Player") && m_copVisible)
					{
						SetState(EnemyState.RUN);
					}
				}
				
				Debug.DrawRay(new Vector2(transform.position.x - m_rayDistanceFromSelf , transform.position.y) , transform.right * m_rayDistance , Color.red);
			}
    }

    void Run()
    {

    }

    public void SetState(EnemyState newState)
	{
		if (m_currentState == newState)
		{
			return;
		}
		
		m_previousState = m_currentState;
		m_currentState = newState;
	}

    private void UpdateStateMachine()
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

    void Walk()
    {
        
    }
}
