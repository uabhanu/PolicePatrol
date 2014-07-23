using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public Animator anim;
	public float enemyToWayPointDistance , smoothTime , wayPointDistance = 10.0f;
	public GameObject closestWayPoint , wayPointControlObj , wayPointObj;
	//public Transform truckLocation;
	public List<Transform> truckLocation;
	public Vector3 velocity;
	public WayPointController wayPointControllerScript;

	public enum State
	{
		Walk,
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

		wayPointControlObj = GameObject.FindGameObjectWithTag("WayPointControl");

		if(wayPointControlObj != null)
		{
			wayPointControllerScript = wayPointControlObj.GetComponent<WayPointController>();
		}

		closestWayPoint = wayPointControllerScript.FindClosestWayPoint(transform);

		if(closestWayPoint != null)
		{
			truckLocation = closestWayPoint.GetComponent<WayPoint>().GetTruckLocation();
		}

		if(transform.position.y < 0)
		{
			anim.SetInteger("AnimIndex" , 1);
		}
	}

	void Movement()
	{
		//closestWayPoint = wayPointControlScript.FindClosestWayPoint(transform);
		//truckLocation = closestWayPoint.GetComponent<WayPoint>().GetTruckLocation();

		//transform.Translate(Vector3.SmoothDamp(transform.position , closestWayPoint.transform.position , ref velocity , smoothTime));
		if(closestWayPoint != null)
		{
			transform.position = Vector3.SmoothDamp(transform.position , closestWayPoint.transform.position , ref velocity , smoothTime);

			enemyToWayPointDistance = Vector3.Distance(transform.position , closestWayPoint.transform.position);
			
			if(enemyToWayPointDistance < wayPointDistance && truckLocation.Count > 1)
			{
				closestWayPoint = truckLocation[truckLocation.Count - 2].gameObject;
				truckLocation = closestWayPoint.GetComponent<WayPoint>().GetTruckLocation();
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
			case State.Walk :
				Movement();
			break;
		}
	}
}
