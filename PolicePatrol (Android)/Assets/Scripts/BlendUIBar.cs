using System.Collections;
using UnityEngine;

public class BlendUIBar : MonoBehaviour 
{
	public float m_blendUIGravityScale;
	public PoliceController m_policeScript;
	public Rigidbody2D m_blendUIBarBody2D;
	public SpriteRenderer[] m_blendUIRenderers;
	public Thug m_thugScript;
	public Transform m_start;


    void Start () 
	{
		m_blendUIBarBody2D.isKinematic = true;
        m_thugScript = GameObject.FindGameObjectWithTag("Thug").GetComponent<Thug>();
		StartCoroutine("BlendUIProperties");
	}

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

	void GravityScale()
	{
		if(m_blendUIRenderers[0].enabled && transform.position.y < 1.464f)
		{
			m_blendUIBarBody2D.gravityScale = -m_blendUIGravityScale;
		}
	}

	void OnCollisionEnter2D(Collision2D col2D)
	{
		if(col2D.gameObject.name.Equals("BlendUI"))
		{
			//Debug.Log("BlendUI");

			if(m_thugScript != null && m_thugScript.m_currentState == Thug.EnemyState.LOOKOUT)
			{
				m_policeScript.SetState(PoliceController.PlayerState.DYING);
				m_thugScript.SetState(Thug.EnemyState.ATTACK);
				//Debug.Log("BlendUI");
			}
		}
	}

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
}
