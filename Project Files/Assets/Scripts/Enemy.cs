using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public Animator anim;
	public float enemyToWayPointDistance , smoothTime;
	public GameObject closestWayPoint , wayPointControlObj;
	//public GameObject[] destinationObjs;
	public List<Transform> destinations;
	//public Transform truckLocation;
	public List<Transform> truckLocation;
	public Vector3 velocity;
	public WayPointController wayPointControllerScript;

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

		//destinationObjs = GameObject.FindGameObjectsWithTag("Destination");

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
		transform.position = Vector3.SmoothDamp(transform.position , closestWayPoint.transform.position , ref velocity , smoothTime);
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
