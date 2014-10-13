using GooglePlayGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnergyDrink : MonoBehaviour 
{
	private string twoDrinks = "CgkI86253N8QEAIQAQ";
	private string fourDrinks = "CgkI86253N8QEAIQAg";

	public bool achievement1 = false , achievement2 = false;
	public EDSpawner edSpawnScript;
	public GameObject edSpawnObj , policeObj , thugObj;
	public int incrementCount = 1;
	public Police policeScript;
	public Thug thugScript;

	void Start () 
	{
		edSpawnObj = GameObject.FindGameObjectWithTag("EDSpawn");

		if(edSpawnObj != null)
		{
			edSpawnScript = edSpawnObj.GetComponent<EDSpawner>();
		}

		policeObj = GameObject.FindGameObjectWithTag("Player");

		if(policeObj != null)
		{
			policeScript = policeObj.GetComponent<Police>();
		}

		thugObj = GameObject.FindGameObjectWithTag("Enemy");

		if(thugObj != null)
		{
			thugScript = thugObj.GetComponent<Thug>();
		}

		StartCoroutine("ExistenceTimer");
	}

	IEnumerator ExistenceTimer()
	{
		yield return new WaitForSeconds(15);
		Destroy(this.gameObject);
		StartCoroutine("ExistenceTimer");
	}

	void FiveDrinks()
	{
		if(achievement1)
		{
			incrementCount = 0;

			if (Social.localUser.authenticated)
			{
				((PlayGamesPlatform)Social.Active).IncrementAchievement(fourDrinks , incrementCount , (bool success) =>
                {
					if(incrementCount < 4)
					{
						incrementCount++;
						Social.ShowAchievementsUI();
					}
				});
			}
		}
	}

	void OnMouseDown()
	{
		//Debug.Log("Energy Drink Selected");
		
		if(policeScript.currentState != Police.State.Attack)
		{	
			policeScript.target = this.gameObject.transform;
			policeScript.SetState(1);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
			Debug.Log("Player had a Drink");

			policeScript.attack = 6;
			policeScript.agent.speed = 28;
			policeScript.energyExpireTimer = 15;

			FiveDrinks();
			TwoDrinks();

			Destroy(this.gameObject);
		}
	}

	void TwoDrinks()
	{
		if (Social.localUser.authenticated)
		{
			((PlayGamesPlatform)Social.Active).IncrementAchievement(twoDrinks , incrementCount , (bool success) =>
        	{
				if(incrementCount < 2)
				{
					incrementCount++;
					Social.ShowAchievementsUI();
				}
			});
		}

		if(incrementCount == 2)
		{
			achievement1 = true;
		}
	}

	void Update () 
	{
		if(Time.timeScale == 0)
		{
			return;
		}

		if(transform.position.z > 10)
		{
			transform.position = new Vector3(transform.position.x , transform.position.y , transform.position.z - 1.0f);
		}
	}
}
