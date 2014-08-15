using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public Animator anim;
	public Enemy enemyScript;
	public float speed;
	public GameObject enemyObj;
	public int attack , hitpoints;
	public NavMeshAgent agent;
	public Transform target;

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
			agent = this.gameObject.GetComponent<NavMeshAgent>();
			anim = this.gameObject.GetComponent<Animator>();
		}
	}

	public void Attack()
	{
		if(enemyObj != null && enemyScript.currentState == Enemy.State.Hit)
		{
			enemyScript.DeductHitPoints(attack);
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
			//Debug.Log("Player Died");
			Destroy(this.gameObject);
		}	
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag.Equals("Target") && enemyScript.collidedPlayer)
		{
			//Debug.Log("Collision with Enemy");
			SetState(2);
		}

		if(col.gameObject.tag.Equals("Left") || col.gameObject.tag.Equals("Right"))
		{
			//Debug.Log("Collision with Truck");
			SetState(0);
		}
	}

	public void SetState(int newState)
	{
		previousState = currentState;
		currentState = (State)newState;
	}
	
	void Run()
	{
		anim.SetInteger("AnimIndex" , 1);

		if(target != null)
		{
			agent.speed = 7;
			agent.SetDestination(target.position);
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
			case State.Idle :
				anim.SetInteger("AnimIndex" , 0);
				agent.speed = 0;
			break;
				
			case State.Run :
				Run();
			break;
				
			case State.Attack :
				anim.SetInteger("AnimIndex" , 2);
			break;
		}
	}
}
