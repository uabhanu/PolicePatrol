using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public Animator anim;
	public bool collidedPlayer;
	public EnemySpawner enemySpawnerScript;
	public float speed;
	public GameObject enemySpawnerObj , iguiObj , playerObj , sweatObj;
	public InGameUI iguiScript;
	public int hitpoints;
	public NavMeshAgent agent;
	public ParticleSystem sweatParticles;
	public Player playerScript;
	public Transform target;

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
		enemySpawnerObj = GameObject.FindGameObjectWithTag("ESpawn");

		if(enemySpawnerObj != null)
		{
			enemySpawnerScript = enemySpawnerObj.GetComponent<EnemySpawner>();
		}

		if(this.gameObject != null)
		{
			agent = this.gameObject.GetComponent<NavMeshAgent>();
			anim = this.gameObject.GetComponent<Animator>();

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
			Destroy (this.gameObject);
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
			playerScript.SetState(0);
		}	
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag.Equals("Left"))
		{
			if(iguiScript.truckLeftScoreValue < 5)
			{
				iguiScript.truckLeftScoreValue++;
			}
			
			Death();
			enemySpawnerScript.enemies--;
		}
		
		if(col.gameObject.tag.Equals("Right"))
		{
			if(iguiScript.truckRightScoreValue < 5)
			{
				iguiScript.truckRightScoreValue++;
			}
			
			Death();
			enemySpawnerScript.enemies--;
		}

		if(col.gameObject.tag.Equals("Player"))
		{
			if(playerScript.currentState != Player.State.Attack)
			{
				Debug.Log("Collision with Player");
				collidedPlayer = true;
			}
		}
	}

	void OnMouseDown()
	{
		Time.timeScale = 1;

		if(playerScript.currentState != Player.State.Attack)
		{
			playerScript.enemyObj = this.gameObject;

			if(playerScript.enemyObj != null)
			{
				playerScript.enemyScript = playerScript.enemyObj.GetComponent<Enemy>();

				sweatObj = GameObject.FindGameObjectWithTag("Sweat");
				
				if(sweatObj != null)
				{
					sweatParticles = sweatObj.GetComponent<ParticleSystem>();
				}
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
		if(sweatObj != null)
		{
			sweatParticles.Play();
		}
	}

	void Walk()
	{
		agent.SetDestination(target.position);

		if(collidedPlayer && playerScript.currentState == Player.State.Attack)
		{
			agent.speed = 0;
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
				anim.SetInteger("AnimIndex" , 1);
			break;

			case State.KO :
				anim.SetInteger("AnimIndex" , 2);
			break;
		}
	}
}
