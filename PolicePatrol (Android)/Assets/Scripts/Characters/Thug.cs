using System.Collections;
using UnityEngine;

public class Thug : MonoBehaviour 
{
	public enum EnemyState
	{
		ATTACK,
		ATTACKING,
		DEAD,
		DYING,
		IDLE,
		LOOKOUT,
		WALK,
	};
	
	public EnemyState m_currentState;
	public EnemyState m_previousState;

	public Animator m_anim , m_dyingAnim;
	public bool  m_dead = false , m_flipping = true , m_isFacingRight = true , m_isInLight = false , m_isMovingRight = false;
	public GameObject m_thugDyingObj;
	public float m_dieTime , m_flipTime , m_idleTime , m_rayDistance , m_runSpeed , m_walkSpeed;
    [HideInInspector] public float m_moveSpeed = 1f;
	public PoliceController m_policeControlScript;
	public Rigidbody2D m_thugBody2D;
	public SpriteRenderer m_thugRenderer , m_thugDyingRenderer;
	public Transform m_start;

    private void Reset()
    {
        m_currentState = EnemyState.IDLE;
        m_dieTime = 2.5f;
        m_flipping = true;
        m_flipTime = 2.5f;
        m_idleTime = 15f;
        m_rayDistance = 2.3f;
        m_runSpeed = 1.5f;
        m_walkSpeed = 0.5f;
    }

    void Start () 
	{
		m_anim = GetComponent<Animator>();

		SetState(EnemyState.IDLE);
		StartCoroutine("Flipping");
		StartCoroutine("StartFlipping");

        m_policeControlScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PoliceController>();
        m_thugBody2D = GetComponent<Rigidbody2D>();
		m_thugDyingObj = GameObject.Find("ThugDying");

        if(m_thugDyingObj != null)
        {
            m_thugDyingRenderer = m_thugDyingObj.GetComponent<SpriteRenderer>();
        }

        m_thugRenderer = GetComponent<SpriteRenderer>();

		if(m_thugDyingObj != null)
		{
			m_dyingAnim = m_thugDyingObj.GetComponent<Animator>();
		}

		m_isFacingRight = false;
        m_start = GameObject.Find("StartPosition").transform;
		m_thugBody2D.transform.Rotate(0 , 180 , 0);
	}
		
	IEnumerator Die()
	{
		yield return new WaitForSeconds(m_dieTime);
		SetState(EnemyState.DEAD);
	}

	IEnumerator Flipping()
	{
		if(m_currentState == EnemyState.IDLE && m_flipping)
		{
			yield return new WaitForSeconds(m_flipTime);
			FlipEnemy();
			//Debug.Log("Flipping");
			StartCoroutine("Flipping");
		}
	}

	IEnumerator StartFlipping()
	{
		yield return new WaitForSeconds(m_flipTime);

		//Debug.Log("Start Flipping");

		if(m_currentState == EnemyState.IDLE && m_flipping)
		{
			StartCoroutine("Flipping");
		}

		StartCoroutine("StartFlipping");
	}

	void BackToIdle()
	{
		if(m_currentState == EnemyState.LOOKOUT)
		{
			SetState(EnemyState.WALK);
		}
	}

	private void FlipEnemy()
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

	void OnTriggerEnter2D(Collider2D col2D)
	{
		if(col2D.gameObject.tag.Equals("Light"))
		{
			m_isInLight = true;
		}

		if(col2D.gameObject.tag.Equals("Player"))
		{
			if(m_currentState == EnemyState.ATTACKING && !m_policeControlScript.m_blend)
			{
				m_policeControlScript.SetState(PoliceController.PlayerState.DYING);
				m_policeControlScript.m_touchHeld = false;
				SetState(EnemyState.ATTACK);
			}
		}
	}

	void OnTriggerExit2D(Collider2D col2D)
	{
		if(col2D.gameObject.tag.Equals("Light"))
		{
			m_isInLight = false;
		}
	}

	void PerformAttack()
	{
		m_thugRenderer.enabled = false;
		m_thugBody2D.velocity = new Vector2(0f , GetComponent<Rigidbody2D>().velocity.y);
		
		if(m_policeControlScript.m_dead)
		{
			SetState(EnemyState.IDLE);
			StartCoroutine("Flipping");
			m_thugRenderer.enabled = true;
		}
	}
	
