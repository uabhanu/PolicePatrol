using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public Animator anim;
	public float smoothTime;
	public GameObject closestWayPoint , wayPointControlObj , wayPointObj;
	//public Transform truckLocation;
	public List<Transform> truckLocations;
	public Vector3 velocity;
	public WayPointController wayPointControlScript;

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

		//truckLocation = GameObject.FindGameObjectWithTag("Truck").transform;

		wayPointControlObj = GameObject.FindGameObjectWithTag("WayPointControl");

		if(wayPointControlObj != null)
		{
			wayPointControlScript = wayPointControlObj.GetComponent<WayPointController>();
		}

		closestWayPoint = wayPointControlScript.FindClosestWayPoint(transform);
		truckLocations = closestWayPoint.GetComponent<WayPoint>().GetTruckLocation();

		if(transform.position.y < 0)
		{
			anim.SetInteger("AnimIndex" , 1);
		}
	}

	public void SetState(int newState)
	{
		previousState = currentState;
		currentState = (State)newState;
	}
	
	void Update () 
	{
		//transform.Translate(Vector3.SmoothDamp(transform.position , closestWayPoint.transform.position , ref velocity , smoothTime));
		transform.position = Vector3.SmoothDamp(transform.position , closestWayPoint.transform.position , ref velocity , smoothTime);
	}
}
