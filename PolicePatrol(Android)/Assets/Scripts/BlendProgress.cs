using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlendProgress : MonoBehaviour
{
    [SerializeField] BansTouchInputListener m_touchInputListener;
    [SerializeField] bool m_registeredInputEvents;
    [SerializeField] PoliceController m_copControlScript;
    [SerializeField] Slider m_blendSlider;

	void Start()
    {
        RegisterEvents();
	}

    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        m_blendSlider.value += 0.005f;
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

    public void ResetSliderValue()
    {
        m_blendSlider.value = 0;
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
