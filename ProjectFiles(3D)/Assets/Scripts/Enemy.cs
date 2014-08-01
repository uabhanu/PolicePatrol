using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public Animator anim;
	public EnemySpawner enemySpawnerScript;
	public float speed;
	public GameObject enemySpawnerObj , iguiObj;
	public InGameUI iguiScript;
	public int hitpoints;
	public NavMeshAgent agent;
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

		SetState(0);
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
	}

	public void SetState(int newState)
	{
		previousState = currentState;
		currentState = (State)newState;
	}

	void Walk()
	{
		anim.SetInteger("AnimIndex" , 0);
		agent.SetDestination(target.position);
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

			break;

			case State.KO :

			break;
		}
	}
}
