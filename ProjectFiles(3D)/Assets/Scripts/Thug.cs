using UnityEngine;
using System.Collections;

public class Thug : MonoBehaviour 
{
	public Animator anim;
	public bool collidedPlayer , selected;
	[HideInInspector]
	public float speed , tagTimer;
	public GameObject iguiObj , policeObj , truckLeft , truckRight;
	public GameObject[] enemies;
	public InGameUI iguiScript;
	public int hitpoints;
	public NavMeshAgent agent;
	public ParticleSystem sweatParticles;
	public Police policeScript;
	public Rigidbody boxBody;
	public static Thug current;
	public Transform target;

	public enum State
	{
		Walk,
		Hit,
		KO,
	};
	
	public State currentState;
	public State previousState;
	
	void Start () 
	{
		if(this.gameObject != null)
		{
			agent = this.gameObject.GetComponent<NavMeshAgent>();
			anim = this.gameObject.GetComponent<Animator>();

			truckLeft = GameObject.FindGameObjectWithTag("Left");
			truckRight = GameObject.FindGameObjectWithTag("Right");

			if(transform.position.x < 0)
			{
				if(truckLeft != null)
				{
					target = truckLeft.transform;
				}

				else if(truckRight != null)
				{
					target = truckRight.transform;
				}
			}

			else if(transform.position.x > 0)
			{
				if(truckRight != null)
				{
					target = truckRight.transform;
				}

				else if(truckLeft != null)
				{
					target = truckLeft.transform;
				}
			}

			if(transform.position.z > 0)
			{
				this.gameObject.transform.Rotate(0 , 180 , 0);
			}
		}

		iguiObj = GameObject.FindGameObjectWithTag("IGUI");

		if(iguiObj != null)
		{
			iguiScript = iguiObj.GetComponent<InGameUI>();
		}

		policeObj = GameObject.FindGameObjectWithTag("Player");

		if(policeObj != null)
		{
			policeScript = policeObj.GetComponent<Police>();
		}
	}

	public void Death()
	{
		if(this.gameObject != null)
		{
			//Debug.Log("Enemy Death");

			if(currentState == State.KO)
			{
				policeScript.SetState(0);
			}


			if(iguiScript.thugCount > 0)
			{
				iguiScript.thugCount--;
			}

			Destroy(this.gameObject);

			if(current != null && policeScript != null && policeScript.target == current.gameObject)
			{
				policeScript.target = null;
			}
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
			//Debug.Log("Enemy Died");
			SetState(2);
		}	
	}

	public void Hit()
	{
		//Debug.Log("Enemy Hit Animation");
		anim.SetInteger("AnimIndex" , 1);
		anim.Play(0);
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag.Equals("Left"))
		{
			if(currentState != State.Hit)
			{
				if(iguiScript.truckLeftScoreValue < 5)
				{
					iguiScript.truckLeftScoreValue++;
				}
				
				Death();
			}
		}
		
		if(col.gameObject.tag.Equals("Right"))
		{
			if(currentState != State.Hit)
			{
				if(iguiScript.truckRightScoreValue < 5)
				{
					iguiScript.truckRightScoreValue++;
				}
				
				Death();
			}
		}

		if(col.gameObject.tag.Equals("Player") && selected)
		{
			//Debug.Log("Collision with Player");
			current.collidedPlayer = true;
		}
	}

	void IdlePlayer()
	{
		//Debug.Log("Player Idle Again");
		policeScript.Idle();
	}

	void OnCollisionExit(Collision col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
			current.collidedPlayer = false;
		}
	}

	void OnMouseDown()
	{
		//Debug.Log("Enemy Selected");

		if(current != null)
		{
			current.selected = false;
		}

		selected = true;
		current = this;

		sweatParticles = this.gameObject.GetComponentInChildren<ParticleSystem>();

		if(Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}

		if(policeScript.currentState != Police.State.Attack)
		{
			policeScript.thugObj = this.gameObject;

			if(policeScript.thugObj != null)
			{
				policeScript.thugScript = policeScript.thugObj.GetComponent<Thug>();
			}

			policeScript.target = this.gameObject.transform;
			policeScript.SetState(1);
		}
	}

	public void SetState(int newState)
	{
		previousState = currentState;
		currentState = (State)newState;
	}

	public void Sweat()
	{
		if(sweatParticles != null)
		{
			if(currentState == State.Hit)
			{
				Debug.Log("Enemy Sweat");
				sweatParticles.Play();
			}
		}
	}

	void Walk()
	{
		if(truckLeft == null && truckRight != null)
		{
			target = truckRight.transform;
		}

		else if(truckRight == null && truckLeft != null)
		{
			target = truckLeft.transform;
		}

		else if(truckLeft == null && truckRight == null)
		{
			target = null;
		}

		if(target != null)
		{
			agent.SetDestination(target.position);
		}

		else if(target == null)
		{
			agent.speed = 0;
		}

		if(this.collidedPlayer && selected && policeScript.currentState == Police.State.Attack)
		{
			SetState(1);
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
			case State.Walk :
				Walk();
			break;

			case State.Hit :

				agent.speed = 0;

				if(boxBody != null)
				{
					boxBody.useGravity = true;
					boxBody.transform.parent = null;
				}

			break;

			case State.KO :
				anim.SetInteger("AnimIndex" , 2);
				IdlePlayer();
			break;
		}
	}
}
