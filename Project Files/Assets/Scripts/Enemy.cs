using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public Animator anim;
	public float speed;
	public Transform[] trucks;
	public List<Vector2> path;
	public Transform pathTarget;

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
		trucks[0] = GameObject.FindGameObjectWithTag("Left").transform;
		trucks[1] = GameObject.FindGameObjectWithTag("Right").transform;

		if(this.gameObject != null)
		{
			anim = GetComponent<Animator>();
		}

		if(transform.position.y < 0)
		{
			anim.SetInteger("AnimIndex" , 1);

			if(transform.position.x < 0)
			{
				pathTarget = trucks[0];
				path = NavMesh2D.GetSmoothedPath(transform.position , pathTarget.position);
			}

			else if(transform.position.x > 0)
			{
				pathTarget = trucks[1];
				path = NavMesh2D.GetSmoothedPath(transform.position , pathTarget.position);
			}
		}

		if(transform.position.y > 0)
		{
			anim.SetInteger("AnimIndex" , 0);
			
			if(transform.position.x < 0)
			{
				pathTarget = trucks[0];
				path = NavMesh2D.GetSmoothedPath(transform.position , pathTarget.position);
			}
			
			else if(transform.position.x > 0)
			{
				pathTarget = trucks[1];
				path = NavMesh2D.GetSmoothedPath(transform.position , pathTarget.position);
			}
		}
	}

	void Movement()
	{
		//transform.position = Vector3.SmoothDamp(transform.position , closestWayPoint.transform.position , ref velocity , smoothTime);

		if(path != null && path.Count != 0)
		{
			transform.position = Vector2.MoveTowards(transform.position , path[0] , speed * Time.deltaTime);

			if(Vector2.Distance(transform.position , path[0]) < 0.01f)
			{
				path.RemoveAt(0);
			}
		}

		if(transform.position.y >= 0)
		{
			//transform.position = new Vector2(transform.position.x , transform.position.y - speed);
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
			case State.Walk :
				Movement();
			break;
		}
	}
}
