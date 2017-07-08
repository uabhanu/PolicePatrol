using System.Collections;
using UnityEngine;

public class CameraClass : MonoBehaviour 
{
	public float m_yOffset;
	public PoliceController m_policeScript;
	
	void Start () 
	{
	
	}
		
	void Update () 
	{
		if(m_policeScript.m_floor == 4)
		{
			transform.position = new Vector3(0 , m_policeScript.m_policeBody2D.position.y + m_yOffset , -10);
		}
	}
}
