using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	public Animator anim;
	//public Enemy enemyScript;
	public float speed;
	//public GameObject enemyObj;
	public int attack , hitpoints;
	public List<Vector2> path;
	public Transform pathTarget;

	public enum State
	{
		Idle,
		Run,
		Attack,
	};
	
	public State currentState;
	public State previousState;
	
	void Start () 
	{
		if(this.gameObject != null)
		{
			anim = this.gameObject.GetComponent<Animator>();
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
			//Debug.Log("Player Died");
			Destroy(this.gameObject);
		}	
	}

	void Movement()
	{
		//Debug.Log("Movement Method");

		if(path != null && path.Count != 0)
		{
			anim.SetBool("Moving" , true);
			transform.position = Vector2.MoveTowards(transform.position , path[0] , speed * Time.deltaTime);
			
			if(Vector2.Distance(transform.position , path[0]) < 0.01f)
			{
				path.RemoveAt(0);
				SetState(0);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag.Equals("Enemy"))
		{
			Debug.Log("Collided Enemy");
			SetState(2);
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
				anim.SetBool("Moving" , false);
				anim.SetBool("Attacking" , false);
			break;

			case State.Run :
				Movement();
			break;

			case State.Attack :
				anim.SetBool("Attacking" , true);
			break;
		}
	}
}
