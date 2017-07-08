using System.Collections;
using UnityEngine;

public class BlendUIBar : MonoBehaviour 
{
	[SerializeField] float m_blendUIGravityScale;
	[SerializeField] PoliceController m_policeScript;
	[SerializeField] Rigidbody2D m_blendUIBarBody2D;
	[SerializeField] SpriteRenderer[] m_blendUIRenderers;
	[SerializeField] Thug[] m_thugScripts;
	[SerializeField] Transform m_start;

	void Start () 
	{
		m_blendUIBarBody2D.isKinematic = true;
		StartCoroutine("BlendUIProperties");
	}

	#region IEnumerator BlendUIProperties()
	IEnumerator BlendUIProperties()
	{
		yield return new WaitForSeconds(0.5f);

		if(m_blendUIRenderers[0].enabled)
		{
			m_blendUIBarBody2D.isKinematic = false;
			m_blendUIBarBody2D.gravityScale = m_blendUIGravityScale;
		}

		if(!m_blendUIRenderers[0].enabled)
		{
			m_blendUIBarBody2D.isKinematic = true;
			transform.position = m_start.position;
		}

		StartCoroutine("BlendUIProperties");
	}
	#endregion

	#region GravityScale()
	void GravityScale()
	{
		if(m_blendUIRenderers[0].enabled && transform.position.y < 1.464f)
		{
			m_blendUIBarBody2D.gravityScale = -m_blendUIGravityScale;
		}
	}
	#endregion

	#region OnCollisionEnter2D()
	void OnCollisionEnter2D(Collision2D col2D)
	{
		if(col2D.gameObject.name.Equals("BlendUI"))
		{
			//Debug.Log("BlendUI");

			if(m_thugScripts[0] != null && m_thugScripts[0].m_currentState == Thug.EnemyState.LOOKOUT)
			{
				m_policeScript.SetState(PoliceController.PlayerState.DYING);
				m_thugScripts[0].SetState(Thug.EnemyState.ATTACK);
				//Debug.Log("BlendUI");
			}

			if(m_thugScripts[1] != null && m_thugScripts[1].m_currentState == Thug.EnemyState.LOOKOUT)
			{
				m_policeScript.SetState(PoliceController.PlayerState.DYING);
				m_thugScripts[1].SetState(Thug.EnemyState.ATTACK);
				//Debug.Log("BlendUI");
			}

			if(m_thugScripts[2] != null && m_thugScripts[2].m_currentState == Thug.EnemyState.LOOKOUT)
			{
				m_policeScript.SetState(PoliceController.PlayerState.DYING);
				m_thugScripts[2].SetState(Thug.EnemyState.ATTACK);
				//Debug.Log("BlendUI");
			}

			if(m_thugScripts[3] != null && m_thugScripts[3].m_currentState == Thug.EnemyState.LOOKOUT)
			{
				m_policeScript.SetState(PoliceController.PlayerState.DYING);
				m_thugScripts[3].SetState(Thug.EnemyState.ATTACK);
				//Debug.Log("BlendUI");
			}

		}
	}
	#endregion

	#region Update()
	void Update () 
	{
		if(Time.timeScale == 0)
		{
			return;
		}

		if(Input.GetMouseButtonDown(0))
		{
			GravityScale();
		}
	}
	#endregion
}
