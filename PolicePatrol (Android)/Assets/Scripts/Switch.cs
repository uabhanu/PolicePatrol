using System.Collections;
using UnityEngine;

public class Switch : MonoBehaviour 
{
	public bool m_ready = false;
	public float m_switchTime;
	public PoliceController m_policeScript;
	public Sprite m_switchON , m_switchOFF;
	public SpriteRenderer m_switchRenderer;
	public string m_switchCount;
	
	void Start () 
	{
		m_switchRenderer.sprite = m_switchOFF;
	}

	IEnumerator ChangeSwitch()
	{
		yield return new WaitForSeconds(m_switchTime);

		if(m_switchRenderer.sprite.Equals(m_switchOFF))
		{
			m_switchRenderer.sprite = m_switchON;
		}
	}

	void OnMouseDown()
	{
		if(m_ready)
		{
			//Debug.Log("Tapped");
			m_policeScript.SetState(PoliceController.PlayerState.SLAP);
			StartCoroutine("ChangeSwitch");
		}
	}

	void OnTriggerEnter2D(Collider2D col2D)
	{
		if(col2D.gameObject.tag.Equals("Player"))
		{
			m_ready = true;
			m_policeScript.m_switchCount = m_switchCount;
		}
	}

	void OnTriggerExit2D(Collider2D col2D)
	{
		if(col2D.gameObject.tag.Equals("Player"))
		{
			m_ready = false;
		}
	}

	void Update () 
	{
		if(Time.timeScale == 0)
		{
			return;
		}

		m_switchTime = m_policeScript.m_idleTime;
	}
}
