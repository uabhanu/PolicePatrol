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
	public GameObject edSpawnObj , policeObj;
	public int incrementCount = 1;
	public Police policeScript;

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

		StartCoroutine("ExistenceTimer");
	}

	IEnumerator ExistenceTimer()
	{
		yield return new WaitForSeconds(10);
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
