using System.Collections;
using UnityEngine;

public class Thug : MonoBehaviour 
{
	#region EnemyState
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
	#endregion

	#region Variables Decleration
	public Animator m_anim , m_dyingAnim;
	public bool  m_dead = false , m_flipping = true , m_isFacingRight = true , m_isInLight = false , m_isMovingLeft = false , m_isMovingRight = false , m_PoliceVisible = false;
	public BoxCollider2D m_boxCollider2D;
	public GameObject thugDyingObj;
	public float m_dieTime , m_flipTime , m_idleTime , m_moveSpeed , m_rayDistance , m_runSpeed , m_walkSpeed;
	public PoliceController m_policeScript;
	public Rigidbody2D m_thugBody2D;
	public SpriteRenderer m_thugRenderer , m_thugDyingRenderer;
	public Transform m_start;
	#endregion

	#region Start()
	void Start () 
	{
		m_anim = GetComponent<Animator>();

		SetState(EnemyState.IDLE);
		StartCoroutine("Flipping");
		StartCoroutine("StartFlipping");

		thugDyingObj = GameObject.Find("ThugDying");

		if(thugDyingObj != null)
		{
			m_dyingAnim = thugDyingObj.GetComponent<Animator>();
		}

		m_isFacingRight = false;
		m_thugBody2D.transform.Rotate(0 , 180 , 0);
	}
	#endregion
		
	#region IEnumerator Die()
	IEnumerator Die()
	{
		yield return new WaitForSeconds(m_dieTime);
		SetState(EnemyState.DEAD);
	}
	#endregion

	#region IEnumerator Flipping()
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
	#endregion

	#region IEnumerator StartFlipping()
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
	#endregion

	#region BackToIdle()
	void BackToIdle()
	{
		if(m_currentState == EnemyState.LOOKOUT)
		{
			SetState(EnemyState.WALK);
		}
	}
	#endregion

