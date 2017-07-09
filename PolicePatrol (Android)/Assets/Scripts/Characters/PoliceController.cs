﻿using System.Collections;
using UnityEngine;

public class PoliceController : MonoBehaviour 
{
	#region PlayerState
	//---------------------------------------------------------------------------------------------------
	public enum PlayerState
	{
		ATTACKING,
		BLEND,
		CROUCH,
		CrouchMoving,
		DEAD,
		DYING,
		IDLE,
		RUNNING,
		SLAP,
		WALKING,
	};
	
	public PlayerState m_currentState;
	public PlayerState m_previousState;
	//---------------------------------------------------------------------------------------------------
	#endregion
	
	#region Variables Decleration
	//---------------------------------------------------------------------------------------------------
	public float m_rayDistance , m_runSpeed , m_walkSpeed;
	//public float m_jumpHeight = 10f;
	//---------------------------------------------------------------------------------------------------
	public bool  m_isMoving      = false;
	public bool m_isCrouchMoving = false;
	public bool  m_isMovingLeft  = false;
	public bool m_isCrouchMovingLeft = false;
	public bool  m_isMovingRight = false;
	public bool m_isCrouchMovingRight = false;
	public bool  m_isGoingUp     = false;
	public bool  m_isGoingDown   = false;
	public bool m_crouched = false , m_blend = false , m_running = false;
	public bool m_dead = false;
	public BoxCollider2D m_policeCollider2D;
	//---------------------------------------------------------------------------------------------------
	public bool  m_isFacingRight = true;
	// private bool  m_shouldFlip    = false;
	//---------------------------------------------------------------------------------------------------
	public Transform  m_groundCheckTransform;
	public LayerMask m_groundLayerMask;
	public float      m_radiusToCheckGround = 0.02f;
	public bool       m_isGrounded = false , m_isInDark = true;
	public float      m_groundCheckOffSet = 1f;

	//---------------------------------------------------------------------------------------------------
	private float xInput = 0f;
	//private float yInput = 0f;
	//---------------------------------------------------------------------------------------------------
	
	//--------------------------------------------------------------------------------------------------
	public AudioSource  m_myAudioSource;
	public AudioClip    m_jumpSound;
	public AudioClip    m_thighSlapSound;
	public AudioClip    m_caughtSound;
	public AudioClip    m_levelWonSound;
	public AudioClip    m_levelLostSound;
	public AudioClip    m_pickupSound;
	public bool m_touchHeld;
	public float m_touchDeadZone;
	public float debugTouchDistance , m_dieTime , m_idleTime;
	public bool m_hasReachedTargetPosition = false;
	public Animator m_anim , m_dyingAnim;
	public Animator[] m_gateOpenAnims;
	//---------------------------------------------------------------------------------------------------
	
	public int m_dieCount = 0 , dubug_CollisionCount = 0 , m_floor = 0 , m_i;
	public bool m_statue , m_touchReleased;
	public BoxCollider2D m_thugCollider2D;
	public Color m_defaultSpriteColour , m_spriteColour;
	private Vector3 m_mountPosition;
	private Vector3 m_targetPosition;
	//private GameObject m_liftReference;
	public float m_greenColourValue , m_liftYPosition , m_liftSpeed = 0.5f , m_policeXPosition , m_policeYPosition , m_redColourValue;
	public Rigidbody2D m_policeBody2D;
	public SpriteRenderer m_policeRenderer , m_policeDyingRenderer;
	SpriteRenderer m_statueRenderer;
	Thug m_thugScript;
	Lift m_liftScript;
	public string m_switchCount;
	public Switch m_switchScript;
	public UIManager m_uiScript;
	#endregion

	#region Start()
	void Start () 
	{
		m_groundCheckTransform.position = new Vector3(transform.position.x , transform.position.y - m_groundCheckOffSet);
		
		m_currentState = PlayerState.IDLE;
		m_previousState = m_currentState;
		
		//m_groundLayerMask = 1 << 12;
		
		m_anim = GetComponent<Animator>();
        m_liftScript = GameObject.FindGameObjectWithTag("Lift").GetComponent<Lift>();
        m_statueRenderer = GameObject.FindGameObjectWithTag("Statue").GetComponent<SpriteRenderer>();
        m_thugScript = GameObject.FindGameObjectWithTag("Thug").GetComponent<Thug>();
	}
	#endregion

