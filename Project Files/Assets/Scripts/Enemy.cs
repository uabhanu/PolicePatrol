using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public Animator anim;
	public bool selected;
	public EnemySpawner enemySpawnerScript;
	public float speed;
	public GameObject enemySpawner , iguiObj;
	public InGameGUI iguiScript;
	public int hitpoints;
	public List<Vector2> path;
	public string type;
	public Transform pathTarget;
	public Transform[] trucks;

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
		enemySpawner = GameObject.Find("PF_EnemySpawner");

		iguiObj = GameObject.FindGameObjectWithTag("IGUI");

		if(iguiObj != null)
		{
			iguiScript = iguiObj.GetComponent<InGameGUI>();
		}

		if(enemySpawner != null)
		{
			enemySpawnerScript = enemySpawner.GetComponent<EnemySpawner>();
		}

		trucks[0] = GameObject.FindGameObjectWithTag("Left").transform;
		trucks[1] = GameObject.FindGameObjectWithTag("Right").transform;

		if(this.gameObject != null)
		{
			anim = GetComponent<Animator>();
		}

		if(transform.position.y < 0)
		{
			anim.SetInteger("AnimIndex" , 1);
			type = "Bottom";

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
			type = "Top";
			
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

	public void DeductHitPoints(int val)
	{
		if(hitpoints > 0)
		{
			hitpoints = hitpoints - val;
		}
		
		if (hitpoints <= 0)
		{
			//Debug.Log("Enemy Died");
			enemySpawnerScript.enemies--;
			Destroy(this.gameObject);
		}	
	}

	void Movement()
	{
		if(path != null && path.Count != 0)
		{
			transform.position = Vector2.MoveTowards(transform.position , path[0] , speed * Time.deltaTime);

			if(Vector2.Distance(transform.position , path[0]) < 0.01f)
			{
				path.RemoveAt(0);
			}
		}		
	}

	void OnMouseDown()
	{
		selected = true;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(type == "Top")
		{
			if(col.gameObject.tag.Equals("TopLeft"))
			{
				//Debug.Log("Left Walk");
				anim.SetInteger("AnimIndex" , 2);
			}
			
			if(col.gameObject.tag.Equals("TopRight"))
			{
				//Debug.Log("Right Walk");
				anim.SetInteger("AnimIndex" , 3);
			}
		}

		else if(type == "Bottom")
		{
			if(col.gameObject.tag.Equals("BottomLeft"))
			{
				//Debug.Log("Left Walk");
				anim.SetInteger("AnimIndex" , 2);
			}
			
			if(col.gameObject.tag.Equals("BottomRight"))
			{
				//Debug.Log("Right Walk");
				anim.SetInteger("AnimIndex" , 3);
			}
		}

		if(col.gameObject.tag.Equals("Left"))
		{
			if(iguiScript.leftScoreValue < 5)
			{
				iguiScript.leftScoreValue++;
			}

			DeductHitPoints(hitpoints);
		}

		if(col.gameObject.tag.Equals("Right"))
		{
			if(iguiScript.rightScoreValue < 5)
			{
				iguiScript.rightScoreValue++;
			}
	
			DeductHitPoints(hitpoints);
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
