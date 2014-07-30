using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	public Enemy enemyScript;
	public float speed;
	public GameObject enemyObj;
	public int attack , hitpoints;
	public List<Vector2> path;
	public Transform pathTarget;

	public enum State
	{
		Idle,
		Walk,
		Attack,
	};
	
	public State currentState;
	public State previousState;
	
	void Start () 
	{
		SetState(0);
		StartCoroutine("GetEnemyTimer");
	}

	public void DeductHitPoints(int val)
	{
		if(hitpoints > 0)
		{
			hitpoints = hitpoints - val;
		}
		
		if (hitpoints <= 0)
		{
			//Debug.Log("Player Died");
			Destroy(this.gameObject);
		}	
	}

	IEnumerator GetEnemyTimer()
	{
		yield return new WaitForSeconds(4);

		//Debug.Log("Get Enemy Timer");

		enemyObj = GameObject.FindGameObjectWithTag("Enemy");

		if(enemyObj != null)
		{
			enemyScript = enemyObj.GetComponent<Enemy>();
		}

		pathTarget = enemyObj.transform;
		path = NavMesh2D.GetSmoothedPath(transform.position , pathTarget.position);

		SetState(1);
		StartCoroutine("GetEnemyTimer");
	}

	void Movement()
	{
		//Debug.Log("Movement Method");
		if(path != null && path.Count != 0)
		{
			transform.position = Vector2.MoveTowards(transform.position , path[0] , speed * Time.deltaTime);
			
			if(Vector2.Distance(transform.position , path[0]) < 0.01f)
			{
				path.RemoveAt(0);
			}
		}
	}

	public void SetState(int newState)
	{
		previousState = currentState;
		currentState = (State)newState;
	}

	void Update () 
	{
		if(Time.timeScale == 0)
		{
			return;
		}

		switch(currentState)
		{
			case State.Idle :

			break;

			case State.Walk :
				Movement();
			break;

			case State.Attack :

			break;
		}
	}	
}
