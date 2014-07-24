using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public Animator anim;

	public enum State
	{
		Walk,
		LeftWalk,
		RightWalk,
		Hit,
		Death,
	};
	
	public State currentState;
	public State previousState;

	void Start () 
	{
		if(this.gameObject != null)
		{
			anim = GetComponent<Animator>();
		}

		if(transform.position.y < 0)
		{
			anim.SetInteger("AnimIndex" , 1);
		}
	}

	void Movement()
	{
		//transform.position = Vector3.SmoothDamp(transform.position , closestWayPoint.transform.position , ref velocity , smoothTime);
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
			case State.Walk :
				Movement();
			break;
		}
	}
}
