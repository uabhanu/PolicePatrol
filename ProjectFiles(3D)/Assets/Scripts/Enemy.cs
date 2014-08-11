using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public Animator anim;
	public bool collidedPlayer;
	public EnemySpawner enemySpawnerScript;
	public float speed;
	public GameObject enemySpawnerObj , iguiObj , playerObj;
	public InGameUI iguiScript;
	public int hitpoints;
	public NavMeshAgent agent;
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

	public void DeductHitPoints(int val)
	{
		if(hitpoints > 0)
		{
			hitpoints = hitpoints - val;
		}
		
		if (hitpoints <= 0)
		{
			//Debug.Log("Enemy Died");
			Destroy(this.gameObject);
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
			
			DeductHitPoints(hitpoints);
			enemySpawnerScript.enemies--;
		}
		
		if(col.gameObject.tag.Equals("Right"))
		{
			if(iguiScript.truckRightScoreValue < 5)
			{
				iguiScript.truckRightScoreValue++;
			}
			
			DeductHitPoints(hitpoints);
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
		if(playerScript.currentState != Player.State.Attack)
		{
			playerScript.target = this.gameObject.transform;
			playerScript.SetState(1);
		}
	}

	public void SetState(int newState)
	{
		previousState = currentState;
		currentState = (State)newState;
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
