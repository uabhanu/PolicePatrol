using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public Animator anim;
	public float enemyToWayPointDistance , smoothTime , wayPointDistance = 10.0f;
	public GameObject closestWayPoint , wayPointControlObj , wayPointObj;
	public GameObject[] destinationObjs;
	public List<Transform> destinations;
	//public Transform truckLocation;
	//public List<Transform> truckLocation;
	public Vector3 velocity;
	//public WayPointController wayPointControllerScript;

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

		destinationObjs = GameObject.FindGameObjectsWithTag("Destination");

		SetDestinations();
		GetDestinations();

//		wayPointControlObj = GameObject.FindGameObjectWithTag("WayPointControl");
//
//		if(wayPointControlObj != null)
//		{
//			wayPointControllerScript = wayPointControlObj.GetComponent<WayPointController>();
//		}
//
//		closestWayPoint = wayPointControllerScript.FindClosestWayPoint(transform);
//
//		if(closestWayPoint != null)
//		{
//			truckLocation = closestWayPoint.GetComponent<WayPoint>().GetTruckLocation();
//		}

		if(transform.position.y < 0)
		{
			anim.SetInteger("AnimIndex" , 1);
		}
	}

	void Movement()
	{
		//transform.Translate(Vector3.SmoothDamp(transform.position , closestWayPoint.transform.position , ref velocity , smoothTime));
	}

	void SetDestinations()
	{
		if(destinationObjs != null)
		{
			destinations.Add(destinationObjs[0].transform);
			destinations.Add(destinationObjs[1].transform);
			destinations.Add(destinationObjs[2].transform);
			destinations.Add(destinationObjs[3].transform);
			destinations.Add(destinationObjs[4].transform);
			destinations.Add(destinationObjs[5].transform);
		}
	}

	public void SetState(int newState)
	{
		previousState = currentState;
		currentState = (State)newState;
	}

	public List<Transform> GetDestinations()
	{
		return new List<Transform>(destinations);
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
