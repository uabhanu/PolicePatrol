using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour 
{
	public BlendUIBar m_blendUIBarScript;
	public SpriteRenderer[] m_blendUIRenderers;
	
	void Start () 
	{
		Disable("BlendUI");	
	}

	public void Disable(string name)
	{
		switch(name)
		{
			case "BlendUI" :
				m_blendUIRenderers[0].enabled = false;
				m_blendUIRenderers[1].enabled = false;
			break;
		}
	}

	public void Enable(string name)
	{
		switch(name)
		{
			case "BlendUI" :
				m_blendUIRenderers[0].enabled = true;
				m_blendUIRenderers[1].enabled = true;
			break;
		}
	}

	void Update () 
	{
	
	}
}
