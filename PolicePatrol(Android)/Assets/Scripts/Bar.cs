using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    bool m_registeredInputEvents;
    [SerializeField] float m_force;
    [SerializeField] Rigidbody2D m_barBody2D;
    [SerializeField] SriTouchInputListener m_touchInputListener;

	void Start()
    {
	    RegisterEvents();
	}

    void OnTapped(TouchInfo touchInfo)
    {
        m_barBody2D.AddForce(new Vector2(0f , m_force));
    }
	
	void RegisterEvents()
    {
        if(!m_registeredInputEvents && m_touchInputListener)
		{
			m_touchInputListener.Tap += OnTapped;
			m_registeredInputEvents = true;
		}
    }

    void UnregisterEvents()
    {
        if(m_registeredInputEvents)
		{
			if(m_touchInputListener)
            {
                m_touchInputListener.Tap -= OnTapped;
            }
            
			m_registeredInputEvents = false;
		}
    }
}
