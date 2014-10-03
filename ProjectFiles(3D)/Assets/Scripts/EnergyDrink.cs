using GooglePlayGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnergyDrink : MonoBehaviour 
{
	private string fiveDrinks = "CgkIz8X_7JkXEAIQAg";
	private string tenDrinks = "CgkIz8X_7JkXEAIQAw";

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
		if (Social.localUser.authenticated)
		{
			((PlayGamesPlatform)Social.Active).IncrementAchievement(fiveDrinks , incrementCount , (bool success) =>
        	{
				if(incrementCount < 2)
				{
					incrementCount++;
					Social.ShowAchievementsUI();
				}
			});
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
			TenDrinks();

			Destroy(this.gameObject);
		}
	}

	void TenDrinks()
	{
		if (Social.localUser.authenticated)
		{
			((PlayGamesPlatform)Social.Active).IncrementAchievement(tenDrinks , incrementCount , (bool success) =>
        	{
				if(incrementCount < 5)
				{
					incrementCount++;
					Social.ShowAchievementsUI();
				}
			});
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
