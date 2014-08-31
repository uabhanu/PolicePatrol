﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public Animator anim;
	public bool collidedPlayer , selected;
	public EnemySpawner eSpawnScript;
	[HideInInspector]
	public float speed , tagTimer;
	public GameObject eSpawnObj , iguiObj , playerObj;
	public GameObject[] enemies;
	public InGameUI iguiScript;
	public int hitpoints;
	public NavMeshAgent agent;
	public ParticleSystem sweatParticles;
	public Player playerScript;
	public Rigidbody boxBody;
	public static Enemy current;
	public Transform target;
	//static public Enemy current;

	public enum State
	{
		Walk,
		Hit,
		KO,
	};
	
	public State currentState;
	public State previousState;
	
	void Start () 
	{
		if(this.gameObject != null)
		{
			agent = this.gameObject.GetComponent<NavMeshAgent>();
			anim = this.gameObject.GetComponent<Animator>();

			eSpawnObj = GameObject.FindGameObjectWithTag("ESpawn");

			if(eSpawnObj != null)
			{
				eSpawnScript = eSpawnObj.GetComponent<EnemySpawner>();
			}

			if(transform.position.x < 0)
			{
				target = GameObject.FindGameObjectWithTag("Left").transform;
			}

			else if(transform.position.x > 0)
			{
				target = GameObject.FindGameObjectWithTag("Right").transform;
			}

			if(transform.position.z > 0)
			{
				this.gameObject.transform.Rotate(0 , 180 , 0);
			}
		}

		iguiObj = GameObject.FindGameObjectWithTag("IGUI");

		if(iguiObj != null)
		{
			iguiScript = iguiObj.GetComponent<InGameUI>();
		}

		playerObj = GameObject.FindGameObjectWithTag("Player");

		if(playerObj != null)
		{
			playerScript = playerObj.GetComponent<Player>();
		}
	}

	public void Death()
	{
		if(this.gameObject != null)
		{
			Debug.Log("Enemy Death");

			if(currentState == State.KO)
			{
				playerScript.SetState(0);
			}


			if(iguiScript.enemyCount > 0)
			{
				iguiScript.enemyCount--;
			}
	
			if(eSpawnScript != null)
			{
				eSpawnScript.enemySpawned = false;
			}

			Destroy (this.gameObject);

			if(playerScript != null)
			{
				playerScript.target = null;
			}
		}
	}

	public void DeductHitPoints(int val)
	{
		if(hitpoints > 0)
		{
			hitpoints = hitpoints - val;
		}
		
		if (hitpoints <= 0)
		{
			//Debug.Log("Enemy Died");
			SetState(2);
		}	
	}

	public void Hit()
	{
		Debug.Log("Enemy Hit Animation");
		anim.SetInteger("AnimIndex" , 1);
		anim.Play(0);
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag.Equals("Left"))
		{
			if(currentState != State.Hit)
			{
				if(iguiScript.truckLeftScoreValue < 5)
				{
					iguiScript.truckLeftScoreValue++;
				}
				
				Death();
			}
		}
		
		if(col.gameObject.tag.Equals("Right"))
		{
			if(currentState != State.Hit)
			{
				if(iguiScript.truckRightScoreValue < 5)
				{
					iguiScript.truckRightScoreValue++;
				}
				
				Death();
			}
		}

		if(col.gameObject.tag.Equals("Player") && playerScript != null)
		{
			if(playerScript.currentState == Player.State.Run)
			{
				//Debug.Log("Collision with Player");
				this.collidedPlayer = true;
			}
		}
	}

	void IdlePlayer()
	{
		Debug.Log("Player Idle Again");
		playerScript.Idle();
	}

	void OnCollisionExit(Collision col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
			this.collidedPlayer = false;
		}
	}

	void OnMouseDown()
	{
		Debug.Log("Enemy Selected");

		if(current != null)
		{
			current.selected = false;
		}

		selected = true;
		current = this;

		sweatParticles = this.gameObject.GetComponentInChildren<ParticleSystem>();

		if(Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}

		if(playerScript.currentState != Player.State.Attack)
		{
			playerScript.enemyObj = this.gameObject;

			if(playerScript.enemyObj != null)
			{
				playerScript.enemyScript = playerScript.enemyObj.GetComponent<Enemy>();
			}

			playerScript.target = this.gameObject.transform;
			playerScript.SetState(1);
		}
	}

	public void SetState(int newState)
	{
		previousState = currentState;
		currentState = (State)newState;
	}

	public void Sweat()
	{
		if(sweatParticles != null)
		{
			if(currentState == State.Hit)
			{
				Debug.Log("Enemy Sweat");
				sweatParticles.Play();
			}
		}
	}

	void Walk()
	{
		agent.SetDestination(target.position);

		if(this.collidedPlayer && selected && playerScript.currentState == Player.State.Attack)
		{
			SetState(1);
		}
	}

	void Update () 
	{
		if(Time.timeScale == 0)
		{
			return;
		}

		switch(currentState)
		{
			case State.Walk :
				Walk();
			break;

			case State.Hit :
				agent.speed = 0;

				if(boxBody != null)
				{
					boxBody.useGravity = true;
					boxBody.transform.parent = null;
				}

			break;

			case State.KO :
				anim.SetInteger("AnimIndex" , 2);
				IdlePlayer();
			break;
		}
	}
}