	#region BackToIdle()
	IEnumerator BackToIdle()
	{
		yield return new WaitForSeconds(m_idleTime);
		SetState(PlayerState.IDLE);

		yield return new WaitForSeconds(3);

		if(m_switchCount == "1st Switch")
		{
			m_gateOpenAnims[0].SetInteger("AnimIndex" , 2);
		}
	}
	#endregion

	#region CheckIfGrounded()
	//---------------------------------------------------------------------------------------------------
	private void CheckIfGrounded()
	{
		if(!m_isGoingUp || !m_isGoingDown)
		{
			m_isGrounded = Physics2D.OverlapCircle(m_groundCheckTransform.position , m_radiusToCheckGround , m_groundLayerMask);
		}
	}
	//---------------------------------------------------------------------------------------------------
	#endregion
	
	#region CheckInput()
	//---------------------------------------------------------------------------------------------------
	private void CheckInput()
	{
		CheckKeyboardAndControllerInput();
		CheckTouchInput();
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region CheckKeyboardAndControllerInput()
	//---------------------------------------------------------------------------------------------------
	private void CheckKeyboardAndControllerInput()
	{
		xInput = Input.GetAxis("Horizontal");
		//yInput = Input.GetAxis("Vertical");
		
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
	#endregion
	
	#region CheckTouchInput()
	//---------------------------------------------------------------------------------------------------
	private void CheckTouchInput()
	{
		//        if(TouchScript.Gestures.LongPressGesture.GestureState.Began)
		//		{
		//			Debug.Log("Touch Held");
		//		}
	}
	//---------------------------------------------------------------------------------------------------
	#endregion
	
	#region ClearFlags()
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
	#endregion

	#region Die()
	IEnumerator Die()
	{
		yield return new WaitForSeconds(m_dieTime);
		SetState(PlayerState.DEAD);
	}
	#endregion

	#region FlipPlayer()
	//---------------------------------------------------------------------------------------------------
	private void FlipPlayer()
	{
		m_isFacingRight = !m_isFacingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region GetState()
	//---------------------------------------------------------------------------------------------------
	private PlayerState GetState()
	{
		return m_currentState;
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region OnTriggerEnter2D()
	void OnTriggerEnter2D(Collider2D col2D)
	{
		if(col2D.gameObject.tag.Equals("Lift"))
		{
			m_liftScript.m_liftReady = true;
		}

		if(col2D.gameObject.tag.Equals("Light"))
		{
			//Debug.Log("Police in Light");
			m_policeRenderer.color = m_spriteColour;
			m_isInDark = false;
		}

		if(col2D.gameObject.tag.Equals("Statue"))
		{
			m_statue = true;
			
			if(m_currentState == PlayerState.RUNNING)
			{
				m_blend = true;
				SetState(PlayerState.BLEND);
			}
		}

		if(col2D.gameObject.tag.Equals("Thug"))
		{
			if(m_isInDark && m_currentState == PlayerState.WALKING)
			{
				Debug.Log("Police Whooped Ass");
				m_policeRenderer.enabled = false;
				SetState(PlayerState.ATTACKING);
				m_thugScript.SetState(Thug.EnemyState.DYING);
			}
		}
	}
	#endregion

	#region OnTriggerExit2D()
	void OnTriggerExit2D(Collider2D col2D)
	{
		if(col2D.gameObject.name.Equals("Lift"))
		{
			m_liftScript.m_liftReady = false;
		}

		if(col2D.gameObject.tag.Equals("Light"))
		{
			//Debug.Log("Police in Dark");
			m_policeRenderer.color = m_defaultSpriteColour;
			m_isInDark = true;
		}
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region PerformAttack()
	//---------------------------------------------------------------------------------------------------
	private void PerformAttack()
	{
		m_policeBody2D.velocity = new Vector2(0f , GetComponent<Rigidbody2D>().velocity.y);
		
		if(m_thugScript.m_dead)
		{
			SetState(PlayerState.IDLE);
		}
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region PerformBlend()
	//---------------------------------------------------------------------------------------------------
	private void PerformBlend()
	{
		m_anim.SetInteger("AnimIndex" , 6);

		m_uiScript.Enable("BlendUI");

		if(m_statue)
		{
			m_statueRenderer.enabled = false;

			if(m_thugScript.m_moveSpeed == m_thugScript.m_runSpeed)
			{
				m_thugScript.m_flipping = false;
				m_thugScript.SetState(Thug.EnemyState.LOOKOUT);
			}

			if(m_thugScript.m_currentState == Thug.EnemyState.WALK)
			{
				m_uiScript.m_blendUIRenderers[0].enabled = false;
				m_uiScript.m_blendUIRenderers[1].enabled = false;
				m_running = false;
				m_blend = false;
				SetState(PlayerState.IDLE);
				m_statueRenderer.enabled = true;
			}
		}

		m_policeBody2D.velocity = new Vector2(0f , GetComponent<Rigidbody2D>().velocity.y);
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region PerformCrouch()
	//---------------------------------------------------------------------------------------------------
	public void PerformCrouch()
	{
		m_anim.SetInteger("AnimIndex" , 4);
		m_policeBody2D.velocity = new Vector2(0f , GetComponent<Rigidbody2D>().velocity.y);
		m_isCrouchMoving = false;
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region PerformCrouchWalk()
	//---------------------------------------------------------------------------------------------------		
	public void PerformCrouchWalk()
	{
		m_anim.SetInteger("AnimIndex" , 1);

		if(!m_isCrouchMoving || m_hasReachedTargetPosition)
		{
			SetState(PlayerState.CROUCH);
			return;
		}
		
		if(m_isCrouchMovingRight)
		{
			if(!m_isFacingRight)
			{
				FlipPlayer();
			}
			
			m_policeBody2D.velocity = new Vector2(m_walkSpeed , GetComponent<Rigidbody2D>().velocity.y);
		}
		
		else if(m_isCrouchMovingLeft)
		{
			if (m_isFacingRight)
			{
				FlipPlayer();
			}
			
			m_policeBody2D.velocity = new Vector2(-m_walkSpeed , GetComponent<Rigidbody2D>().velocity.y);
		}
		
		else
		{
			m_isCrouchMoving = false;
			return;
		}
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region PerformDeath()
	//---------------------------------------------------------------------------------------------------
	private void PerformDeath()
	{
		m_dead = true;
		m_dyingAnim.SetBool("ConstableDying" , false);
		m_policeDyingRenderer.enabled = false;
		Destroy(this.gameObject);
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region PerformDying()
	//---------------------------------------------------------------------------------------------------
	private void PerformDying()
	{
		m_dyingAnim.SetBool("ConstableDying" , true);
		TouchReleased();
		m_uiScript.Disable("BlendUI");
		m_policeRenderer.enabled = false;
		//m_thugScript.m_thugRenderer.enabled = false;
		m_policeDyingRenderer.enabled = true;
		StartCoroutine("Die");
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region PerformIdle()
	//---------------------------------------------------------------------------------------------------
	private void PerformIdle()
	{
		m_anim.SetInteger("AnimIndex" , 0);
		m_policeBody2D.velocity = new Vector2(0f , GetComponent<Rigidbody2D>().velocity.y);
		m_isMoving = false;
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region PerformRun()
	public void PerformRun()
	{
		m_anim.SetInteger("AnimIndex" , 5);

		if (!m_isMoving || m_hasReachedTargetPosition)
		{
			SetState(PlayerState.IDLE);
			return;
		}
		
		if (m_isMovingRight)
		{
			if(!m_isFacingRight)
			{
				FlipPlayer();
			}
			
			m_policeBody2D.velocity = new Vector2(m_runSpeed , GetComponent<Rigidbody2D>().velocity.y);
		}
		
		else if (m_isMovingLeft)
		{
			if (m_isFacingRight)
			{
				FlipPlayer();
			}
			
			m_policeBody2D.velocity = new Vector2(-m_runSpeed , GetComponent<Rigidbody2D>().velocity.y);
		}
		
		else
		{
			m_isMoving = false;
			return;
		}
	}
	#endregion

	#region PerformThighSlap()
	//---------------------------------------------------------------------------------------------------
	private void PerformThighSlap()
	{
		m_anim.SetInteger("AnimIndex" , 3);

		if(m_switchScript.m_switchCount == "1st Switch" && m_switchScript.m_switchRenderer.sprite.Equals(m_switchScript.m_switchOFF))
		{
			m_gateOpenAnims[0].SetInteger("AnimIndex" , 1);
		}

		StartCoroutine("BackToIdle");
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region PerformWalk()
	//---------------------------------------------------------------------------------------------------
	public void PerformWalk()
	{
		m_anim.SetInteger("AnimIndex" , 2);

		//m_policeBody2D.gravityScale = 1;

		if (!m_isMoving || m_hasReachedTargetPosition)
		{
			SetState(PlayerState.IDLE);
			return;
		}
		
		if (m_isMovingRight)
		{
			if(!m_isFacingRight)
			{
				FlipPlayer();
			}
			
			m_policeBody2D.velocity = new Vector2(m_walkSpeed , GetComponent<Rigidbody2D>().velocity.y);
		}
		
		else if (m_isMovingLeft)
		{
			if (m_isFacingRight)
			{
				FlipPlayer();
			}
			
			m_policeBody2D.velocity = new Vector2(-m_walkSpeed , GetComponent<Rigidbody2D>().velocity.y);
		}
		
		else
		{
			m_isMoving = false;
			return;
		}
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region ProcessInput()
	//---------------------------------------------------------------------------------------------------
	private void ProcessInput()
	{
		if (m_isMoving)
		{
			if(xInput != 0)
			{
				SetState(PlayerState.WALKING);
			}
			else
			{
				m_isMoving = false;
				SetState(PlayerState.IDLE);
			}
		}
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region SetState()
	//---------------------------------------------------------------------------------------------------
	public void SetState(PlayerState newState)
	{
		if (m_currentState == newState)
		{
			return;
		}
		
		m_previousState = m_currentState;
		m_currentState = newState;
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region TouchHeld()
	//---------------------------------------------------------------------------------------------------
	public void TouchHeld(TouchInfo touchInfo)
	{
		debugTouchDistance = touchInfo.touchPosition.x - transform.position.x;
		
		if(m_touchHeld && !m_hasReachedTargetPosition)
		{
			if(m_blend)
			{
				TouchReleased();
			}

			if(!m_crouched)
			{
				m_isMoving = true;
				SetState(PlayerState.WALKING);
				
				if (debugTouchDistance > m_touchDeadZone)
				{
					m_isMovingRight = true;
					m_isMovingLeft = false;
				}
				
				else if (debugTouchDistance < -m_touchDeadZone)
				{
					m_isMovingLeft = true;
					m_isMovingRight = false;
				}
				
				else
				{
					m_hasReachedTargetPosition = true;
				}				
			}
			
			if(m_running)
			{
				m_isMoving = true;
				SetState(PlayerState.RUNNING);
				
				if (debugTouchDistance > m_touchDeadZone)
				{
					m_isMovingRight = true;
					m_isMovingLeft = false;
				}
				
				else if (debugTouchDistance < -m_touchDeadZone)
				{
					m_isMovingLeft = true;
					m_isMovingRight = false;
				}
				
				else
				{
					m_hasReachedTargetPosition = true;
				}
			}
			
			else if(m_crouched)
			{
				m_isCrouchMoving = true;
				SetState(PlayerState.CrouchMoving);
				
				if (debugTouchDistance > m_touchDeadZone)
				{
					m_isCrouchMovingRight = true;
					m_isCrouchMovingLeft = false;
				}
				
				else if (debugTouchDistance < -m_touchDeadZone)
				{
					m_isCrouchMovingLeft = true;
					m_isCrouchMovingRight = false;
				}
				
				else
				{
					m_hasReachedTargetPosition = true;
				}
			}
		}
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region TouchInput()
	//---------------------------------------------------------------------------------------------------
	public void TouchInput(TouchInfo touchInfo)
	{
		SriTouchGestures gesture = touchInfo.touchGesture;
		m_touchReleased = false;
		
		switch(gesture)
		{
			case SriTouchGestures.SRI_NONE:

			break;
			
			case SriTouchGestures.SRI_SWIPEDLEFT:
				//SwipedLeft();
			break;
			
			case SriTouchGestures.SRI_SWIPEDRIGHT:
				//SwipedRight();
			break;
			
			case SriTouchGestures.SRI_SWIPEDUP:
				
				if(m_liftScript.m_liftReady)
				{
					m_policeBody2D.gravityScale = 10;
				}
				
				if(!m_liftScript.m_liftReady)
				{
					m_crouched = false;
					m_policeBody2D.gravityScale = 1;
					SetState(PlayerState.IDLE);
				}
			
			break;
			
			case SriTouchGestures.SRI_SWIPEDDOWN:
				
				if(m_liftScript.m_liftReady)
				{
					m_policeBody2D.gravityScale = 10;
				}
				
				if(!m_liftScript.m_liftReady)
				{
					m_crouched = true;
					m_policeBody2D.gravityScale = 1;
					SetState(PlayerState.CROUCH);
				}
			
			break;
			
			case SriTouchGestures.SRI_DOUBLETAPPED:
				//DoubleTapped();
				Debug.Log("Double Tapped");
			break;
			
			case SriTouchGestures.SRI_TAPHELD:
				
				if(m_currentState != PlayerState.ATTACKING && m_currentState != PlayerState.BLEND && m_currentState != PlayerState.DYING && m_currentState != PlayerState.SLAP)
				{
					m_touchHeld = true;
					TouchHeld(touchInfo);
				}
			
			break;
			
			case SriTouchGestures.SRI_RELEASED:

				if(m_currentState != PlayerState.BLEND)
				{
					TouchReleased();
				}

			break;

			case SriTouchGestures.SRI_TAPPED:
				Debug.Log("Tapped");
			break;
		}
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region TouchReleased()
	//---------------------------------------------------------------------------------------------------
	public void TouchReleased()
	{
		m_touchReleased = true;
		
		if(m_touchHeld && m_blend && m_currentState == PlayerState.RUNNING)
		{
			m_touchHeld = false;
			SetState(PlayerState.BLEND);
			m_hasReachedTargetPosition = false;
		}

		else if(m_touchHeld && !m_crouched)
		{
			m_touchHeld = false;
			SetState(PlayerState.IDLE);
			m_hasReachedTargetPosition = false;
		}
		
		else if (m_touchHeld && m_crouched)
		{
			m_touchHeld = false;
			SetState(PlayerState.CROUCH);
			m_hasReachedTargetPosition = false;
		}
	}
	//---------------------------------------------------------------------------------------------------	
	#endregion
	
	#region UpdateStateMachine()
	//---------------------------------------------------------------------------------------------------
	private void UpdateStateMachine()
	{
		switch (m_currentState)
		{
			case PlayerState.ATTACKING:
				PerformAttack();
			break;

			case PlayerState.BLEND:
				PerformBlend();
			break;
			
			case PlayerState.CROUCH:
				PerformCrouch();
			break;
			
			case PlayerState.CrouchMoving:
				PerformCrouchWalk();
			break;
			
			case PlayerState.DEAD: 
				PerformDeath();
			break;
			
			case PlayerState.DYING: 
				PerformDying();
			break;
			
			case PlayerState.IDLE: 
				PerformIdle();
			break;
			
			case PlayerState.RUNNING:
				PerformRun();
			break;
			
			case PlayerState.SLAP: 
				PerformThighSlap();
			break;
			
			case PlayerState.WALKING: 
				PerformWalk();
			break;
		}
	}
	//---------------------------------------------------------------------------------------------------
	#endregion
	
	#region UpdateAnimations()
	//---------------------------------------------------------------------------------------------------
	private void UpdateAnimations()
	{
		switch (m_currentState)
		{
			case PlayerState.ATTACKING: break;
			case PlayerState.BLEND: break;
			case PlayerState.CROUCH: break;
			case PlayerState.CrouchMoving: break;
			case PlayerState.DEAD: break;
			case PlayerState.DYING: break;
			case PlayerState.IDLE: break;
			case PlayerState.RUNNING: break;
			case PlayerState.SLAP: break;
			case PlayerState.WALKING: break;
		}
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region FixedUpdate()
	//---------------------------------------------------------------------------------------------------
	void FixedUpdate()
	{
		m_groundCheckTransform.position = new Vector3(transform.position.x , transform.position.y - m_groundCheckOffSet);
		CheckIfGrounded();
	}
	//---------------------------------------------------------------------------------------------------
	#endregion

	#region Update()
	//---------------------------------------------------------------------------------------------------
	void Update () 
	{
		if(Time.timeScale == 0)
		{
			return;
		}

		UpdateStateMachine();
		UpdateAnimations();
		ClearFlags();
		
		//m_liftYPosition = m_liftBody2D.position.y;

		m_policeXPosition = m_policeBody2D.position.x;
		m_policeYPosition = m_policeBody2D.position.y;
	}
	//---------------------------------------------------------------------------------------------------
	#endregion	
}