	#region FlipEnemy()
	private void FlipEnemy()
	{
		m_isFacingRight = !m_isFacingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	#endregion

	#region GetState()
	private EnemyState GetState()
	{
		return m_currentState;
	}
	#endregion

	#region OnCollisionEnter2D()
	void OnCollisionEnter2D(Collision2D col2D)
	{
//		if(col2D.gameObject.tag.Equals("Player"))
//		{
//			if(m_currentState == EnemyState.ATTACKING && !m_policeScript.m_blend)
//			{
//				m_policeScript.SetState(PoliceController.PlayerState.DYING);
//				m_policeScript.m_touchHeld = false;
//				SetState(EnemyState.ATTACK);
//			}
//		}
	}
	#endregion

	#region OnTriggerEnter2D()
	void OnTriggerEnter2D(Collider2D col2D)
	{
		if(col2D.gameObject.tag.Equals("Light"))
		{
			m_isInLight = true;
		}

		if(col2D.gameObject.tag.Equals("Player"))
		{
			if(m_currentState == EnemyState.ATTACKING && !m_policeScript.m_blend)
			{
				m_policeScript.SetState(PoliceController.PlayerState.DYING);
				m_policeScript.m_touchHeld = false;
				SetState(EnemyState.ATTACK);
			}
		}
	}
	#endregion

	#region OnTriggerExit2D()
	void OnTriggerExit2D(Collider2D col2D)
	{
		if(col2D.gameObject.tag.Equals("Light"))
		{
			m_isInLight = false;
		}
	}
	#endregion

	#region PerformAttack()
	void PerformAttack()
	{
		m_thugRenderer.enabled = false;
		m_thugBody2D.velocity = new Vector2(0f , GetComponent<Rigidbody2D>().velocity.y);
		
		if(m_policeScript.m_dead)
		{
			SetState(EnemyState.IDLE);
			StartCoroutine("Flipping");
			m_thugRenderer.enabled = true;
		}
	}
	#endregion
	
	#region PerformAttacking()
	void PerformAttacking()
	{
		m_moveSpeed = m_runSpeed;

		m_anim.SetInteger("AnimIndex" , 1);
		
		m_boxCollider2D.enabled = true;
		
		StopCoroutine("FlipTimer");
		
		if (m_isMovingRight)
		{
			if(!m_isFacingRight)
			{
				FlipEnemy();
			}
			
			m_thugBody2D.velocity = new Vector2(m_moveSpeed , GetComponent<Rigidbody2D>().velocity.y);
		}
		
		else if(m_isMovingLeft)
		{
			if(m_isFacingRight)
			{
				FlipEnemy();
			}
			
			m_thugBody2D.velocity = new Vector2(-m_moveSpeed , GetComponent<Rigidbody2D>().velocity.y);
		}
	}
	#endregion

	#region PerformDeath()
	void PerformDeath()
	{
		m_dyingAnim.SetBool("ThugDying" , false);
		m_dead = true;
		m_thugDyingRenderer.enabled = false;
		m_policeScript.m_policeRenderer.enabled = true;
		//m_policeScript.m_moveSpeed = m_policeScript.m_walkSpeed;
		Destroy(this.gameObject);
	}
	#endregion
	
	#region PerformDying()
	void PerformDying()
	{
		m_dyingAnim.SetBool("ThugDying" , true);
		m_policeScript.TouchReleased();
		m_thugRenderer.enabled = false;
		m_thugDyingRenderer.enabled = true;
		StartCoroutine("Die");
	}
	#endregion
	
	#region PerformIdle()
	void PerformIdle()
	{
		m_thugRenderer.enabled = true;

		//m_flipping = true;

		if(!m_PoliceVisible)
		{
			m_boxCollider2D.enabled = true;
		}
		
		if(m_PoliceVisible)
		{
			m_boxCollider2D.enabled = false;
		}
		
		m_anim.SetInteger("AnimIndex" , 0);
		m_thugBody2D.velocity = new Vector2(0f , GetComponent<Rigidbody2D>().velocity.y);
		
		
		if(m_isFacingRight)
		{
			RaycastHit2D hit2D = Physics2D.Raycast(transform.position , -transform.right , m_rayDistance , 1 << LayerMask.NameToLayer("Default"));
				
			if(hit2D) 
			{            
				if(hit2D.collider.tag.Equals("Player"))
				{
					Debug.Log(hit2D.collider);
					m_isMovingRight = true;
					m_isMovingLeft = false;
					m_policeScript.m_running = true;
					m_flipping = false;
					m_policeScript.SetState(PoliceController.PlayerState.RUNNING);
					SetState(EnemyState.ATTACKING);
				}
			}
				
			Debug.DrawRay(transform.position , -transform.right*m_rayDistance , Color.red);
		}
			
		else if(!m_isFacingRight)
		{
			RaycastHit2D hit2D = Physics2D.Raycast(transform.position , transform.right , m_rayDistance , 1 << LayerMask.NameToLayer("Default"));
				
			if(hit2D) 
			{            
				if(hit2D.collider.tag.Equals("Player"))
				{
					Debug.Log(hit2D.collider);
					m_isMovingRight = false;
					m_isMovingLeft = true;
					m_policeScript.m_running = true;
					m_flipping = false;
					m_policeScript.SetState(PoliceController.PlayerState.RUNNING);
					SetState(EnemyState.ATTACKING);
				}
			}
				
			Debug.DrawRay(transform.position , transform.right*m_rayDistance , Color.red);
		}
	}
	#endregion

	#region PerformLookout()
	void PerformLookout()
	{
		m_anim.SetInteger("AnimIndex" , 3);
		m_flipping = false;
		m_thugBody2D.velocity = new Vector2(0f , GetComponent<Rigidbody2D>().velocity.y);
		Invoke("BackToIdle" , m_idleTime);
	}
	#endregion

	#region PerformWalk()
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
	#endregion

	#region SetState()
	public void SetState(EnemyState newState)
	{
		if (m_currentState == newState)
		{
			return;
		}
		
		m_previousState = m_currentState;
		m_currentState = newState;
	}
	#endregion

	#region UpdateStateMachine()
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
	#endregion

	#region Update()
	void Update () 
	{
		if(Time.timeScale == 0)
		{
			return;
		}

		m_PoliceVisible = !m_policeScript.m_isInDark;

		if(m_isInLight && !m_policeScript.m_isInDark)
		{
			m_boxCollider2D.enabled = true;
		}
		
		if(!m_isInLight && m_policeScript.m_isInDark)
		{
			m_boxCollider2D.enabled = true;
		}

		if(m_isInLight && m_policeScript.m_isInDark)
		{
			m_boxCollider2D.enabled = false;
		}

		if(!m_isInLight && m_policeScript.m_isInDark)
		{
			m_boxCollider2D.enabled = false;
		}

		UpdateStateMachine();
	}
	#endregion
}
