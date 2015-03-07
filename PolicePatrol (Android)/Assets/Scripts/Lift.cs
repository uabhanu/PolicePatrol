using System.Collections;
using UnityEngine;

public class Lift : MonoBehaviour 
{
	public AudioSource m_liftSound;
	public bool m_liftReady = false , m_touchReleased;
	public float m_speed;
	public int m_i;
	public Sprite[] m_liftLightSprites;
	public SpriteRenderer m_liftLightRenderer;
	public Transform[] m_targetPositions;
	
	void Start () 
	{

	}

	public void TouchInput(TouchInfo touchInfo)
	{
		SriTouchGestures gesture = touchInfo.touchGesture;
		m_touchReleased = false;
		
		switch(gesture)
		{
			case SriTouchGestures.SRI_NONE:

			break;

			case SriTouchGestures.SRI_SWIPEDDOWN:
				
				Debug.Log("Lift Swiped Down");

				if(m_liftReady)
				{
					if(m_i > 0)
					{
						m_i--;
					}
				}
			
			break;

			case SriTouchGestures.SRI_SWIPEDUP:

				Debug.Log("Lift Swiped Up");

				if(m_liftReady)
				{
					if(m_i < 1)
					{
						m_i++;
					}
				}

			break;
			
			case SriTouchGestures.SRI_RELEASED:
		
			break;
		}
	}
		
	void Update()
	{
		if(Time.timeScale == 0)
		{
			return;
		}

		if(m_liftReady)
		{
			m_liftLightRenderer.sprite = m_liftLightSprites[1];
		}

		else if(!m_liftReady)
		{
			m_liftLightRenderer.sprite = m_liftLightSprites[0];
		}

		float step = m_speed * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position , m_targetPositions[m_i].position , step);
	}
}
