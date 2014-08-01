using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public EnemySpawner enemySpawnerScript;
	public float speed;
	public GameObject enemySpawnerObj , iguiObj;
	public InGameUI iguiScript;
	public int hitpoints;
	public NavMeshAgent brain;
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
			brain = this.gameObject.GetComponent<NavMeshAgent>();

			if(transform.position.x < 0)
			{
				target = GameObject.FindGameObjectWithTag("Left").transform;
			}

			else if(transform.position.x > 0)
			{
				target = GameObject.FindGameObjectWithTag("Right").transform;
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
		brain.destination = target.position;
	}

	void Update () 
	{
		if(Time.timeScale == 0)
		{
			return;
		}
		Walk();
		switch(currentState)
		{
			case State.Walk :
				//Walk();
			break;

			case State.Hit :

			break;

			case State.KO :

			break;
		}
	}
}
