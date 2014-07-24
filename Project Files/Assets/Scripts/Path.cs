using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Path<Node> : IEnumerable<Node> Gives error
public class Path : IEnumerable 
{
	public double TotalCost;
	public Node LastStep;
	public Path<Node> PreviousSteps;
	
	void Start () 
	{
	
	}

	void Update () 
	{
	
	}

	void EnemyPath(Node lastStep , Path<Node> previousSteps , double totalCost)
	{
		LastStep = lastStep;
		PreviousSteps = previousSteps;
		TotalCost = totalCost;
	}
}
