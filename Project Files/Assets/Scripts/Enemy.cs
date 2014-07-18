using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	
	NavMeshAgent nmAgent;
	public Transform target;
	
	void Start () 
	{
		nmAgent = GetComponent<NavMeshAgent>();
	}
	
	void Update () 
	{
		nmAgent.SetDestination(target.position);
	}
}
