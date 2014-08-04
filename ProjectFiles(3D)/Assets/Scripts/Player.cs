using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public Animator anim;
	public float speed;
	public int hitpoints;
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
		if(col.gameObject.tag.Equals("Enemy"))
		{
			Debug.Log("Collision with Enemy");
			SetState(2);
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
			case State.Idle :

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
