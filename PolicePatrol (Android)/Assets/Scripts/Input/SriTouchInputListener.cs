using UnityEngine;
using System.Collections;


public class SriTouchInputListener : MonoBehaviour
{	
    void Start()
    {

    }
	
    void Update()
    {

    }

    public void TouchInputListener(TouchInfo touchInfo)
    {
        TouchInfo newInfo = touchInfo;
		SendMessage("TouchInput" , newInfo);
    }
}
