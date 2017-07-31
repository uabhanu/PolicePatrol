using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlendProgress : MonoBehaviour
{
    bool m_registeredInputEvents;
    [SerializeField] BansTouchInputListener m_touchInputListener;
    [SerializeField] Slider m_blendSlider;

	void Start()
    {
	    RegisterEvents();
	}

    void Update()
    {
        m_blendSlider.value += 0.01f;
    }

    void OnTapped(TouchInfo touchInfo)
    {
        m_blendSlider.value -= 0.1f;
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