	void PerformAttacking()
	{
		m_moveSpeed = m_runSpeed;

		m_anim.SetInteger("AnimIndex" , 1);
		
		StopCoroutine("FlipTimer");
		
		if (m_isMovingRight)
		{
			if(!m_isFacingRight)
			{
				FlipEnemy();
			}
			
			m_thugBody2D.velocity = new Vector2(m_moveSpeed , GetComponent<Rigidbody2D>().velocity.y);
		}
		
		else if(!m_isMovingRight)
		{
			if(m_isFacingRight)
			{
				FlipEnemy();
			}
			
			m_thugBody2D.velocity = new Vector2(-m_moveSpeed , GetComponent<Rigidbody2D>().velocity.y);
		}
	}

	void PerformDeath()
	{
		m_dyingAnim.SetBool("ThugDying" , false);
		m_dead = true;
		m_thugDyingRenderer.enabled = false;
		m_policeControlScript.m_policeRenderer.enabled = true;
		//m_policeControlScript.m_moveSpeed = m_policeControlScript.m_walkSpeed;
		Destroy(this.gameObject);
	}
	
	void PerformDying()
	{
		m_dyingAnim.SetBool("ThugDying" , true);
		m_policeControlScript.TouchReleased();
		m_thugRenderer.enabled = false;
		m_thugDyingRenderer.enabled = true;
		StartCoroutine("Die");
	}
	
	void PerformIdle()
	{
		m_thugRenderer.enabled = true;

        m_anim.SetInteger("AnimIndex" , 0);
		m_thugBody2D.velocity = new Vector2(0f , GetComponent<Rigidbody2D>().velocity.y);


        if (m_isFacingRight)
        {
            RaycastHit2D hit2D = Physics2D.Raycast(new Vector2(transform.position.x + 0.3f , transform.position.y) , -transform.right * m_rayDistance);

            if(hit2D)
            {
                if (hit2D.collider.tag.Equals("Player"))
                {
                    Debug.Log(hit2D.collider);
                    m_isMovingRight = true;
                    m_policeControlScript.m_running = true;
                    m_flipping = false;
                    m_policeControlScript.SetState(PoliceController.PlayerState.RUNNING);
                    SetState(EnemyState.ATTACKING);
                }
            }

            Debug.DrawRay(new Vector2(transform.position.x + 0.3f , transform.position.y) , -transform.right * m_rayDistance , Color.red);
        }

        else if (!m_isFacingRight)
        {
            RaycastHit2D hit2D = Physics2D.Raycast(new Vector2(transform.position.x - 0.3f , transform.position.y) , transform.right * m_rayDistance);

            if(hit2D)
            {
                if (hit2D.collider.tag.Equals("Player"))
                {
                    Debug.Log(hit2D.collider);
                    m_isMovingRight = false;
                    m_policeControlScript.m_running = true;
                    m_flipping = false;
                    m_policeControlScript.SetState(PoliceController.PlayerState.RUNNING);
                    SetState(EnemyState.ATTACKING);
                }
            }

            Debug.DrawRay(new Vector2(transform.position.x - 0.3f , transform.position.y) , transform.right * m_rayDistance , Color.red);
        }
    }

    void PerformLookout()
    {
        m_anim.SetInteger("AnimIndex", 3);
        m_flipping = false;
        m_thugBody2D.velocity = new Vector2(0f, GetComponent<Rigidbody2D>().velocity.y);
        Invoke("BackToIdle", m_idleTime);
    }

    void PerformWalk()
	{
		m_moveSpeed = m_walkSpeed;

		float step = m_moveSpeed * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position , m_start.position , step);

		if(transform.position.x == m_start.position.x)
		{
			m_flipping = true;
			SetState(EnemyState.IDLE);
		}
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
				PerformAttack();
			break;
			
			case EnemyState.ATTACKING: 
				PerformAttacking();
			break;

			case EnemyState.DEAD: 
				PerformDeath();
			break;
			
			case EnemyState.DYING: 
				PerformDying();
			break;

			case EnemyState.IDLE: 
				PerformIdle();
			break;

			case EnemyState.LOOKOUT:
				PerformLookout();
			break;

			case EnemyState.WALK:
				PerformWalk();
			break;
		}
	}

	void Update () 
	{
		if(Time.timeScale == 0)
		{
			return;
		}

		m_isInLight = !m_policeControlScript.m_isInDark;
		UpdateStateMachine();
	}
}
