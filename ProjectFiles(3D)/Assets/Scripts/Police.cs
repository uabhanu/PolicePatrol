using UnityEngine;
using System.Collections;

public class Police : MonoBehaviour 
{
	public Animator anim;
	public EnergyDrink energyDrinkScript;
	public GameObject energyDrinkObj , thugObj;
	public int attack , hitpoints;
	public NavMeshAgent agent;
	public Thug thugScript;
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

		//StartCoroutine("ResetPolice");
	}

	IEnumerator ResetPolice()
	{
		yield return new WaitForSeconds(15);

		if(agent.acceleration > 8 && attack > 1)
		{
			//Debug.Log("Normal Police");
			agent.acceleration = 8;
			attack = 1;
		}

		StartCoroutine("ResetPolice");
	}

	public void Attack()
	{
		if(thugScript != null && thugScript.currentState == Thug.State.Hit)
		{
			thugScript.DeductHitPoints(attack);
			thugScript.Hit();
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

	public void Idle()
	{
		anim.SetInteger("AnimIndex" , 0);
	}

	void OnCollisionEnter(Collision col)
	{
		if(thugScript != null)
		{
			if(col.gameObject.tag.Equals("Enemy") && thugScript.collidedPlayer)
			{
				//Debug.Log("Collision with Enemy");
				SetState(2);
			}
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

		else if(target == null)
		{
			SetState(0);
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
				agent.speed = 0;
				anim.SetInteger("AnimIndex" , 0);
			break;
				
			case State.Run :
				Run();
			break;
				
			case State.Attack :
				agent.speed = 0;
				anim.SetInteger("AnimIndex" , 2);
			break;
		}
	}
}
